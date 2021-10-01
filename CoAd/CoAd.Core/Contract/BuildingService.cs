using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using CoAd.Core.Database;
using CoAd.Model;
using CoAd.Model.Entities;
using CoAd.Model.Entities.Requests;
using CoAd.Model.Enums;

namespace CoAd.Core.Contract
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BuildingService : IService
    {
        public Package<ClientDataResponse> StoreData(ClientDataRequest request)
        {
            if(EngineModel.Instance.Configuration.CurrentConfig.Sleep !=0)
            Thread.Sleep(EngineModel.Instance.Configuration.CurrentConfig.Sleep);

            int time = 0;
            var resultList = new List<Parameter>();

            try
            {
                time = Watch.Instance.Time(() =>
                {
                    var db = new DataContext(EngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());
                    var server = db.GetTable<ClientServer>().FirstOrDefault(s => s.identifier == request.ClientId);

                    if (server == null) throw new CoAdException($"Объект {request.ClientId} не найден", ErrorEnum.NoObject);

                    #region stores (полный импорт)
                    var stores = db.GetTable<ClientStore>(); 
                    foreach (var store in request.Stores)
                    {
                        var st = stores.FirstOrDefault(s => s.id_server == server.id && s.fo_id_store == store.FoIdStore);
                        // проверка блокировки внесения изменений
                        if (st != null && (st.state == 1 || st.state == 2)) continue;
                        // проверка опоздавшего старого запроса с клиента
                        if (st != null && st.dateOfChange != null && st.state == 0
                            && (DateTime.Now - (DateTime) st.dateOfChange).Seconds < request.Delay) continue;
                        if (st != null)
                        {
                            st.name = store.Name;
                            st.egais_props = store.EgaisProps;
                            st.ofd_props = store.OfdProps;
                            st.bpa_props = store.BpaProps;
                        }
                        else
                        {
                            stores.InsertOnSubmit(new ClientStore
                            {
                                id_server = server.id,
                                fo_id_store = store.FoIdStore,
                                name = store.Name,
                                egais_props = store.EgaisProps,
                                ofd_props = store.OfdProps,
                                bpa_props = store.BpaProps,
                                state = 0
                            });
                        }
                    }
                    #endregion
                    Log.Instance.Info(this, "Объект {0}. Данные магазинов загружены. Общее количество {1}", request.ClientId, request.Stores.Count);

                    #region groups (полный импорт)
                    var groups = db.GetTable<ClientDeviceGroup>();
                    foreach (var group in request.Groups)
                    {
                        var gr = groups.FirstOrDefault(g => g.id_server == server.id && g.fo_id_group == group.FoIdGroup);
                        if (gr != null)
                        {
                            gr.name = group.Name;
                        }
                        else
                        {
                            groups.InsertOnSubmit(new ClientDeviceGroup
                            {
                                id_server = server.id,
                                fo_id_group = group.FoIdGroup,
                                name = group.Name
                            });
                        }
                    }
                    #endregion
                    Log.Instance.Info(this, "Объект {0}. Данные групп загружены. Общее количество {1}", request.ClientId, request.Groups.Count);

                    // группы устройств должны обновиться перед устройствами и параметрами
                    db.SubmitChanges();

                    #region devices (полный импорт)
                    var devices = db.GetTable<ClientDevice>();
                    foreach (var device in request.Devices)
                    {
                        var dv = devices.FirstOrDefault(d => d.id_server == server.id && d.fo_id_device == device.FoIdDevice);

                        int? groupId;
                        // анализируем фо-группу
                        if (device.Type != 6)
                        {
                            if (device.IdDeviceGroup == null)
                            {
                                Log.Instance.Info(this, "Объект {0}. Группа не определена", request.ClientId);
                                continue;
                            }
                            else
                            {
                                // нам приходит ФО группа устройств
                                var group = db.GetTable<ClientDeviceGroup>().FirstOrDefault(g => g.fo_id_group == device.IdDeviceGroup);
                                // группы вполне может и не быть на мертвом устройстве
                                if (group == null)
                                {
                                    Log.Instance.Info(this, "Объект {0}. Группа {1} не найдена", request.ClientId, device.IdDeviceGroup);
                                    continue;
                                }
                                else groupId = group.id;
                            }
                        }
                        else groupId = null;
                        
                        if (dv != null)
                        {
                            dv.type_device = device.Type;
                            dv.id_group = groupId;
                            dv.name = device.Name;
                            dv.status = device.Status;
                            dv.data = device.Data;
                            dv.settings = device.Settings;
                        }
                        else
                        {
                            devices.InsertOnSubmit(new ClientDevice
                            {
                                id_server = server.id,
                                fo_id_device = device.FoIdDevice,
                                type_device = device.Type,
                                id_group = groupId,
                                name = device.Name,
                                status = device.Status,
                                data = device.Data,
                                settings = device.Settings
                            });
                        }
                    }
                    #endregion
                    Log.Instance.Info(this, "Объект {0}. Данные устройств загружены. Общее количество {1}", request.ClientId, request.Devices.Count);

                    db.SubmitChanges();
                    
                    #region parameters (частичный импорт)
                    var parameters = db.GetTable<DeviceGroupParam>();
                    var paramTypes = db.GetTable<TypeParam>();
                    // группа приходи фо-шная
                    groups = db.GetTable<ClientDeviceGroup>();
                    foreach (var param in request.Parameters)
                    {
                        // ищем тип параметра
                        var type = paramTypes.FirstOrDefault(t => t.mnem_param == param.Mnemonics);
                        if (type == null)
                        {
                            Log.Instance.Info(this, "Объект {0}. Параметр с мнемоникой {1} не найден", request.ClientId, param.Mnemonics);
                            continue;
                        }
                        // ищем идентификатор группы
                        var group = groups.FirstOrDefault(g => g.fo_id_group == param.IdGroup);
                        if (group == null)
                        {
                            Log.Instance.Info(this, "Объект {0}. Параметр с группой {1} не найден", request.ClientId, param.IdGroup);
                            continue;
                        }
                        var pm = parameters.FirstOrDefault(p => p.TypeParam.mnem_param == param.Mnemonics && p.id_group == group.id);
                        // проверка блокировки внесения изменений
                        if (pm != null && (pm.state == 1 || pm.state == 2)) continue;
                        // проверка опоздавшего старого запроса с клиента
                        if (pm != null && pm.dateOfChange != null && pm.state == 0
                            && (DateTime.Now - (DateTime)pm.dateOfChange).Seconds < request.Delay) continue;

                        bool ok = true; // признак удачной обработки
                        var insertedParam = new DeviceGroupParam();
                        try // может что-то пойти не так
                        {
                            if (pm != null)
                            {
                                pm.value = param.Value;
                            }
                            else
                            {
                                insertedParam.id_group = group.id;
                                insertedParam.id_type = type.id_type;
                                insertedParam.value = param.Value;

                                parameters.InsertOnSubmit(insertedParam);
                                //parameters.InsertOnSubmit(new DeviceGroupParam
                                //{
                                //    id_group = group.id,
                                //    id_type = type.id_type,
                                //    value = param.Value
                                //});
                            }
                            db.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            ok = false;
                            parameters.DeleteOnSubmit(insertedParam);
                            Log.Instance.Info(this, "Объект {0}. Ошибка внесения данных параметра {1}-{2}: {3}",
                                request.ClientId, param.Mnemonics, param.IdGroup, ex.Message);
                        }
                        if (ok) // вносим в список успешно залитых
                            resultList.Add(new Parameter
                                {
                                    IdGroup = param.IdGroup,
                                    Mnemonics = param.Mnemonics
                                }
                            );
                    }
                    #endregion
                    Log.Instance.Info(this, "Объект {0}. Данные параметров загружены. Общее количество {1}", request.ClientId, request.Parameters.Count);
                    
                    //db.SubmitChanges();

                });

                Log.Instance.Info(this, "Запрос StoreData был обработан. {0} мс", time);

                return new Package<ClientDataResponse>
                {
                    ErrorCode = ErrorEnum.None,
                    ProcessingTime = time,
                    Object = new ClientDataResponse
                    {
                        Saved = resultList
                    }
                };
            }
            catch (CoAdException mex)
            {
                Log.Instance.Warn(this, mex, "Ошибка в запросе StoreData: {0}", mex.Message);

                return new Package<ClientDataResponse>
                {
                    ErrorCode = mex.State,
                    ProcessingTime = time,
                };
            }
            catch (Exception ex)
            {
                Log.Instance.Warn(this, ex, "Ошибка в запросе StoreData: {0}", ex.Message);

                return new Package<ClientDataResponse>
                {
                    ErrorCode = ErrorEnum.Unknown,
                    ProcessingTime = time,
                    ErrorDescription = ex.Message,
                };
            }
        }
    }
}
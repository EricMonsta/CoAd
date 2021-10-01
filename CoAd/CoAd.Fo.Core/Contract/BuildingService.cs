using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.ServiceModel;
using CoAd.Fo.Core.Database;
using CoAd.Model;
using CoAd.Model.Entities;
using CoAd.Model.Entities.Requests;
using CoAd.Model.Enums;
using System.Threading;

namespace CoAd.Fo.Core.Contract
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class BuildingService : IService
    {
        public Package<UpdateStoreResponse> UpdateStore(UpdateStoreRequest request)
        {
            if (FoEngineModel.Instance.Configuration.CurrentConfig.Sleep != 0)
                Thread.Sleep(FoEngineModel.Instance.Configuration.CurrentConfig.Sleep);

            int time = 0;

            try
            {
                time = Watch.Instance.Time(() =>
                {
                    var db = new DataContext(FoEngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());

                    if (request.ClientId != FoEngineModel.Instance.Configuration.CurrentConfig.ClientId)
                        throw new CoAdException($"Объект {request.ClientId} не совпадает", ErrorEnum.InvalidObject);

                    // искомый магазин
                    var store = db.GetTable<Classif_depart>().FirstOrDefault(s => s.id_depart == request.Store.FoIdStore);

                    if (store == null)
                        throw new CoAdException($"Магазин id={request.Store.FoIdStore} не найден", ErrorEnum.InvalidObject);
                    
                    store.name_depart = request.Store.Name;
                    store.egais_prop = request.Store.EgaisProps;
                    store.ofd_prop = request.Store.OfdProps;
                    store.bpa_prop = request.Store.BpaProps;
                    
                    db.SubmitChanges();

                    Log.Instance.Info(this, "Объект {0}. Данные магазина обновлены", request.ClientId);

                });

                Log.Instance.Info(this, "Запрос UpdateStore был обработан. {0} мс", time);

                return new Package<UpdateStoreResponse>
                {
                    ErrorCode = ErrorEnum.None,
                    ProcessingTime = time,
                    Object = new UpdateStoreResponse()
                };
            }
            catch (CoAdException mex)
            {
                Log.Instance.Warn(this, mex, "Ошибка в запросе UpdateStore: {0}", mex.Message);

                return new Package<UpdateStoreResponse>
                {
                    ErrorCode = mex.State,
                    ProcessingTime = time,
                };
            }
            catch (Exception ex)
            {
                Log.Instance.Warn(this, ex, "Ошибка в запросе UpdateStore: {0}", ex.Message);

                return new Package<UpdateStoreResponse>
                {
                    ErrorCode = ErrorEnum.Unknown,
                    ProcessingTime = time,
                    ErrorDescription = ex.Message,
                };
            }
        }

        public Package<UpdateParametersResponse> UpdateParameters(UpdateParametersRequest request)
        {
            if (FoEngineModel.Instance.Configuration.CurrentConfig.Sleep != 0)
                Thread.Sleep(FoEngineModel.Instance.Configuration.CurrentConfig.Sleep);

            int time = 0;
            var resultList = new List<Parameter>();

            try
            {
                time = Watch.Instance.Time(() =>
                {
                    var db = new DataContext(FoEngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());

                    if (request.ClientId != FoEngineModel.Instance.Configuration.CurrentConfig.ClientId)
                        throw new CoAdException($"Объект {request.ClientId} не совпадает", ErrorEnum.InvalidObject);

                    var parameters = db.GetTable<Cash_param>();
                    var paramTypes = db.GetTable<Str_cash_param>();
                    // группа приходит фо-шная
                    var groups = db.GetTable<Group_device>();
                    foreach (var param in request.Parameters)
                    {
                        // ищем тип параметра
                        var type = paramTypes.FirstOrDefault(t => t.mnem_str_cash_param == param.Mnemonics);
                        if (type == null)
                        {
                            Log.Instance.Info(this, "Объект {0}. Параметр с мнемоникой {1} не найден", request.ClientId, param.Mnemonics);
                            continue;
                        }
                        // ищем идентификатор группы
                        var group = groups.FirstOrDefault(g => g.id_group_devices == param.IdGroup);
                        if (group == null)
                        {
                            Log.Instance.Info(this, "Объект {0}. Параметр с группой {1} не найден", request.ClientId, param.IdGroup);
                            continue;
                        }
                        var pm = parameters.FirstOrDefault(p => p.Str_cash_param.mnem_str_cash_param == param.Mnemonics && p.id_group_devices == group.id_group_devices);

                        bool ok = true;
                        var insertedParam = new Cash_param();
                        try
                        {
                            if (pm != null)
                            {
                                pm.value_blob = param.Value;
                                pm.state = 0;
                            }
                            else
                            {
                                insertedParam.id_group_devices = group.id_group_devices;
                                insertedParam.id_str_cash_param = type.id_str_cash_param;
                                insertedParam.value_blob = param.Value;
                                insertedParam.state = 0;

                                parameters.InsertOnSubmit(insertedParam);
                                //parameters.InsertOnSubmit(new Cash_param
                                //{
                                //    id_group_devices = group.id_group_devices,
                                //    id_str_cash_param = type.id_str_cash_param,
                                //    value_blob = param.Value,
                                //    state = 0
                                //});
                            }
                            db.SubmitChanges();
                        }
                        catch (Exception ex)
                        {
                            ok = false;
                            parameters.DeleteOnSubmit(insertedParam);
                            Log.Instance.Info(this, "Объект {0}. Ошибка добавления параметра: {1}", request.ClientId, ex.Message);
                        }
                        if (ok) // вносим в список успешно залитых
                            resultList.Add(new Parameter
                            {
                                IdGroup = param.IdGroup,
                                Mnemonics = param.Mnemonics
                            });
                    }
                    //db.SubmitChanges();

                    Log.Instance.Info(this, "Объект {0}. Параметры обновлены", request.ClientId);

                });

                Log.Instance.Info(this, "Запрос UpdateParameters был обработан. {0} мс", time);

                return new Package<UpdateParametersResponse>
                {
                    ErrorCode = ErrorEnum.None,
                    ProcessingTime = time,
                    Object = new UpdateParametersResponse
                    {
                        Saved = resultList
                    }
                };
            }
            catch (CoAdException mex)
            {
                Log.Instance.Warn(this, mex, "Ошибка в запросе UpdateParameters: {0}", mex.Message);

                return new Package<UpdateParametersResponse>
                {
                    ErrorCode = mex.State,
                    ProcessingTime = time,
                };
            }
            catch (Exception ex)
            {
                Log.Instance.Warn(this, ex, "Ошибка в запросе UpdateParameters: {0}", ex.Message);

                return new Package<UpdateParametersResponse>
                {
                    ErrorCode = ErrorEnum.Unknown,
                    ProcessingTime = time,
                    ErrorDescription = ex.Message,
                };
            }
        }
    }
}
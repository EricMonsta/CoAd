using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using CoAd.Core.Database;
using CoAd.Model;
using CoAd.Model.Entities;
using CoAd.Model.Entities.Requests;
using CoAd.Model.Enums;

namespace CoAd.Core.Environments
{
    public class EngineEnvironment : AbstractEnvironment
    {
        public override string FriendlyName
        {
            get { return "Engine"; }
        }

        protected override Action StartAction
        {
            get
            {
                return () =>
                {
                    Log.Instance.Info(this, "Внесение данных о магазинах с периодом {0} сек", EngineModel.Instance.Configuration.CurrentConfig.SendStorePeriod);

                    #region Монитор изменения данных магазина
                    var updateStoreMonitor = new Thread(() =>
                    {
                        do
                        {
                            var time = Watch.Instance.Time(() =>
                            {
                                var db = new DataContext(EngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());

                                // грузим все магазины в состоянии отредактировано
                                foreach (var store in db.GetTable<ClientStore>().Where(s=>s.state == 1))
                                {
                                    var request = new UpdateStoreRequest
                                    {
                                        Store = new Store
                                        {
                                            FoIdStore = store.fo_id_store,
                                            Name = store.name,
                                            EgaisProps = store.egais_props,
                                            OfdProps = store.ofd_props,
                                            BpaProps = store.bpa_props
                                        },

                                        ClientId = store.ClientServer.identifier
                                    };

                                    // получаем реквизиты
                                    var conf = ClientConfiguration.Deserialize(store.ClientServer.configuration);

                                    var sender = new Sender(conf.ClientEndpoint, EngineModel.Instance.Configuration.CurrentConfig.RequestTimeout);

                                    Log.Instance.Info(this, "Отправка данных о магазине {0}",store.ClientServer.identifier);

                                    var response = sender.FullSendV2<UpdateStoreRequest, UpdateStoreResponse>(request, @"/UpdateStore");

                                    if (response != null && response.ErrorCode == ErrorEnum.None)
                                    {
                                        Log.Instance.Info(this, "Данные о магазине {0} отправлены", store.ClientServer.identifier);

                                        // возможно за время отправки в данные были внесены изменения
                                        if (store.state == 1) store.state = 0;
                                        if (store.state == 2) store.state = 1;
                                        // выставляем дату обновления для устранения коллизий
                                        store.dateOfChange = DateTime.Now;
                                        db.SubmitChanges();
                                    }
                                    else Log.Instance.Info(this, "Не удалось отправить данные о магазине: {0}", response == null ? "ответ не получен" : response.ErrorDescription);

                                }

                            });
                            var sleep = EngineModel.Instance.Configuration.CurrentConfig.SendStorePeriod * 1000 - time;
                            Thread.Sleep(sleep >= 0 ? sleep : 0);

                        } while (IsActive);
                    });
                    if (EngineModel.Instance.Configuration.CurrentConfig.SendStorePeriod != 0) updateStoreMonitor.Start();
                    #endregion

                    #region Монитор изменения параметров
                    var updateParametersMonitor = new Thread(() =>
                    {
                        do
                        {
                            var time = Watch.Instance.Time(() =>
                            {
                                var db = new DataContext(EngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());

                                // 3 сценария: параметр в группе меняется, параметр в глобальной группе меняется, происходит связка группы с глобальной
                                // 1. параметр родной группы получает state = 1, или state = 2 если еще не ушел
                                // 2. параметр глобальной группы остается с состоянием 0, все параметры по связке получают =1 / =2 или добавляются
                                // 3  все параметры по связке получают =1 / =2 или добавляются

                                foreach (var server in db.GetTable<ClientServer>())
                                {
                                    //var groups = db.GetTable<ClientDeviceGroup>().Where(g => g.id_server == server.id);
                                    var parameters = new List<Parameter>();
                                    
                                    // не оптимально но легко
                                    foreach (var param in db.GetTable<DeviceGroupParam>().Where(p => p.state == 1 && p.ClientDeviceGroup.ClientServer.id == server.id))
                                    {
                                        parameters.Add(new Parameter
                                        {
                                            IdGroup = (int)param.ClientDeviceGroup.fo_id_group,
                                            Mnemonics = param.TypeParam.mnem_param,
                                            Value = param.value
                                        });
                                    }

                                    // формируем запрос
                                    var request = new UpdateParametersRequest
                                    {
                                        ClientId = server.identifier,
                                        Parameters = parameters
                                    };

                                    // получаем реквизиты
                                    var conf = ClientConfiguration.Deserialize(server.configuration);

                                    var sender = new Sender(conf.ClientEndpoint, EngineModel.Instance.Configuration.CurrentConfig.RequestTimeout);

                                    Log.Instance.Info(this, "Отправка данных параметров на клиента {0}", server.identifier);

                                    var response = sender.FullSendV2<UpdateParametersRequest, UpdateParametersResponse>(request, @"/UpdateParameters");

                                    if (response != null && response.ErrorCode == ErrorEnum.None)
                                    {
                                        foreach (var parameter in response.Object.Saved)
                                        {
                                            var p = db.GetTable<DeviceGroupParam>()
                                                .FirstOrDefault(cp => cp.TypeParam.mnem_param == parameter.Mnemonics &&
                                                                      cp.id_group == parameter.IdGroup);
                                            if (p != null)
                                            {
                                                // возможно за время отправки в данные были внесены изменения
                                                if (p.state == 1) p.state = 0;
                                                if (p.state == 2) p.state = 1;
                                                // выставляем дату обновления для устранения коллизий
                                                p.dateOfChange = DateTime.Now;
                                            }
                                            else Log.Instance.Info(this, "Параметр {0}-{1} не найден", parameter.Mnemonics, parameter.IdGroup);
                                        }

                                        db.SubmitChanges();

                                        Log.Instance.Info(this, "Параметры отправлены");
                                    }
                                    else Log.Instance.Info(this, "Не удалось отправить параметры на объект: {0}", response == null ? "ответ не получен" : response.ErrorDescription);

                                }
                                
                            });
                            var sleep = EngineModel.Instance.Configuration.CurrentConfig.SendStorePeriod * 1000 - time;
                            Thread.Sleep(sleep >= 0 ? sleep : 0);

                        } while (IsActive);
                    });
                    if (EngineModel.Instance.Configuration.CurrentConfig.SendParamsPeriod != 0) updateParametersMonitor.Start();
                    #endregion
                };
            }
        }

        protected override Action StopAction
        {
            get
            {
                return () =>
                {

                };
            }
        }
    }
}
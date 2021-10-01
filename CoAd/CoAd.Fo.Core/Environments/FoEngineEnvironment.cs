using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using CoAd.Fo.Core.Database;
using CoAd.Model;
using CoAd.Model.Entities;
using CoAd.Model.Entities.Requests;
using CoAd.Model.Enums;
using Device = CoAd.Model.Entities.Device;

namespace CoAd.Fo.Core.Environments
{
    public class FoEngineEnvironment : AbstractEnvironment
    {
        public override string FriendlyName
        {
            get { return "FoEngine"; }
        }

        protected override Action StartAction
        {
            get
            {
                return () =>
                {
                    Log.Instance.Info(this, "Отправка данных о магазине с периодом {0} сек", FoEngineModel.Instance.Configuration.CurrentConfig.UpdateTimeout);

                    #region отправка инфы о магазине, кассах, группах, параметрах
                    var storeDataMonitor = new Thread(() =>
                    {
                        do
                        {
                            var time = Watch.Instance.Time(() =>
                            {
                                Log.Instance.Info(this, "Загрузка данных из БД...");

                                var db = new DataContext(FoEngineModel.Instance.Configuration.CurrentConfig.GetConnectionString());

                                // места хранения - полный импорт
                                var stores = new List<Store>();
                                foreach (var store in db.GetTable<Classif_depart>())
                                {
                                    stores.Add(new Store
                                    {
                                        FoIdStore = store.id_depart,
                                        Name = store.name_depart,
                                        EgaisProps = store.egais_prop,
                                        OfdProps = store.ofd_prop,
                                        BpaProps = store.bpa_prop
                                    });
                                }
                                Log.Instance.Info(this, "Данные по магазинам получены. Общее количество {0}", stores.Count);

                                // группы касс - полный импорт
                                var groups = new List<DeviceGroup>();
                                foreach (var group in db.GetTable<Group_device>())
                                {
                                    groups.Add(new DeviceGroup
                                    {
                                        FoIdGroup = group.id_group_devices,
                                        Name = group.Name_group_devices
                                    });
                                }
                                Log.Instance.Info(this, "Данные по группам касс получены. Общее количество {0}", groups.Count);

                                // устройства - полный импорт
                                var devices = new List<Device>();
                                var serializer = new XmlSerializer(typeof(DeviceSettings));
                                foreach (var device in db.GetTable<Database.Device>())
                                {
                                    string xml;
                                    using (var swr = new StringWriter())
                                    {
                                        serializer.Serialize(swr, new DeviceSettings
                                        {
                                            Server = device.host_device,
                                            Database = device.name_db,
                                            Password = device.password,
                                            User = device.user_name
                                        });
                                        xml = swr.ToString();
                                    }

                                    devices.Add(new Device
                                    {
                                        FoIdDevice = device.id_device,
                                        Type = device.id_type_device ?? 0,
                                        IdDeviceGroup = device.id_group_devices,
                                        Name = device.name_device,
                                        Status = device.state_device ?? -1,
                                        Data = "",
                                        Settings = xml
                                    });
                                }
                                Log.Instance.Info(this, "Данные по устройствам получены. Общее количество {0}", devices.Count);

                                // параметры - частичный импорт
                                var sw = new Stopwatch();
                                sw.Start();
                                var parameters = new List<Parameter>();
                                foreach (var param in db.GetTable<Cash_param>().Where(p => p.state == 1))
                                {
                                    parameters.Add(new Parameter
                                    {
                                        Mnemonics = param.Str_cash_param.mnem_str_cash_param,
                                        IdGroup = param.id_group_devices,
                                        Value = param.value_blob ?? param.value_param
                                    });
                                }
                                Log.Instance.Info(this, "Данные по параметрам получены. Общее количество {0}", parameters.Count);

                                var request = new ClientDataRequest
                                {
                                    Stores = stores,
                                    Groups = groups,
                                    Devices = devices,
                                    Parameters = parameters,
                                    ClientId = FoEngineModel.Instance.Configuration.CurrentConfig.ClientId,
                                    Delay = (int)sw.ElapsedMilliseconds / 1000 + FoEngineModel.Instance.Configuration.CurrentConfig.RequestTimeout + 3
                                };

                                var sender = new Sender(FoEngineModel.Instance.Configuration.CurrentConfig.ServiceEndpoint, FoEngineModel.Instance.Configuration.CurrentConfig.RequestTimeout);
                                Log.Instance.Info(this, "Отправка данных о магазине");
                                
                                var response = sender.FullSendV2<ClientDataRequest, ClientDataResponse>(request, @"/StoreData");

                                if (response != null && response.ErrorCode == ErrorEnum.None)
                                {
                                    // помечаем отправленные параметры
                                    foreach (var parameter in response.Object.Saved)
                                    {
                                        var p = db.GetTable<Cash_param>()
                                            .FirstOrDefault(cp => cp.Str_cash_param.mnem_str_cash_param == parameter.Mnemonics &&
                                                         cp.id_group_devices == parameter.IdGroup);
                                        if (p != null)
                                        {
                                            if (p.state == 1) p.state = 0;
                                            if (p.state == 2) p.state = 1;
                                        }
                                        else Log.Instance.Info(this, "Параметр {0}-{1} не найден",parameter.Mnemonics, parameter.IdGroup);
                                    }

                                    db.SubmitChanges();

                                    Log.Instance.Info(this, "Данные о магазине отправлены");
                                }
                                else Log.Instance.Info(this, "Не удалось отправить данные о магазине: {0}", response == null ? "ответ не получен" : response.ErrorDescription);

                            });
                            var sleep = FoEngineModel.Instance.Configuration.CurrentConfig.UpdateTimeout * 1000 - time;
                            Thread.Sleep(sleep >= 0 ? sleep : 0);

                        } while (IsActive);
                    });
                    if (FoEngineModel.Instance.Configuration.CurrentConfig.UpdateTimeout != 0) storeDataMonitor.Start();
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
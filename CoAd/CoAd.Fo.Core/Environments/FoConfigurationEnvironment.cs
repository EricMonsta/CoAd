using System;
using System.IO;
using System.Threading;
using CoAd.Model;

namespace CoAd.Fo.Core.Environments
{
    public class FoConfigurationEnvironment : AbstractEnvironment
    {
        public override string FriendlyName
        {
            get { return "FoConfiguration"; }
        }

        protected string ConfigFileName = @"FoCoAd.cfg";

        protected string ConfigFilePath { get { return Path.Combine(FoEngineModel.CurrentDirectory, ConfigFileName); } }

        public Configurator<FoEngineConfiguration> CHandler { get; protected set; }

        public FoEngineConfiguration CurrentConfig { get; protected set; }

        protected override Action StartAction
        {
            get
            {
                return () =>
                {
                    if (CHandler == null)
                    {
                        CHandler = new Configurator<FoEngineConfiguration> { ObjectPath = ConfigFilePath };
                    }

                    if (File.Exists(ConfigFilePath))
                    {
                        CHandler.Load();
                        CurrentConfig = CHandler.Object;
                    }
                    else
                    {
                        CurrentConfig = CHandler.Object = FoEngineConfiguration.Default;
                        CHandler.Save();
                    }

                    // монитор конфига 5 минут
                    var monitor = new Thread(() =>
                    {
                        Thread.Sleep(300 * 1000);
                        while (IsActive)
                        {
                            Thread.Sleep(300 * 1000 - Watch.Instance.Time(() =>
                            {
                                Log.Instance.Info(this, "Обновление конфигурации клиента");
                                CurrentConfig = CHandler.Load();
                            }));
                        }
                    });
                    monitor.Start();
                };
            }
        }

        protected override Action StopAction
        {
            get
            {
                return () =>
                {
                    CHandler = null;
                };
            }
        }
    }
}
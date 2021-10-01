using System;
using System.IO;
using System.Threading;
using CoAd.Model;

namespace CoAd.Core.Environments
{
    public class ConfigurationEnvironment : AbstractEnvironment
    {
        public override string FriendlyName
        {
            get { return "Configuration"; }
        }

        protected string ConfigFileName = @"CoAd.cfg";

        protected string ConfigFilePath { get { return Path.Combine(EngineModel.CurrentDirectory, ConfigFileName); } }

        public Configurator<EngineConfiguration> CHandler { get; protected set; }

        public EngineConfiguration CurrentConfig { get; protected set; }

        protected override Action StartAction
        {
            get
            {
                return () =>
                {
                    if (CHandler == null)
                    {
                        CHandler = new Configurator<EngineConfiguration> { ObjectPath = ConfigFilePath };
                    }

                    if (File.Exists(ConfigFilePath))
                    {
                        CHandler.Load();
                        CurrentConfig = CHandler.Object;
                    }
                    else
                    {
                        CurrentConfig = CHandler.Object = EngineConfiguration.Default;
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
                                Log.Instance.Info(this, "Обновление конфигурации сервера");
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
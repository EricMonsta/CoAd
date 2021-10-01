using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CoAd.Core.Environments;
using CoAd.Model;
using CoAd.Model.Enums;
using CoAd.Model.EventArgs;
using CoAd.Model.Interfaces;

namespace CoAd.Core
{
    public sealed class EngineModel : IStartable
    {
        private static readonly object Sync = new object();

        private static volatile EngineModel _instance;

        public static EngineModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new EngineModel();
                        }
                    }
                }

                return _instance;
            }
        }

        public EngineModel()
        {
            Status = StatusEnum.Stopped;
        }

        public StatusEnum Status { get; set; }

        public static string CurrentDirectory
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public int ModelTimeStart { get; protected set; }

        public int ModelTimeStop { get; protected set; }

        public int ModelTimeRestart
        {
            get { return ModelTimeStart + ModelTimeStop; }
        }

        public event EventHandler<ExternalEventArgs> FeedBack;
        public event EventHandler<ExceptionEventArgs> ExceptionBack;

        public void ToFeedBack(ExternalEventArgs e)
        {
            if (e != null && FeedBack != null) FeedBack(this, e);
        }

        public void ToExceptionBack(ExceptionEventArgs e)
        {
            if (e != null && ExceptionBack != null) ExceptionBack(this, e);
        }

        /// <summary>
        /// Окружения ядра модели
        /// </summary>
        public List<AbstractEnvironment> Environments { get; protected set; }

        /// <summary>
        /// Конфигуратор
        /// </summary>
        public ConfigurationEnvironment Configuration
        {
            get { return Environments != null ? Environments.FirstOrDefault(x => x is ConfigurationEnvironment) as ConfigurationEnvironment : null; }
        }

        /// <summary>
        /// Контракт WCF
        /// </summary>
        public ServiceEnvironment Contract
        {
            get { return Environments != null ? Environments.FirstOrDefault(x => x is ServiceEnvironment) as ServiceEnvironment : null; }
        }

        /// <summary>
        /// Выполнятор
        /// </summary>
        public EngineEnvironment Engine
        {
            get { return Environments != null ? Environments.FirstOrDefault(x => x is EngineEnvironment) as EngineEnvironment : null; }
        }

        /// <summary>
        /// Инициализация основных элементов окружения
        /// </summary>
        public void InitEnvironments()
        {
            Environments.Add(new ConfigurationEnvironment());
            Environments.Add(new EngineEnvironment());
            Environments.Add(new ServiceEnvironment());
        }

        public void Start()
        {
            Log.Instance.Info(this, string.Empty);
            Log.Instance.Info(this, ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Log.Instance.Info(this, "Запускается ...");

            FeedBack += EngineModelFeedBack;
            ExceptionBack += EngineModelExceptionBack;

            lock (Sync)
            {
                ModelTimeStart = Watch.Instance.Time(() =>
                {
                    if (Status == StatusEnum.Stopped)
                    {
                        ToFeedBack(new ExternalEventArgs("ConfiguratorModel starting ..."));

                        try
                        {
                            ToFeedBack(new ExternalEventArgs("Environment starting ..."));

                            Environments = new List<AbstractEnvironment>();

                            InitEnvironments();

                            foreach (var environment in Environments)
                            {
                                environment.Start();

                                ToFeedBack(new ExternalEventArgs(string.Format("Environment \"{0}\" has been started", environment.FriendlyName)));
                            }
                        }
                        catch (Exception ex)
                        {
                            ToExceptionBack(new ExceptionEventArgs(ex, "Fatal Application Error. The application can not continue its work, contact the experts"));

                            Status = StatusEnum.Stopped;

                            return;
                        }

                        Status = StatusEnum.Started;

                        ToFeedBack(new ExternalEventArgs("Application has been started"));
                    }
                    else
                    {
                        ToFeedBack(new ExternalEventArgs("ConfiguratorModel is already running"));
                    }
                });
            }
        }

        public void Stop()
        {
            Log.Instance.Info(this, string.Empty);
            Log.Instance.Info(this, "<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            Log.Instance.Info(this, "Останавливается ...");

            FeedBack -= EngineModelFeedBack;
            ExceptionBack -= EngineModelExceptionBack;

            lock (Sync)
            {
                ModelTimeStop = Watch.Instance.Time(() =>
                {
                    if (Status == StatusEnum.Started)
                    {
                        ToFeedBack(new ExternalEventArgs("ConfiguratorModel stopping ..."));

                        try
                        {
                            if (Environments != null && Environments.Count > 0)
                            {
                                ToFeedBack(new ExternalEventArgs("Environment stopping ..."));

                                foreach (var environment in Environments)
                                {
                                    environment.Stop();

                                    ToFeedBack(new ExternalEventArgs(string.Format("Environment \"{0}\" has been started", environment.FriendlyName)));
                                }

                                Environments.Clear();
                                Environments = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            ToExceptionBack(new ExceptionEventArgs(ex, "Fatal Application Error. The application can not continue its work, contact the experts"));
                        }

                        Status = StatusEnum.Stopped;

                        ToFeedBack(new ExternalEventArgs("Application has been stopped"));
                    }
                    else
                    {
                        ToFeedBack(new ExternalEventArgs("ConfiguratorModel has been stopped already"));
                    }
                });
            }
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        private void EngineModelFeedBack(object sender, ExternalEventArgs e)
        {
            Log.Instance.Info(this, e.Information, e.Arguments);
        }

        void EngineModelExceptionBack(object sender, ExceptionEventArgs e)
        {
            Log.Instance.Warn(this, e.Ex, e.Information, e.Arguments);
        }

        //public Session Session { get; set; }
    }
}
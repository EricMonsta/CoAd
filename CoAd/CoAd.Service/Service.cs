using System.ServiceProcess;
using CoAd.Core;

namespace CoAd.Service
{
    public partial class Service : ServiceBase
    {
        protected EngineModel Model;

        public Service()
        {
            InitializeComponent();

            Model = EngineModel.Instance;
        }

        protected override void OnStart(string[] args)
        {
            Model.Start();
        }

        protected override void OnStop()
        {
            Model.Stop();
        }
    }
}

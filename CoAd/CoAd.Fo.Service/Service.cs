using System.ServiceProcess;
using CoAd.Fo.Core;

namespace CoAd.Fo.Service
{
    public partial class Service : ServiceBase
    {
        protected FoEngineModel Model;

        public Service()
        {
            InitializeComponent();

            Model = FoEngineModel.Instance;
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

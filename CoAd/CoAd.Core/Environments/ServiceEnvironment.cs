using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using CoAd.Core.Contract;
using CoAd.Model;

namespace CoAd.Core.Environments
{
    public class ServiceEnvironment : AbstractEnvironment
    {
        public ServiceHost Host { get; protected set; }

        public override string FriendlyName
        {
            get { return "Contract"; }
        }

        protected override Action StartAction
        {
            get
            {
                return () =>
                {
                    // endpoint
                    var uri = new Uri(String.Format("http://{0}/Service/", EngineModel.Instance.Configuration.CurrentConfig.Endpoint));

                    // contract
                    var contract = new BuildingService();

                    if (Host == null)
                    {
                        // webservice host
                        Host = new WebServiceHost(contract, uri);

                        var webBinding = GetBinding();
                        Host.AddServiceEndpoint(typeof(IService), webBinding, "");
                    }

                    Host.Open();

                    Log.Instance.Info(this, "Contract start on: {0}", Host.BaseAddresses[0].ToString());
                };
            }
        }

        /// <summary>
        /// Binding
        /// </summary>
        /// <returns></returns>
        private WebHttpBinding GetBinding()
        {
            var webHttpBinding = new WebHttpBinding(WebHttpSecurityMode.None)
            {
                MaxReceivedMessageSize = 10485760,
                MaxBufferPoolSize = 10485760,
                MaxBufferSize = 10485760,
                CloseTimeout = new TimeSpan(0, 3, 0),
                OpenTimeout = new TimeSpan(0, 3, 0),
                ReceiveTimeout = new TimeSpan(0, 0, 10),
                SendTimeout = new TimeSpan(0, 3, 0),
                ReaderQuotas = new XmlDictionaryReaderQuotas
                {
                    MaxDepth = 32,
                    MaxStringContentLength = 10485760,
                    MaxArrayLength = 10485760,
                    MaxBytesPerRead = 10485760
                }
            };

            return webHttpBinding;
        }

        protected override Action StopAction
        {
            get
            {
                return () =>
                {
                    if (Host != null) Host.Close();
                };
            }
        }

    }
}
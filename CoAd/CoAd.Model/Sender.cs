using System;
using System.Threading;
using CoAd.Model.Entities.Requests;
using RestSharp;

namespace CoAd.Model
{
    public class Sender
    {
        private readonly string _endpoint;
        private readonly int _timeout;

        public Sender()
        {
            //_endpoint = PosEngineModel.Instance.Configuration.CurrentConfig.ServiceEndpoint;
            //_timeout = PosEngineModel.Instance.Configuration.CurrentConfig.RequestTimeout;
        }

        public Sender(string endpoint, int timeout)
        {
            _endpoint = endpoint;
            _timeout = timeout;
        }

        public T Send<T>(T input, string method) where T : Request
        {
            try
            {
                var client = new RestClient(String.Format("http://{0}/Service", _endpoint));

                IRestResponse<Package<T>> output = null;

                var request = new RestRequest(method, Method.POST) { RequestFormat = DataFormat.Json, };

                request.AddBody(new Package<T>
                {
                    Object = input
                });

                var waiting = true;

                var async = client.ExecuteAsync<Package<T>>(request, response =>
                {
                    output = response;
                    waiting = false;
                });

                var start = DateTime.Now;

                while (start.AddMilliseconds(_timeout * 1000) > DateTime.Now && waiting)
                {
                    Thread.Sleep(10);
                }

                if (waiting)
                {
                    async.Abort();
                    throw new TimeoutException("Превышено время ожидания ответа от сервера");
                }

                if (output == null || output.Data == null)
                {
                    throw new Exception("Не были получены данные от сервера");
                }

                if (output.Data.Object != null)
                {
                    return output.Data.Object;
                }
            }

            catch (Exception ex)
            {
                Log.Instance.Warn(new Sender(), ex);
            }

            return null;
        }

        public Package<T2> FullSendV2<T1, T2>(T1 input, string method) where T1 : class where T2 : class
        {
            try
            {
                var client = new RestClient(String.Format("http://{0}/Service", _endpoint));

                IRestResponse<Package<T2>> output = null;

                var request = new RestRequest(method, Method.POST) { RequestFormat = DataFormat.Json, };

                request.AddBody(input);

                var waiting = true;

                var async = client.ExecuteAsync<Package<T2>>(request, response =>
                {
                    output = response;
                    waiting = false;
                });

                var start = DateTime.Now;

                while (start.AddMilliseconds(_timeout * 1000) > DateTime.Now && waiting)
                {
                    Thread.Sleep(10);
                }

                if (waiting)
                {
                    async.Abort();
                    throw new TimeoutException("Превышено время ожидания ответа от сервера");
                }

                if (output == null || output.Data == null)
                {
                    throw new Exception("Не были получены данные от сервера");
                }

                if (output.Data.Object != null)
                {
                    return output.Data;
                }
            }

            catch (Exception ex)
            {
                Log.Instance.Warn(new Sender(), ex);
            }

            return null;
        }

    }
}
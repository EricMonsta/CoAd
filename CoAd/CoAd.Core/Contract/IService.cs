using System.ServiceModel;
using System.ServiceModel.Web;
using CoAd.Model;
using CoAd.Model.Entities.Requests;

namespace CoAd.Core.Contract
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/StoreData", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Package<ClientDataResponse> StoreData(ClientDataRequest request);
    }
}
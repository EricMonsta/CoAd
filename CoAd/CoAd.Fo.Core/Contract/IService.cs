using System.ServiceModel;
using System.ServiceModel.Web;
using CoAd.Model;
using CoAd.Model.Entities.Requests;

namespace CoAd.Fo.Core.Contract
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateStore", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Package<UpdateStoreResponse> UpdateStore(UpdateStoreRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/UpdateParameters", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Package<UpdateParametersResponse> UpdateParameters(UpdateParametersRequest request);
    }
}
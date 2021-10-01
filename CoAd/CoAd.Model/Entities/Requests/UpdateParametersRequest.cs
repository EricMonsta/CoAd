using System.Collections.Generic;

namespace CoAd.Model.Entities.Requests
{
    public class UpdateParametersRequest
    {
        public UpdateParametersRequest()
        {
            Parameters = new List<Parameter>();
        }

        public List<Parameter> Parameters { get; set; }

        public string ClientId { get; set; }
    }
}
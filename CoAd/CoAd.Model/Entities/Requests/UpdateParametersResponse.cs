using System.Collections.Generic;

namespace CoAd.Model.Entities.Requests
{
    public class UpdateParametersResponse
    {
        public UpdateParametersResponse()
        {
            Saved = new List<Parameter>();
        }

        public List<Parameter> Saved { get; set; }
    }
}
using System.Collections.Generic;

namespace CoAd.Model.Entities.Requests
{
    public class ClientDataResponse
    {
        public ClientDataResponse()
        {
            Saved = new List<Parameter>();
        }

        public List<Parameter> Saved { get; set; }
    }
}
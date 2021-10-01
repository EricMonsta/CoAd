using System.Collections.Generic;

namespace CoAd.Model.Entities.Requests
{
    /// <summary>
    /// запрос на сервер со структурой клиента 
    /// </summary>
    public class ClientDataRequest
    {
        public ClientDataRequest()
        {
            Stores = new List<Store>();
            Groups = new List<DeviceGroup>();
            Devices = new List<Device>();
            Parameters = new List<Parameter>();
        }
        
        /// <summary>
        /// идентификатор клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// максимальная задержка запроса от момента старта монитора
        /// </summary>
        public int Delay { get; set; }

        public List<Store> Stores { get; set; }

        public List<DeviceGroup> Groups { get; set; }

        public List<Device> Devices { get; set; }

        public List<Parameter> Parameters { get; set; }
    }
}
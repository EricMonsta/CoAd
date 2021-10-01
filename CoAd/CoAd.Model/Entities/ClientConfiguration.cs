using System.IO;
using System.Xml.Serialization;

namespace CoAd.Model.Entities
{
    public class ClientConfiguration
    {
        // ip:port
        public string ClientEndpoint { get; set; }

        public static ClientConfiguration Deserialize(string data)
        {
            var serializer = new XmlSerializer(typeof(ClientConfiguration));

            using (TextReader reader = new StringReader(data))
            {
                return (ClientConfiguration)serializer.Deserialize(reader);
            }
        }

    }
}
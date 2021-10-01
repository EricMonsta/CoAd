using System;
using System.IO;
using System.Xml.Serialization;

namespace CoAd.Model
{
    public class Configurator<T>
    {
        public Exception LastException { get; private set; }

        public T Object { get; set; }

        public string ObjectPath { get; set; }

        public T Load(string path)
        {
            ObjectPath = path;

            return Load();
        }

        public T Load()
        {
            LastException = null;

            try
            {
                if (!File.Exists(ObjectPath)) return default(T);

                using (var fs = File.Open(ObjectPath, FileMode.Open))
                {
                    var xs = new XmlSerializer(typeof(T));
                    Object = (T)xs.Deserialize(fs);
                    fs.Close();
                }

                return Object;
            }
            catch (Exception ex)
            {
                LastException = ex;

                return default(T);
            }
        }

        public void Save()
        {
            using (var fs = File.Open(ObjectPath, FileMode.Create))
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(fs, Object);
                fs.Close();
            }
        }
    }
}
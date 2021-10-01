using System.Data.SqlClient;
using System.Xml.Serialization;

namespace CoAd.Fo.Core
{
    public class FoEngineConfiguration
    {
        /// <summary>
        /// настройки подключения к БД
        /// </summary>
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }

        /// <summary>
        /// хост:порт
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// хост:порт сервера
        /// </summary>
        public string ServiceEndpoint { get; set; }

        /// <summary>
        /// таймаут запроса, с
        /// </summary>
        public int RequestTimeout { get; set; }

        /// <summary>
        /// таймаут запроса основных данных
        /// </summary>
        public int UpdateTimeout { get; set; }

        /// <summary>
        /// идентификатор клиента
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// задержка в обработке запроса, мс
        /// </summary>
        public int Sleep { get; set; }

        private SqlConnectionStringBuilder _connection;
        [XmlIgnore]
        public SqlConnectionStringBuilder Connection
        {
            get
            {
                return _connection ?? (_connection = new SqlConnectionStringBuilder
                {
                    DataSource = Server,
                    InitialCatalog = Database,
                    UserID = User,
                    Password = Password,
                    ConnectTimeout = Timeout,
                });
            }
        }

        public string GetConnectionString()
        {
            return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", Server, Database, User, Password);
        }

        public static FoEngineConfiguration Default
        {
            get
            {
                return new FoEngineConfiguration
                {
                    Server = @"192.168.1.66\sqlexpress",
                    Database = "frontdk_stand_test",
                    User = "sa",
                    Password = "mssql",
                    Timeout = 30,
                    Endpoint = "192.168.1.66:30001",
                    ServiceEndpoint = "192.168.1.66:30002",
                    RequestTimeout = 20,
                    UpdateTimeout = 300,
                    ClientId = "320",
                    Sleep = 0
                };
            }
        }
    }
}
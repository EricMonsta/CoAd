using System.Data.SqlClient;
using System.Xml.Serialization;

namespace CoAd.Core
{
    /// <summary>
    /// Объект конфигурации
    /// </summary>
    public class EngineConfiguration
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
        /// таймаут запроса, с
        /// </summary>
        public int RequestTimeout { get; set; }

        /// <summary>
        /// период отправки данных о магазинах
        /// </summary>
        public int SendStorePeriod { get; set; }

        /// <summary>
        /// период отправки параметров
        /// </summary>
        public int SendParamsPeriod { get; set; }

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

        public static EngineConfiguration Default
        {
            get
            {
                return new EngineConfiguration
                {
                    Server = @"192.168.1.66\sqlexpress",
                    Database = "CoAd",
                    User = "sa",
                    Password = "mssql",
                    Timeout = 30,
                    Endpoint = "192.168.1.66:30002",
                    RequestTimeout = 20,
                    SendStorePeriod = 60,
                    SendParamsPeriod = 60,
                    Sleep = 0
                    
                };
            }
        }
    }
}
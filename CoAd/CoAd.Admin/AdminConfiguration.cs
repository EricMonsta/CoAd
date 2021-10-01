using System.Data.SqlClient;
using System.Xml.Serialization;

namespace CoAd.Admin
{
    public class AdminConfiguration
    {
        /// <summary>
        /// настройки подключения к БД
        /// </summary>
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }

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
            return $"Data Source={Server};Initial Catalog={Database};Persist Security Info=True;User ID={User};Password={Password}";
        }

        public static AdminConfiguration Default
        {
            get
            {
                return new AdminConfiguration
                {
                    Server = @"192.168.1.66\sqlexpress",
                    Database = "CoAd_test",
                    User = "sa",
                    Password = "mssql",
                    Timeout = 30,
                };
            }
        }
    }
}
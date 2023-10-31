using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class BaseRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;
        public List<SqlParameter> parameters;
        private string _pcName = ConfigurationManager.AppSettings.Get("pcName");
        private static Configuration  configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;
        public BaseRepository()
        {
            connection = new SqlConnection($"Data Source=localhost\\SqlExpress;Initial Catalog=epcdocmandb_igps; MultipleActiveResultSets=true;Uid=epcdocman;Pwd=just4us;");

        }
        protected string ConcatStringFromList(List<string> listOfString)
        {
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }

        public void Connect()
        {
            try
            {
                this.connection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  void Disconnect()
        {
            if (connection == null) return;

            if(connection.State == System.Data.ConnectionState.Open) 
            {
                this.connection.Close();
            }

        }

        public async Task ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);

            reader = await command.ExecuteReaderAsync(); 
        }
    }
}

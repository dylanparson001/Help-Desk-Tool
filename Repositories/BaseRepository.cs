using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


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

        public void Disconnect()
        {
            if (connection == null) return;

            if(connection.State == System.Data.ConnectionState.Open) 
            {
                this.connection.Close();
            }

        }

        public void ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            if (parameters != null)
            {
                if (parameters.Count > 0)
                {
                    parameters.AddRange(parameters.ToArray());
                }
            }
            reader = command.ExecuteReader(); 
        }
    }
}

using iGPS_Help_Desk.Views;
using Serilog;
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
        public SqlConnection connection = new SqlConnection();
        public SqlCommand command;
        public SqlDataReader reader;
        public List<SqlParameter> parameters;
        private string _pcName = ConfigurationManager.AppSettings.Get("pcName");
        private static Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        private static KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;
        public readonly ILogger _logger = Log.ForContext<Igps>();
        public BaseRepository()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
        }

        public string ConcatStringFromList(List<string> listOfString)
        {
            return string.Join(",", listOfString.Select(i => $"'{i}'"));
        }

        public void Connect()
        {
            try
            {
               connection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Disconnect()
        {

            if(connection.State == System.Data.ConnectionState.Open) 
            {
                connection.Close();
            }

        }

        public async Task ExecuteQuery(string query, SqlConnection conn)
        {
            SqlCommand command = new SqlCommand(query, conn);

            reader = await command.ExecuteReaderAsync(); 
        }
    }
}

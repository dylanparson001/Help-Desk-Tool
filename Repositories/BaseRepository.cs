using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Views;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
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

        public string GetSiteID()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            string result = "";
            string query = "SELECT LOOKUP_VALUE FROM VALUE_LOOKUP WHERE LOOKUP_ID = 231";
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                     sqlConnection.OpenAsync();

                    var command = new SqlCommand(query, sqlConnection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            var siteId = reader[0].ToString();

                            if (string.IsNullOrEmpty(siteId))
                            {
                                break;
                            }
                            result = siteId;
                        }

                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }


            return result;


        }
    }
}


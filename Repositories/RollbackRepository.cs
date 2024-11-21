using iGPS_Help_Desk.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Repositories
{
    public class RollbackRepository : BaseRepository
    {
        public async Task<string> GetTrailerNumber(string orderId)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            string result = string.Empty;

            string query = $"SELECT User7 FROM OrderRequestNew_Header WHERE OrderId = '{orderId}'";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();
                } 
                catch(Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                SqlCommand command = new SqlCommand (query, conn);
                reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader["User7"].ToString();
                    }
                }
                conn.Close();
            }
            return result;

        }
        public async Task<string> GetSealNumber(string orderId)
        {
            string result = string.Empty;

            string query = $"SELECT User8 FROM OrderRequestNew_Header WHERE OrderId = '{orderId}'";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                SqlCommand command = new SqlCommand (query, conn);
                reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader["User8"].ToString();
                    }
                }
                conn.Close();
            }
            return result;

        }
    }
}

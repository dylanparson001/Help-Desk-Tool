using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Repositories
{
    public class OrderRequestNewHeaderRepository : BaseRepository
    {
        public async Task<List<OrderRequestNewHeader>> GetOrdersFromList(List<string> bols)
        {

            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<OrderRequestNewHeader> result = new List<OrderRequestNewHeader>();
            string query = $"SELECT *" +
                $" FROM OrderRequestNew_Header WHERE BolId IN " +
                $"({string.Join(",", bols.Select((_, index) => $"@param{index}"))})";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();


                    SqlCommand command = new SqlCommand(query, conn);

                    for (int i = 0; i < bols.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", bols[i]);
                    }

                    reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var bolsFromDb = new OrderRequestNewHeader(reader);
                            result.Add(bolsFromDb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    MessageBox.Show(ex.ToString());
                }
                conn.Close();
            }
            return result;

        }
        public async Task RemoveOrders(List<string> orderIds)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string query = $"UPDATE OrderRequestNew_Header" +
                $" SET PROCESSING_STATUS = 'CANCELLED' " +
                $"WHERE OrderId IN ({string.Join(",", orderIds.Select((_, index) => $"@param{index}"))})";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();


                    SqlCommand command = new SqlCommand(query, conn);

                    for (int i = 0; i < orderIds.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", orderIds[i]);
                    }

                    reader = await command.ExecuteReaderAsync();

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public async Task UpdateRequestedQuantity(int newQuantity, List<string> orderIds)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string query = $"UPDATE OrderRequestNew_Header" +
                $" SET RequestedQuantity = @NewQuantity " +
                $"WHERE OrderId IN ({string.Join(",", orderIds.Select((_, index) => $"@param{index}"))})";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();


                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    for (int i = 0; i < orderIds.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", orderIds[i]);
                    }

                    reader = await command.ExecuteReaderAsync();

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
    }
}

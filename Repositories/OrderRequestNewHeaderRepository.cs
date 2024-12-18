﻿using iGPS_Help_Desk.Models;
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
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                SqlCommand command = new SqlCommand(query, conn);
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
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
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

                SqlCommand command = new SqlCommand(query, conn);
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

        public async Task Rollback(string orderId, string gln)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            string insertQuery = "INSERT INTO IGPS_DEPOT_GLN ([GLN], [GRAI], [DATE_TIME]) " +
                                 "SELECT @GLN, AssetId, GETUTCDATE() " +
                                 "FROM dbo.orderrequestprocessed_detail WHERE OrderId = @OrderId;";

            string updateQuery = "UPDATE orderrequestNew_Header " +
                                 "SET Processing_Status = 'CANCELLED' " +
                                 "WHERE OrderId = @OrderId;";

            string deleteQuery = "DELETE FROM orderrequestprocessed_detail WHERE OrderId = @OrderId;";


            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    // Insert
                    using (var insertCommand = new SqlCommand(insertQuery, conn))
                    {
                        insertCommand.Parameters.AddWithValue("@OrderId", orderId);
                        insertCommand.Parameters.AddWithValue("@GLN", gln);
                        await insertCommand.ExecuteNonQueryAsync();
                    }

                    // Update
                    using (var updateCommand = new SqlCommand(updateQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@OrderId", orderId);
                        await updateCommand.ExecuteNonQueryAsync();
                    }

                    // Delete
                    using (var deleteCommand = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCommand.Parameters.AddWithValue("@OrderId", orderId);
                        await deleteCommand.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    throw;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
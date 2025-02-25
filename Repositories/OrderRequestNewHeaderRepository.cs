using iGPS_Help_Desk.Enums;
using iGPS_Help_Desk.Interfaces;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace iGPS_Help_Desk.Repositories
{
    public class OrderRequestNewHeaderRepository : BaseRepository, IOrderRequestNewHeaderRepository
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
                }
                finally
                {

                    conn.Close();
                }
            }
            return result;

        }
        public async Task SetOrderStatus(List<string> orderIds, OrderStatus newStatus)
        {
            string query = string.Empty;

            switch (newStatus)
            {
                case OrderStatus.Cancelled:
                    query = $"UPDATE OrderRequestNew_Header" +
                        $" SET PROCESSING_STATUS = 'CANCELLED' " +
                        $"WHERE OrderId IN ({string.Join(",", orderIds.Select((_, index) => $"@param{index}"))})";

                    break;
                case OrderStatus.Open:
                    query = $"UPDATE OrderRequestNew_Header" +
                        $" SET PROCESSING_STATUS = NULL " +
                        $"WHERE OrderId IN ({string.Join(",", orderIds.Select((_, index) => $"@param{index}"))})";

                    break;
            }

            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }


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

        public async Task<bool> RollbackInsertGrais(string orderId, string gln)
        {
            bool isSuccess = true;

            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string insertQuery = "INSERT INTO IGPS_DEPOT_GLN ([GLN], [GRAI], [DATE_TIME]) " +
                     "SELECT @GLN, AssetId, GETUTCDATE() " +
                     "FROM dbo.OrderRequestProcessed_Detail WHERE OrderId = @OrderId;";
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
                    isSuccess = true;
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    isSuccess = false;
                    throw;
                }
                catch (Exception ex)
                {
                    isSuccess = false;
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
                return isSuccess;
            }
        }
        public async Task<bool> RollbackUpdateProcessingStatus(string orderId)
        {
            bool isSuccess = false;
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string updateQuery = "UPDATE OrderRequestNew_Header " +
                                 "SET Processing_Status = 'CANCELLED' " +
                                 "WHERE OrderId = @OrderId;";
            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    // Update
                    using (var updateCommand = new SqlCommand(updateQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@OrderId", orderId);
                        await updateCommand.ExecuteNonQueryAsync();
                    }
                    isSuccess = true;
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    isSuccess = false;
                    throw;
                }
                catch (Exception ex)
                {
                    isSuccess = false;
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
                return isSuccess;
            }
        }
        public async Task<bool> RollbackDeleteGraisFromOrderId(string orderId)
        {
            bool isSuccess = false;
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string deleteQuery = "DELETE FROM OrderRequestProcessed_Detail WHERE OrderId = @OrderId;";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    // Delete
                    using (var deleteCommand = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCommand.Parameters.AddWithValue("@OrderId", orderId);
                        await deleteCommand.ExecuteNonQueryAsync();
                    }
                    isSuccess = true;
                }
                catch (SqlException ex) when (ex.Number == 2627)
                {
                    isSuccess = false;
                    throw;
                }
                catch (Exception ex)
                {
                    isSuccess = false;
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
                return isSuccess;
            }
        }
        public async Task<List<string>> GetGraisFromOrderId(string orderId)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            string query = $"SELECT GRAI FROM IGPS_DEPOT_GLN WHERE GRAI IN (SELECT AssetId FROM orderrequestprocessed_detail WHERE OrderId = '{orderId}')";
            List<string> grais = new List<string>();
            using (var conn = connection)
            {
                try
                {
                    conn.Open();
                    using (var command = new SqlCommand(query, conn))
                    {
                        reader = await command.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var grai = reader["GRAI"].ToString();
                                grais.Add(grai);
                            }
                        }
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
                return grais;
            }
        }

        public async Task ClearExistingGrais(string grais)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            string query = $"DELETE FROM IGPS_DEPOT_GLN WHERE GRAI IN ({grais})";
            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    using (var command = new SqlCommand(query, conn))
                    {
                        await command.ExecuteNonQueryAsync();
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
        public async Task<string> ReadCountFromOrderId(string gln)
        {
            string result = string.Empty;
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT COUNT(*) AS COUNT FROM OrderRequestProcessed_Detail WHERE OrderId = '{gln}';";

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
                        result = reader["COUNT"].ToString();
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }

                return result;
            }
        }

        public Task Rollback(string orderId, string gln)
        {
            throw new NotImplementedException();
        }
    }
}
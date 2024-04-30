using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Models.Repositories;

namespace iGPS_Help_Desk.Repositories
{
    public class IgpsDepotGlnRepository : BaseRepository
    {
        public async Task<(List<IGPS_DEPOT_GLN>, int)> ReadAllContainers()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();

            string query = "SELECT Gln, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN ORDER BY GLN";

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
                command.CommandTimeout = 300;
                reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                        Glns.Add(glnsFromDb);
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }

                return (Glns, Glns.Count);
            }
        }
        public async Task<List<IGPS_DEPOT_GLN>> SearchGraiFromContainer(string grai, string gln, string generationPrefix)
        {
            grai = $"%{generationPrefix}{grai}%";

            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT Gln, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GLN = @Gln AND GRAI LIKE @Grai ORDER BY GLN";

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

                command.Parameters.Add("@Gln", System.Data.SqlDbType.VarChar);
                command.Parameters["@Gln"].Value = gln;

                command.Parameters.Add("@Grai", System.Data.SqlDbType.VarChar);
                command.Parameters["@Grai"].Value = grai;

                reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                        Glns.Add(glnsFromDb);
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }

                return Glns;
            }
        }

        public async Task<(List<IGPS_DEPOT_GLN>, int)> ReadAllContainersBatch()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (string.IsNullOrEmpty(test))
            {
                _logger.Error("Connection string is missing or empty.");
                return (null, 0);
            }

            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();
            int offset = 1;
            int count = await GetCountOfTable();
            int fetchNext = 10000;

            using (connection = new SqlConnection(test))
            {
                try
                {
                    connection.Open();

                    while (offset < count)
                    {
                        string query = $"SELECT Gln, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN ORDER BY GLN" +
                                       $" OFFSET {offset} ROWS FETCH NEXT {fetchNext} ROWS ONLY";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.CommandTimeout = 500;
                            using (reader = await command.ExecuteReaderAsync())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                                        Glns.Add(glnsFromDb);
                                    }
                                }
                            }
                        }

                        offset += fetchNext;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                finally
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return (Glns, Glns.Count);
        }


        public async Task<int> GetCountOfTable()
        {
            int result = 0;
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string query = "SELECT COUNT(*) AS COUNT FROM IGPS_DEPOT_GLN";
            using (SqlConnection conn = connection)
            {
                try
                {
                    conn.Open();
                    // Perform database operations here
                    SqlCommand command = new SqlCommand(query, conn);

                    reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result = Int32.Parse(reader["COUNT"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    _logger.Error(ex.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return result;
        }

        public async Task<List<IGPS_DEPOT_GLN>> ReadFromGraiList(List<string> list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT GLN, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GRAI IN " +
                $"({string.Join(",", list.Select((_, index) => $"@param{index}"))});";

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

                for (int i = 0; i < list.Count; i++)
                {
                    command.Parameters.AddWithValue($"param{i}", list[i]);
                }
                reader = await command.ExecuteReaderAsync();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                        Grais.Add(glnsFromDb);
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return Grais;
        }
        public async Task<List<IGPS_DEPOT_GLN>> ReadContainersFromList(List<string> list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            // Constructing the parameterized query string
            string query = $"SELECT GLN, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GLN IN " +
                $"({string.Join(",", list.Select((_, index) => $"@param{index}"))}) ORDER BY GLN;";

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

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Adding parameters to the command
                    for (int i = 0; i < list.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", list[i]);
                    }

                    reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                            Grais.Add(glnsFromDb);
                        }
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return Grais;
        }
        
        public async Task<List<IGPS_DEPOT_GLN>> ReadContainersFromList(string list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT GLN, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GLN IN ({list}) ORDER BY GLN;";

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
                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                        Grais.Add(glnsFromDb);
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return Grais;
        }



        public async Task<List<IGPS_DEPOT_GLN>> ReadContainersFromListOrderByDate(string list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT GLN, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GLN IN ({list}) ORDER BY DATE_TIME;";

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
                        IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                        Grais.Add(glnsFromDb);
                    }
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }

                return Grais;
            }
        }

        //public async void DeleteGlnsFromList(List<string> list)
        //{
        //    var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
        //    if (test != null)
        //    {
        //        connection = new SqlConnection(test);
        //    }

        //    string deleteQuery = $"DELETE FROM IGPS_DEPOT_GLN WHERE GLN IN " +
        //        $"({string.Join(",", list.Select((_, index) => $"@param{index}"))})";

        //    using (var conn = connection)
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.Error(ex.Message);
        //        }

        //        SqlCommand command = new SqlCommand(deleteQuery, conn);

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            command.Parameters.AddWithValue($"param{i}", list[i]);
        //        }

        //        reader = await command.ExecuteReaderAsync();


        //        if (conn.State == System.Data.ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        public async void DeleteGraisFromList(string list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            string deleteQuery = $"DELETE FROM IGPS_DEPOT_GLN WHERE GLN IN ({list})";

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

                SqlCommand command = new SqlCommand(deleteQuery, conn);

                reader = await command.ExecuteReaderAsync();


                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

      


        public async Task<List<string>> GetGhostGrais()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<string> Grais = new List<string>();

            string query = "select GLN from IGPS_DEPOT_GLN except select GLN from IGPS_DEPOT_LOCATION;";
            using (SqlConnection conn = connection)
            {
                try
                {
                    conn.Open();
                    // Perform database operations here
                    SqlCommand command = new SqlCommand(query, conn);

                    reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var glnsFromDb = reader["GLN"].ToString();
                            Grais.Add(glnsFromDb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    _logger.Error(ex.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return Grais;
        }
    }
}
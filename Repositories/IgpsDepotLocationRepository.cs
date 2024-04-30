using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class IgpsDepotLocationRepository : BaseRepository
    {

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadAllContainers()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();
            string query = "SELECT SITE_ID, GLN, GLN96, Status, CREATE_DATE, DESCRIPTION, Visible, SubStatus, SKUType, " +
                "(SELECT COUNT(GLN) FROM IGPS_DEPOT_GLN WHERE IGPS_DEPOT_GLN.GLN = IGPS_DEPOT_LOCATION.GLN )  AS COUNT " +
                "FROM IGPS_DEPOT_LOCATION;";

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
                        var glnsFromDb = new IGPS_DEPOT_LOCATION(reader);
                        glnsFromDb.Count = (int)reader["COUNT"];
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

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadContainersFromList(List<string> list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();

            string query = $"SELECT SITE_ID, GLN, GLN96, Status, CREATE_DATE, DESCRIPTION, Visible, SubStatus, SKUType" +
                $" FROM IGPS_DEPOT_LOCATION WHERE GLN IN " +
                $"({string.Join(",", list.Select((_, index) => $"@param{index}"))})";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();


                    SqlCommand command = new SqlCommand(query, conn);

                    for (int i = 0; i < list.Count; i++)
                    {
                        command.Parameters.AddWithValue($"@param{i}", list[i]);
                    }

                    reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var glnsFromDb = new IGPS_DEPOT_LOCATION(reader);
                            Glns.Add(glnsFromDb);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return Glns;
            }
        }


        public async Task<List<string>> ReadDnus()
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            List<string> containers = new List<string>();

            string query = $"SELECT Gln FROM IGPS_DEPOT_LOCATION WHERE DESCRIPTION LIKE ('%DNU%')" +
                           $" ORDER BY GLN;";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

                    reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var gln = reader["GLN"].ToString();
                            containers.Add(gln);
                        }
                    }


                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                return containers;
            }
        }

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadFromSearch(string search)
        {
            search = $"%{search}%";
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;

            if (test != null)
            {
                connection = new SqlConnection(test);
            }

            List<IGPS_DEPOT_LOCATION> containers = new List<IGPS_DEPOT_LOCATION>();

            string query =
                $"SELECT GLN, Status, SubStatus, Description," +
                $"(SELECT COUNT(GLN) FROM IGPS_DEPOT_GLN WHERE IGPS_DEPOT_GLN.GLN = IGPS_DEPOT_LOCATION.GLN) AS COUNT " +
                $"FROM IGPS_DEPOT_LOCATION WHERE Description LIKE @ContainerSearch OR GLN LIKE @ContainerSearch;";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.Add("@ContainerSearch", System.Data.SqlDbType.VarChar);
                    command.Parameters["@ContainerSearch"].Value = search;

                    reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var gln = reader["GLN"].ToString();
                            var status = reader["Status"].ToString();
                            var subStatus = reader["SubStatus"].ToString();
                            var description = reader["Description"].ToString();
                            var glnsFromDb = new IGPS_DEPOT_LOCATION(gln, status, subStatus, description);
                            glnsFromDb.Count = (int)reader["COUNT"];
                            containers.Add(glnsFromDb);
                        }
                    }

                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                }
                return containers;
            }
        }

        public async void DeleteContainersFromList(string list)
        {
            var test = ConfigurationManager.ConnectionStrings["connectionString"]?.ConnectionString;
            if (test != null)
            {
                connection = new SqlConnection(test);
            }
            if (list.Length == 0)
            {
                MessageBox.Show("No containers found");
                return;
            }
            string query = $"DELETE FROM IGPS_DEPOT_LOCATION WHERE GLN IN " +
                $"({list})";

            using (var conn = connection)
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(query, conn);

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
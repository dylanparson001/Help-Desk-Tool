using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Models.Repositories;

namespace iGPS_Help_Desk.Repositories
{
    public class IgpsDepotGlnRepository : BaseRepository
    {
        public async Task<(List<IGPS_DEPOT_GLN>, int)> ReadAllContainers()
        {
            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();

            Connect();
            await ExecuteQuery("SELECT Gln, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN ORDER BY GLN");

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                    Glns.Add(glnsFromDb);
                }
            }
            Disconnect();

            return (Glns, Glns.Count);
        }

        public async Task<List<IGPS_DEPOT_GLN>> ReadContainersFromList(string list)
        {
            List<IGPS_DEPOT_GLN> Grais = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT GLN, GRAI, DATE_TIME FROM IGPS_DEPOT_GLN WHERE GLN IN ({list}) ORDER BY GLN;";

            Connect();
            await ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                    Grais.Add(glnsFromDb);
                }
            }
            Disconnect();
            return Grais;
        }


        public async void DeleteGlnsFromList(string list)
        {
            string deleteQuery = $"DELETE FROM IGPS_DEPOT_GLN WHERE GLN IN ({list})";

            Connect();
            await ExecuteQuery(deleteQuery);

            Disconnect();

        }

        public async void UpdateContainersToExistingContainer(string fromGln, string toGln)
        {
            var grais = await ReadContainersFromList(fromGln);
            List<string> tempList = new List<string>();

            foreach (var g in grais)
            {
                tempList.Add(g.Grai.ToString());
            }

            var concatenatedGrais = ConcatStringFromList(tempList);

            string updateQuery = $"UPDATE IGPS_DEPOT_GLN " +
                                 $"SET GLN = {toGln}" +
                                 $"WHERE GRAI IN ({concatenatedGrais})";

            using (SqlConnection conn = new SqlConnection(
                       $"Data Source=localhost\\SqlExpress;Initial Catalog=epcdocmandb_igps;" +
                       $" MultipleActiveResultSets=true;Uid=epcdocman;Pwd=just4us;"))
            {
                try
                {
                    connection.Open();
                    // Perform database operations here

                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    reader = await command.ExecuteReaderAsync();
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        public async void UpdateSelectedGrais(List<string> grais, string toGln)
        {
            var concatenatedGrais = ConcatStringFromList(grais);

            string updateQuery = $"UPDATE IGPS_DEPOT_GLN " +
                                $"SET GLN = {toGln}" +
                                $"WHERE GRAI IN ({concatenatedGrais})";
            
            using (SqlConnection conn = new SqlConnection($"Data Source=localhost\\SqlExpress;Initial Catalog=epcdocmandb_igps;" +
                                                          $" MultipleActiveResultSets=true;Uid=epcdocman;Pwd=just4us;"))
            {
                try
                {
                    connection.Open();
                    // Perform database operations here
                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    reader = await command.ExecuteReaderAsync(); 
                }
                catch (Exception ex)
                {
                    // Handle exceptions here
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            } 
            
            /*Connect();
            await ExecuteQuery(updateQuery);

            Disconnect();*/
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class IgpsDepotGlnRepository: BaseRepository
    {
        public List<IGPS_DEPOT_GLN> ReadAllContainers()
        {
            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();
            
            Connect();
            ExecuteQuery("SELECT * FROM IGPS_DEPOT_GLN ORDER BY GLN ");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                    Glns.Add(glnsFromDb);
                }
            }
            Disconnect();

            return Glns;
        }

        public List<IGPS_DEPOT_GLN> ReadContainersFromList(string list)
        {
            List<IGPS_DEPOT_GLN> Glns = new List<IGPS_DEPOT_GLN>();

            string query = $"SELECT * FROM IGPS_DEPOT_GLN WHERE GLN IN ({list}) ORDER BY GLN;";
            
            Connect();  
            ExecuteQuery(query);
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    IGPS_DEPOT_GLN glnsFromDb = new IGPS_DEPOT_GLN(reader);
                    Glns.Add(glnsFromDb);
                }
            }
            Disconnect();
            return Glns;
        }

        public void DeleteGlnsFromList(string list)
        {
            string deleteQuery = $"DELETE FROM IGPS_DEPOT_GLN WHERE GLN IN ({list})";

            Connect();
            ExecuteQuery(deleteQuery);
            
            Disconnect();

        }
    }
}

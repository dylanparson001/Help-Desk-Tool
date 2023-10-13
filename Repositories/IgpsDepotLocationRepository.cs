using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class IgpsDepotLocationRepository : BaseRepository
    {
        public List<IGPS_DEPOT_LOCATION> ReadAllContainers()
        {
            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();

            Connect();
            ExecuteQuery("SELECT * FROM IGPS_DEPOT_LOCATION ORDER BY GLN ");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var glnsFromDb = new IGPS_DEPOT_LOCATION(reader);
                    Glns.Add(glnsFromDb);
                }
            }

            Disconnect();

            return Glns;
        }

        public List<IGPS_DEPOT_LOCATION> ReadContainersFromList(string list)
        {

            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();

            string query = $"SELECT * FROM IGPS_DEPOT_LOCATION WHERE GLN IN ({list})";

            Connect();
            ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var glnsFromDb = new IGPS_DEPOT_LOCATION(reader);
                    Glns.Add(glnsFromDb);
                }
            }

            Disconnect();
            return Glns;
        }

        public List<string> ReadDnus()
        {
            List<string> containers = new List<string>();

            string query = $"SELECT * FROM IGPS_DEPOT_LOCATION WHERE DESCRIPTION LIKE ('%DNU%')" +
                           $" ORDER BY GLN;";

            Connect();
            ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var containersFromDb = new IGPS_DEPOT_LOCATION(reader);
                    containers.Add(containersFromDb.Gln);
                }
            }
            
            Disconnect();
            return containers;
        }

        public void ChangeStatus(string list, string newStatus)
        {

            string query = $"UPDATE IGPS_DEPOT_LOCATION " +
                           $"SET STATUS = '{newStatus}'" +
                           $"WHERE GLN IN ({list})";

            Connect();
            ExecuteQuery(query);

            Disconnect();
        }

        public void ChangeSubStatus(string list, string newSubStatus)
        {
            string query = $"UPDATE IGPS_DEPOT_LOCATION " +
                           $"SET SubStatus = '{newSubStatus}'" +
                           $"WHERE GLN IN ({list})";

            Connect();
            ExecuteQuery(query);

            Disconnect();
        }

        public void DeleteContainersFromList(string list)
        {
            string query = $"DELETE FROM IGPS_DEPOT_LOCATION WHERE GLN IN ({list})";
            Connect();
            ExecuteQuery(query);
            
            Disconnect();
            
        }
        
        

    }
}
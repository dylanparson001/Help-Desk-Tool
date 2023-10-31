using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class IgpsDepotLocationRepository : BaseRepository
    {
        public async Task<List<IGPS_DEPOT_LOCATION>> ReadAllContainers() { 
        
            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();

            Connect();
            await ExecuteQuery("SELECT GLN, Status, SubStatus, Description FROM IGPS_DEPOT_LOCATION ORDER BY GLN ");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var gln = reader["GLN"].ToString();
                    var status = reader["Status"].ToString();
                    var subStatus = reader["SubStatus"].ToString();
                    var description = reader["Description"].ToString();
                    var glnsFromDb = new IGPS_DEPOT_LOCATION(gln, status, subStatus, description);
                    Glns.Add(glnsFromDb);
                }
            }

            Disconnect();

            return Glns;
        }

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadContainersFromList(string list)
        {

            List<IGPS_DEPOT_LOCATION> Glns = new List<IGPS_DEPOT_LOCATION>();

            string query = $"SELECT Gln, Status, SubStatus FROM IGPS_DEPOT_LOCATION WHERE GLN IN ({list})";

            Connect();
            await ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var gln = reader["GLN"].ToString();
                    var status = reader["Status"].ToString();
                    var subStatus = reader["SubStatus"].ToString();
                    var glnsFromDb = new IGPS_DEPOT_LOCATION(gln, status, subStatus);
                    Glns.Add(glnsFromDb);
                }
            }

            Disconnect();
            return Glns;
        }

        public async Task<List<string>> ReadDnus()
        {
            List<string> containers = new List<string>();

            string query = $"SELECT Gln FROM IGPS_DEPOT_LOCATION WHERE DESCRIPTION LIKE ('%DNU%')" +
                           $" ORDER BY GLN;";

            Connect();
            await ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var gln = reader["GLN"].ToString();
                    containers.Add(gln);
                }
            }
            
            Disconnect();
            return containers;
        }

        public async Task<List<IGPS_DEPOT_LOCATION>> ReadFromSearch(string search)
        {
            List<IGPS_DEPOT_LOCATION> containers = new List<IGPS_DEPOT_LOCATION>();

            string query = $"SELECT * FROM IGPS_DEPOT_LOCATION WHERE DESCRIPTION LIKE ('{search}%') OR GLN LIKE ('{search}%')";

            Connect();
            await ExecuteQuery(query);
            if (reader.HasRows)
            {
                while (reader.Read())
                {;
                    var container = new IGPS_DEPOT_LOCATION(reader);
                    containers.Add(container);
                }
            }
            Disconnect();
            return containers;
        }

        public async void ChangeStatus(string list, string newStatus)
        {

            string query = $"UPDATE IGPS_DEPOT_LOCATION " +
                           $"SET STATUS = '{newStatus}'" +
                           $"WHERE GLN IN ({list})";

            Connect();
            await ExecuteQuery(query);

            Disconnect();
        }

        public async void ChangeSubStatus(string list, string newSubStatus)
        {
            string query = $"UPDATE IGPS_DEPOT_LOCATION " +
                           $"SET SubStatus = '{newSubStatus}'" +
                           $"WHERE GLN IN ({list})";

            Connect();
            await ExecuteQuery(query);

            Disconnect();
        }

        public async void DeleteContainersFromList(string list)
        {
            if (list.Length == 0)
            {
                MessageBox.Show("No containers found");
                return;
            }
            string query = $"DELETE FROM IGPS_DEPOT_LOCATION WHERE GLN IN ({list})";
            Connect();
            await ExecuteQuery(query);
            
            Disconnect();
            
        }


        

    }
}
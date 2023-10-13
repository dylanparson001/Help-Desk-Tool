using System.Collections.Generic;
using System.Linq;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class FacilityContainerStatusRepository : BaseRepository
    {
        public List<string> GetStatuses()
        {
            List<string> statusList = new List<string>();

            string query = "SELECT * FROM FacilityContainerStatus";

            Connect();
            ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var statusFromDb = new FacilityContainerStatus(reader);
                    statusList.Add(statusFromDb.Status);
                }
            }

            Disconnect();
            return statusList;
        }

        public List<string> GetSubStatusesFromStatus(string status)
        {
            List<string> subStatusList = new List<string>();
            string query = $"SELECT * FROM FacilityContainerStatus WHERE Status = '{status}';";
            Connect();
            ExecuteQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var subStatusFromDb = new FacilityContainerStatus(reader);
                    subStatusList.Add(subStatusFromDb.SubStatus);
                }
            }

            Disconnect();
            return subStatusList;
        }
    }
    }

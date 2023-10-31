using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Models.Repositories
{
    public class FacilityContainerStatusRepository : BaseRepository
    {
        public async Task<List<string>> GetStatuses()
        {
            List<string> statusList = new List<string>();

            string query = "SELECT * FROM FacilityContainerStatus";

            Connect();
            await ExecuteQuery(query);

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
            string query = $"SELECT * FROM FacilityContainerStatus WHERE Status = @Status;";

            Connect();

            // ExecuteQuery(query);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Status", status);

            reader = command.ExecuteReader();


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

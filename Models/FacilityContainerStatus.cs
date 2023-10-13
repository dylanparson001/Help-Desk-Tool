using System;
using System.Data.SqlClient;

namespace iGPS_Help_Desk.Models
{
    public class FacilityContainerStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public bool Allowed { get; set; }
        public string FacilityId { get; set; }
        public string SubStatus { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string SkuType { get; set; }
        

        public FacilityContainerStatus(SqlDataReader reader)
        {
            Id = (int)reader["Id"];
            Status = reader["Status"].ToString();
            Allowed = (bool)reader["Allowed"];
            FacilityId = reader["FacilityID"].ToString();
            SubStatus = reader["SubStatus"].ToString();
            ModifiedDate = (DateTime)reader["ModifiedDate"];
            SkuType = reader["SKUType"].ToString();
        }
    }
}
using System.Data.SqlClient;

namespace iGPS_Help_Desk.Models
{
    public class IGPS_DEPOT_LOCATION
    {
        public SqlDataReader DataReader { get; set; }
        public string SiteId { get; set; }
        public string Gln { get; set; }
        public string Gln96 { get; set; }
        public string Status { get; set; }
        public string Date_Time { get; set; }
        public string Description { get; set; }
        public object Visible { get; set; }
        public string SubStatus { get; set; }
        public string SkuType { get; set; }
        public int Count { get; set; }

        public IGPS_DEPOT_LOCATION()
        {
            
        }
        public IGPS_DEPOT_LOCATION(string gln)
        {
            Gln = gln;
        }
        public IGPS_DEPOT_LOCATION(string gln, string status,
            string subStatus, string description)
        {
            Gln = gln;
            Status = status;
            SubStatus = subStatus;
            Description = description;
        }
        public IGPS_DEPOT_LOCATION(string gln, string status,
            string subStatus)
        {
            Gln = gln;
            Status = status;
            SubStatus = subStatus;
        }

        public IGPS_DEPOT_LOCATION(SqlDataReader reader)
        {
            SiteId = reader["SITE_ID"].ToString();
            Gln = reader["GLN"].ToString();
            Gln96 = reader["GLN96"].ToString();
            Status = reader["STATUS"].ToString();
            Date_Time = reader["CREATE_DATE"].ToString();
            Description = reader["DESCRIPTION"].ToString();
            Visible = reader["Visible"];
            SubStatus = reader["SubStatus"].ToString();
            SkuType = reader["SKUtype"].ToString();

        }
    }
}

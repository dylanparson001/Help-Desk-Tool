using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Models
{
    public class IGPS_DEPOT_GLN
    {
        public SqlDataReader DataReader{ get; set; }
        public string Gln { get; set; }
        public string Grai { get; set; }
        public DateTime Date_Time { get; set; }

        public IGPS_DEPOT_GLN(SqlDataReader reader)
        {
            Gln = reader["GLN"].ToString();
            Grai = reader["GRAI"].ToString();
            Date_Time = (DateTime)reader["DATE_TIME"];
        }
    }
}

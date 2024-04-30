using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGPS_Help_Desk.Models
{
    public class OrderRequestNewHeader
    {
        public string  OrderId { get; set; }
        public short? CodeProductType { get; set; }
        public DateTime? OriginatorDate { get; set; }
        public string FacilityId_Source { get; set; }
        public string FacilityId_Pickup { get; set; }
        public string FacilityId_Delivery { get; set; }
        public DateTime? ShipDateEarliest { get; set; }
        public DateTime? ShipDateLatest { get; set; }
        public DateTime? DeliveryDateEarliest { get; set; }
        public DateTime? DeliveryDateLatest { get; set; }
        public DateTime? DeliveryDateActual { get; set; } 
        public short? StackHeight { get; set; }
        public short? RequestedQuantity { get; set; }
        public short? TotalWeight { get; set; }
        public string BolId { get; set; }
        public string iTRACOrderNo { get; set; }
        public string iTRACCustPONo { get; set; }
        public string LogisticsOrderId { get; set; }
        public string LogisticsTruckType { get; set; }
        public string LogisticsCarrierId { get; set; } 
        public string LogisticsCarrierName { get; set; }
        public string LogisticsCarrierProNo { get; set; }
        public string LogisticsShipmentNo { get; set; }
        public string LogisticsReceiptNo { get; set; }
        public string DeliveryComment { get; set; }
        public string LoadComment { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string User3 { get; set; }
        public string User4 { get; set; }
        public string User5 { get; set; }
        public string User6 { get; set; }
        public string User7 { get; set; }
        public string User8 { get; set; }
        public string User9 { get; set; }
        public string User10 { get; set; }
        public string PROCESSING_STATUS { get; set; }
        public DateTime? STATUS_DATE { get; set; }

        public OrderRequestNewHeader(SqlDataReader reader)
        {
            OrderId = reader["OrderId"].ToString();
            CodeProductType = (short)reader["CodeProductType"];
            OriginatorDate = (DateTime)reader["OriginatorDate"];
            FacilityId_Source = reader["FacilityId_Source"].ToString();
            FacilityId_Pickup = reader["FacilityId_Pickup"].ToString();
            FacilityId_Delivery = reader["FacilityId_Delivery"].ToString();
            ShipDateEarliest = (DateTime)reader["ShipDateEarliest"];
            ShipDateLatest = (DateTime)reader["ShipDateLatest"];
            DeliveryDateEarliest = (DateTime)reader["DeliveryDateEarliest"];
            DeliveryDateLatest = (DateTime)reader["DeliveryDateLatest"];
            DeliveryDateActual = reader["DeliveryDateActual"] == DBNull.Value ? null : (DateTime?)reader["DeliveryDateActual"];
            StackHeight = (short)reader["StackHeight"];
            RequestedQuantity = (short) reader["RequestedQuantity"];
            TotalWeight = (short)(int)reader["TotalWeight"];
            BolId = reader["BolId"].ToString();
            iTRACOrderNo = reader["iTRACOrderNo"].ToString();
            iTRACCustPONo = reader["iTRACCustPONo"].ToString();
            LogisticsOrderId = reader["LogisticsOrderId"].ToString();
            LogisticsTruckType = reader["LogisticsTruckType"].ToString();
            LogisticsCarrierId = reader["LogisticsCarrierId"].ToString();
            LogisticsCarrierName = reader["LogisticsCarrierName"].ToString();
            LogisticsCarrierProNo = reader["LogisticsCarrierProNo"].ToString();
            LogisticsShipmentNo = reader["LogisticsShipmentNo"].ToString();
            LogisticsReceiptNo = reader["LogisticsReceiptNo"].ToString();
            DeliveryComment = reader["DeliveryComment"].ToString();
            LoadComment = reader["LoadComment"].ToString();
            User1 = reader["User1"].ToString();
            User2 = reader["User2"].ToString();
            User3 = reader["User3"].ToString();
            User4 = reader["User4"].ToString();
            User5 = reader["User5"].ToString();
            User6 = reader["User6"].ToString();
            User7 = reader["User7"].ToString();
            User8 = reader["User8"].ToString();
            User9 = reader["User9"].ToString();
            User10 = reader["User10"].ToString();
            PROCESSING_STATUS = reader["PROCESSING_STATUS"].ToString();
            if (!reader.IsDBNull(reader.GetOrdinal("STATUS_DATE")))
            {
                STATUS_DATE = (DateTime)reader["STATUS_DATE"];
            }
            else
            {
                //STATUS_DATE = DateTime.MinValue; // or
                STATUS_DATE = null; // if STATUS_DATE is nullable
            }
        }

    }
}

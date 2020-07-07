namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Live
    {
        [Key]
        public long OrderNo { get; set; }

        [StringLength(50)]
        public string OrderType { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(10)]
        public string SecurityType { get; set; }

        [StringLength(50)]
        public string CDS_AC_No { get; set; }

        [StringLength(12)]
        public string Broker_Code { get; set; }

        [StringLength(50)]
        public string Client_Type { get; set; }

        public decimal? Tax { get; set; }

        [StringLength(50)]
        public string Shareholder { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        public int? TotalShareHolding { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        public DateTime? Create_date { get; set; }

        public DateTime? Deal_Begin_Date { get; set; }

        public DateTime? Expiry_Date { get; set; }

        public int? Quantity { get; set; }

        public decimal? BasePrice { get; set; }

        public int? AvailableShares { get; set; }

        [StringLength(50)]
        public string OrderPref { get; set; }

        [StringLength(255)]
        public string OrderAttribute { get; set; }

        [StringLength(255)]
        public string Marketboard { get; set; }

        [StringLength(255)]
        public string TimeInForce { get; set; }

        [StringLength(255)]
        public string OrderQualifier { get; set; }

        [StringLength(255)]
        public string BrokerRef { get; set; }

        [StringLength(255)]
        public string ContraBrokerId { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? MiniPrice { get; set; }

        public bool? Flag_oldorder { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(30)]
        public string Currency { get; set; }

        [StringLength(50)]
        public string Language { get; set; }
    }
}

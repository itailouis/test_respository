namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LiveTradingMaster")]
    public partial class LiveTradingMaster
    {
        [Key]
        public long LiveTMID { get; set; }

        public long? OrderNo { get; set; }

        [StringLength(50)]
        public string OrderType { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(10)]
        public string SecurityType { get; set; }

        [StringLength(50)]
        public string CDS_AC_No { get; set; }

        [StringLength(10)]
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
        public string DealStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? Expiry_Date { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? BasePrice { get; set; }

        public int? AvailableShares { get; set; }

        [StringLength(50)]
        public string OrderPref { get; set; }

        public int? OrderTransQty { get; set; }

        [Column(TypeName = "money")]
        public decimal? OrderTransPrice { get; set; }

        public DateTime? DealDate { get; set; }

        [StringLength(255)]
        public string OrderAttribute { get; set; }

        [StringLength(255)]
        public string TimeInForce { get; set; }

        [StringLength(255)]
        public string Marketboard { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? MiniPrice { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Posted
    {
        [Key]
        public long DealNo { get; set; }

        [StringLength(50)]
        public string DealType { get; set; }

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

        [Column(TypeName = "numeric")]
        public decimal? Tax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shareholder { get; set; }

        [StringLength(50)]
        public string ClientName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalShareHolding { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DealStatus { get; set; }

        public DateTime? Create_date { get; set; }

        public DateTime? Deal_Begin_Date { get; set; }

        public DateTime? Expiry_Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BasePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AvailableShares { get; set; }

        [StringLength(50)]
        public string OrderPref { get; set; }
    }
}

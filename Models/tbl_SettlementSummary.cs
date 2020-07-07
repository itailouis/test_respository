namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SettlementSummary
    {
        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(400)]
        public string deal_reference { get; set; }

        [StringLength(4000)]
        public string client_name { get; set; }

        [StringLength(4000)]
        public string client_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? trade_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? unit_price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Broker_Amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Broker_Charge { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Stamp_Duty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Capital_Gain_Tax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? vat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount_due { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Settlement_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Brokerage_Total { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Sub_total { get; set; }

        [StringLength(50)]
        public string Status_Flag { get; set; }

        [StringLength(50)]
        public string OrderType { get; set; }

        [StringLength(18)]
        public string Eft_File_Status { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
    }
}

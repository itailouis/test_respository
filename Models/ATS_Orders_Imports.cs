namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ATS_Orders_Imports
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TransID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long InitDealNo { get; set; }

        public int? InitSuffixNo { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DealPrice { get; set; }

        public DateTime? DealDateTime { get; set; }

        [StringLength(10)]
        public string Broker_Init { get; set; }

        [StringLength(10)]
        public string Broker_Target { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(6)]
        public string InitDealType { get; set; }

        [StringLength(6)]
        public string TargetDealType { get; set; }

        public long? TargetDealNo { get; set; }

        public int? TargetSuffixNo { get; set; }
    }
}

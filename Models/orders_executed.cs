namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class orders_executed
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal TransId { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal InitDealNo { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal InitSuffixNo { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal DealPrice { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime DealDateTime { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Broker_init { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Broker_target { get; set; }

        [StringLength(10)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string InitDealType { get; set; }

        [StringLength(50)]
        public string TargetDealType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TargetDealNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TargetSuffixNo { get; set; }

        public bool? dealstatus { get; set; }
    }
}

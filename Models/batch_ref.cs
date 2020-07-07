namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class batch_ref
    {
        [Key]
        [Column("batch_ref", Order = 0, TypeName = "numeric")]
        public decimal batch_ref1 { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal MatcheDealNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string DrBroker { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shareholder { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string CrBroker { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal TradedShares { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string TradedAmount { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime TradedDate { get; set; }

        [StringLength(50)]
        public string Company { get; set; }
    }
}

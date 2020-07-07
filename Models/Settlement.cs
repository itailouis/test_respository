namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Settlement
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal MatchDeal { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string DealerA { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal sharesA { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string TranTypeA { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal ConfirmA { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string DealerB { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal SharesB { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string TranTypeB { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal ConfirmB { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime DealDate { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("marketcap")]
    public partial class marketcap
    {
        [Key]
        [StringLength(50)]
        public string company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? price { get; set; }

        [Column("Market cap", TypeName = "numeric")]
        public decimal? Market_cap { get; set; }
    }
}

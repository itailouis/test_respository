namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class temptran
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? batch_ref { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? matchedDeal { get; set; }

        [StringLength(50)]
        public string shareholder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shares { get; set; }

        public DateTime? Transdate { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rights_instr
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal issue_no { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime close_date { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal offer { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal every { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string round { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal price_per_share { get; set; }
    }
}

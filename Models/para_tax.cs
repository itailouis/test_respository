namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_tax
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(50)]
        public string fnam { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal rate { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}

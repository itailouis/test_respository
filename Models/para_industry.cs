namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_industry
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(70)]
        public string fnam { get; set; }
    }
}

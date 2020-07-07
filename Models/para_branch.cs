namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_branch
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bank { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string branch { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string branch_name { get; set; }

        [StringLength(50)]
        public string branch_code { get; set; }
    }
}

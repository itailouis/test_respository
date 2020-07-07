namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class div_types
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string type { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string fnam { get; set; }
    }
}

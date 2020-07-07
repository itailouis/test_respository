namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class industry_code
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal sector_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string sector_name { get; set; }
    }
}

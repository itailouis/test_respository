namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class security_type
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal security_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string security_name { get; set; }
    }
}

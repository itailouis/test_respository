namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class registrar_type
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal type_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string fnam { get; set; }
    }
}

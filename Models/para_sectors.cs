namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_sectors
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string fnam { get; set; }
    }
}

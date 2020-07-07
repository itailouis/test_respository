namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class batch_certs
    {
        public int id { get; set; }

        public int? batch_no { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? shares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? certificate_no { get; set; }
    }
}

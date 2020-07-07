namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cds_certs
    {
        [Column(TypeName = "numeric")]
        public decimal id { get; set; }

        [Required]
        [StringLength(50)]
        public string company { get; set; }

        public DateTime date_created { get; set; }

        [Column(TypeName = "numeric")]
        public decimal shares { get; set; }

        [StringLength(50)]
        public string certificate_number { get; set; }

        [StringLength(50)]
        public string agent { get; set; }

        [Required]
        [StringLength(50)]
        public string updated_by { get; set; }

        public DateTime updated_time { get; set; }
    }
}

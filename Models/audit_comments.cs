namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_comments
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string auditor { get; set; }

        [StringLength(50)]
        public string report { get; set; }

        [Column(TypeName = "text")]
        public string comment { get; set; }

        public DateTime? date_posted { get; set; }
    }
}

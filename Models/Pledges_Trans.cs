namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pledges_Trans
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string CDS_Number { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shares { get; set; }

        [StringLength(50)]
        public string TransType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string TransBy { get; set; }

        [StringLength(50)]
        public string TransRefID { get; set; }
    }
}

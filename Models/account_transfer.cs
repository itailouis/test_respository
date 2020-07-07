namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class account_transfer
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string from_broker { get; set; }

        [StringLength(50)]
        public string to_broker { get; set; }

        [StringLength(200)]
        public string comment { get; set; }

        public DateTime? date_sent { get; set; }

        public short? authorized { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? part_portfolio { get; set; }

        [StringLength(100)]
        public string company { get; set; }
    }
}

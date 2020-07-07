namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_unmatchedorders
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity_unmatched { get; set; }

        [Column(TypeName = "date")]
        public DateTime? order_date { get; set; }

        [StringLength(50)]
        public string orderno { get; set; }

        [StringLength(10)]
        public string order_status { get; set; }
    }
}

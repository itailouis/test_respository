namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_airtelmoney
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? txn_date { get; set; }

        public TimeSpan? txn_time { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [Column(TypeName = "money")]
        public decimal? amount { get; set; }

        public string txn_narration { get; set; }
    }
}

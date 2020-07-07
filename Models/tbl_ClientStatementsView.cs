namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ClientStatementsView
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? trans_date { get; set; }

        [Column("ref")]
        [StringLength(500)]
        public string _ref { get; set; }

        [StringLength(500)]
        public string trans_type { get; set; }

        [StringLength(4000)]
        public string details { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debit { get; set; }

        [Column(TypeName = "money")]
        public decimal? Credit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Balance { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string company { get; set; }
    }
}

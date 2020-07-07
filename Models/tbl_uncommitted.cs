namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_uncommitted
    {
        public int id { get; set; }

        public string Description { get; set; }

        public string Script { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string Sender { get; set; }

        public DateTime? Date_inserted { get; set; }

        public string Comment { get; set; }

        public string email_body { get; set; }

        [StringLength(50)]
        public string email_subject { get; set; }

        [StringLength(50)]
        public string email_to { get; set; }

        [StringLength(50)]
        public string category { get; set; }
    }
}

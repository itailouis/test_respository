namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pledges_release
    {
        [Key]
        public int Release_id { get; set; }

        public int? Pledge_id { get; set; }

        public DateTime? Release_date { get; set; }

        [StringLength(50)]
        public string Released_by { get; set; }

        public string Release_reseason { get; set; }

        [StringLength(10)]
        public string Release_Approval { get; set; }

        [StringLength(50)]
        public string codes { get; set; }
    }
}

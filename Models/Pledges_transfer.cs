namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pledges_transfer
    {
        [Key]
        public int trans_id { get; set; }

        public int? Pledge_id { get; set; }

        public DateTime? trans_date { get; set; }

        [StringLength(50)]
        public string transferred_by { get; set; }

        public string transfer_reason { get; set; }

        [StringLength(10)]
        public string transfer_Approval { get; set; }
    }
}

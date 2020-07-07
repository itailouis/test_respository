namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Batch_receipt
    {
        public int? id { get; set; }

        [Key]
        public int Batch_No { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Batch_Shares { get; set; }

        public decimal? Shareprice { get; set; }

        [Column(TypeName = "money")]
        public decimal? Batch_value { get; set; }

        public DateTime? Batch_date { get; set; }

        [StringLength(50)]
        public string Lodger { get; set; }

        public short? Balanced { get; set; }

        public short? Verified { get; set; }

        public short? Successful { get; set; }

        [StringLength(50)]
        public string broker_code { get; set; }

        [StringLength(50)]
        public string batch_type { get; set; }

        public short? masttemp { get; set; }

        [StringLength(50)]
        public string security_type { get; set; }
    }
}

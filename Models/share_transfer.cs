namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class share_transfer
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? amount_to_transfer { get; set; }

        [StringLength(50)]
        public string transferor { get; set; }

        [StringLength(50)]
        public string transferee { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        [Column(TypeName = "ntext")]
        public string query { get; set; }

        [StringLength(100)]
        public string company { get; set; }
    }
}

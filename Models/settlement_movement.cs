namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class settlement_movement
    {
        public int id { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string trans_type { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(50)]
        public string source { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? uploadId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UpdateState { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Order_Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TplusDealDate { get; set; }
    }
}

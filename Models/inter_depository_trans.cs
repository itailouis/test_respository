namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class inter_depository_trans
    {
        public int id { get; set; }

        [StringLength(50)]
        public string from_isin { get; set; }

        [StringLength(50)]
        public string to_isin { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string stockexchange { get; set; }

        [StringLength(50)]
        public string from_cds_number { get; set; }

        [StringLength(50)]
        public string to_cds_number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Quantity { get; set; }

        public string Reason_for_transfer { get; set; }

        public short? Authorized1 { get; set; }

        public short? Authorized2 { get; set; }

        [StringLength(50)]
        public string broker { get; set; }
    }
}

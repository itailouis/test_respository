namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_charges
    {
        public int id { get; set; }

        [StringLength(50)]
        public string ChargeName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Charge { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Updated { get; set; }
    }
}

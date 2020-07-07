namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_EventsDiary
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(150)]
        public string Caption { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EventDate { get; set; }

        [StringLength(4000)]
        public string Details { get; set; }

        [StringLength(50)]
        public string EventFlag { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EventEndDate { get; set; }
    }
}

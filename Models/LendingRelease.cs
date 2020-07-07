namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LendingRelease")]
    public partial class LendingRelease
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string transID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal initialloan { get; set; }

        [Column(TypeName = "numeric")]
        public decimal outstanding { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Returned { get; set; }

        public bool? ConfirmedCustodian { get; set; }

        public bool? ConfirmedBorrower { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateReturned { get; set; }
    }
}

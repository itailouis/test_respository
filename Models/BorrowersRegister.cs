namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BorrowersRegister")]
    public partial class BorrowersRegister
    {
        public int id { get; set; }

        [StringLength(4000)]
        public string cds_number { get; set; }

        [StringLength(4000)]
        public string surname { get; set; }

        [StringLength(4000)]
        public string forenames { get; set; }

        [StringLength(4000)]
        public string company { get; set; }

        [StringLength(4000)]
        public string quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EffectiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(4000)]
        public string Status { get; set; }
    }
}

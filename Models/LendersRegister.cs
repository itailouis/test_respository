namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LendersRegister")]
    public partial class LendersRegister
    {
        public int id { get; set; }

        [StringLength(400)]
        public string cds_number { get; set; }

        [StringLength(400)]
        public string surname { get; set; }

        [StringLength(400)]
        public string forenames { get; set; }

        [StringLength(400)]
        public string company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EffectiveDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(400)]
        public string Status { get; set; }

        [StringLength(20)]
        public string security_type { get; set; }
    }
}

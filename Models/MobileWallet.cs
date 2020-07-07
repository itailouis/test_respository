namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MobileWallet")]
    public partial class MobileWallet
    {
        [Key]
        public int ID_ { get; set; }

        [StringLength(50)]
        public string Identification { get; set; }

        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        [StringLength(50)]
        public string ReferenceNumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount_Paid { get; set; }

        public DateTime? Date_Created { get; set; }

        public bool? Used { get; set; }

        [Column("MobileWallet")]
        [StringLength(50)]
        public string MobileWallet1 { get; set; }
    }
}

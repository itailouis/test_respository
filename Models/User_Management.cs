namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Management
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [Key]
        [StringLength(50)]
        public string User_Name { get; set; }

        [StringLength(50)]
        public string Pass_Word { get; set; }

        [StringLength(50)]
        public string ContactEmail { get; set; }

        public bool? OnTempKey { get; set; }

        public bool? UserStatus { get; set; }

        public int? LockCount { get; set; }

        public bool? Locked { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Expiry { get; set; }

        [StringLength(500)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(500)]
        public string Active_Session { get; set; }

        [StringLength(500)]
        public string Fullname { get; set; }
    }
}

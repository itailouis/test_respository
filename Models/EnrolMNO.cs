namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EnrolMNOs")]
    public partial class EnrolMNO
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(50)]
        public string MNO_Code { get; set; }

        [StringLength(50)]
        public string FullCoName { get; set; }

        [StringLength(50)]
        public string ContactPerson { get; set; }

        [StringLength(50)]
        public string ContactEmail { get; set; }

        [StringLength(50)]
        public string ContactNumber { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? OnTempKey { get; set; }

        public bool? UserStatus { get; set; }

        [StringLength(50)]
        public string WalletName { get; set; }

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

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoginAudit")]
    public partial class LoginAudit
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal idkey { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] LoginTime { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime LoginDate { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool LoginStatus { get; set; }

        [StringLength(4000)]
        public string AddressLocation { get; set; }

        [StringLength(4000)]
        public string AccessMode { get; set; }
    }
}

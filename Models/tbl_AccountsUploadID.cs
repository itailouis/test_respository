namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AccountsUploadID
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal UploadID { get; set; }

        [StringLength(50)]
        public string BrokerCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UploadDate { get; set; }

        [StringLength(50)]
        public string UploadedBy { get; set; }
    }
}

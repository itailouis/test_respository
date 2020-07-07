namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankResponses")]
    public partial class BankRespons
    {
        [StringLength(50)]
        public string ReferenceNumber { get; set; }

        [StringLength(50)]
        public string AccountNo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Balance { get; set; }

        public DateTime? TimeNew { get; set; }

        public DateTime? FinTime { get; set; }

        [Key]
        public int msgid { get; set; }
    }
}

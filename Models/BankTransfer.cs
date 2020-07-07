namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankTransfer
    {
        [StringLength(50)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? TimeNew { get; set; }

        public DateTime? FinTime { get; set; }

        [Key]
        public int msgid { get; set; }
    }
}

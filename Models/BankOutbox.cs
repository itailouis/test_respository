namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BankOutbox")]
    public partial class BankOutbox
    {
        [StringLength(50)]
        public string TransRef { get; set; }

        [StringLength(50)]
        public string BankBIC { get; set; }

        [StringLength(50)]
        public string AccountID { get; set; }

        [StringLength(50)]
        public string MsgStatus { get; set; }

        [StringLength(50)]
        public string MessageType { get; set; }

        [StringLength(50)]
        public string Amount { get; set; }

        public DateTime? TimeNew { get; set; }

        public DateTime? FinTime { get; set; }

        [Key]
        public int msgid { get; set; }
    }
}

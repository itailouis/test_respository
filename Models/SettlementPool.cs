namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SettlementPool")]
    public partial class SettlementPool
    {
        [Key]
        public int EntryID { get; set; }

        [StringLength(50)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string SettlementRef { get; set; }

        [StringLength(50)]
        public string Broker { get; set; }

        [StringLength(50)]
        public string TradeType { get; set; }

        [StringLength(50)]
        public string Investor { get; set; }

        public double? Amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NumberofShares { get; set; }

        public double? Price { get; set; }

        [StringLength(50)]
        public string BrokerBIC { get; set; }

        [StringLength(50)]
        public string BrokerBankAcc { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string BankApproved { get; set; }

        [StringLength(50)]
        public string SharesApproved { get; set; }

        public bool? Settled { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TranDate { get; set; }

        public TimeSpan? TranTime { get; set; }

        public TimeSpan? BankTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BankDate { get; set; }

        [StringLength(50)]
        public string Narration { get; set; }

        [StringLength(50)]
        public string MessageType { get; set; }

        [StringLength(50)]
        public string MessageDirection { get; set; }
    }
}

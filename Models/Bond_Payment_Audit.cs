namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bond_Payment_Audit
    {
        [Key]
        public int ID_ { get; set; }

        [StringLength(50)]
        public string Bank { get; set; }

        [StringLength(50)]
        public string Branch { get; set; }

        [StringLength(50)]
        public string Accountnumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? No_of_Notes_Applied { get; set; }

        [Column(TypeName = "money")]
        public decimal? AmountPaid { get; set; }

        [StringLength(50)]
        public string PaymentRefNo { get; set; }

        [StringLength(50)]
        public string ClientType { get; set; }

        [StringLength(50)]
        public string BrokerReference { get; set; }

        [StringLength(50)]
        public string DividendDisposalPreference { get; set; }

        [StringLength(50)]
        public string MNO_ { get; set; }

        public DateTime? Date_Created { get; set; }

        [StringLength(50)]
        public string Identification { get; set; }

        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        [StringLength(50)]
        public string CDSC_Number { get; set; }

        [StringLength(50)]
        public string ReceiptNumber { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Custodian { get; set; }

        [StringLength(100)]
        public string TransNum { get; set; }

        [StringLength(500)]
        public string PledgeIndicator { get; set; }

        [StringLength(500)]
        public string PledgeeBPID { get; set; }
    }
}

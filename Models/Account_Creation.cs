namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Creation
    {
        [Key]
        public int ID_ { get; set; }

        public int? RecordType { get; set; }

        [StringLength(50)]
        public string ClientSuffix { get; set; }

        [StringLength(50)]
        public string JointAcc { get; set; }

        [StringLength(50)]
        public string Identification { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Initials { get; set; }

        [StringLength(50)]
        public string OtherNames { get; set; }

        [StringLength(50)]
        public string Surname_CompanyName { get; set; }

        [StringLength(50)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string Address3 { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        [StringLength(50)]
        public string PostCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string FaxNumber { get; set; }

        [StringLength(50)]
        public string Emailaddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateofBirth_Incorporation { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(50)]
        public string Resident { get; set; }

        public int? TaxBracket { get; set; }

        [StringLength(50)]
        public string TelephoneNumber { get; set; }

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
        public string CDSC_Number { get; set; }

        public int? Notification_Sent { get; set; }

        [StringLength(50)]
        public string Callback_Endpoint { get; set; }

        [StringLength(50)]
        public string MNO_ { get; set; }

        public DateTime? Date_Created { get; set; }

        public int? File_Sent_DirectDebt { get; set; }

        public int? File_Sent_AccountCr { get; set; }

        [StringLength(50)]
        public string PIN_No { get; set; }

        [StringLength(50)]
        public string Middlename { get; set; }

        [StringLength(50)]
        public string RNum { get; set; }

        [StringLength(100)]
        public string MNOCustodian { get; set; }

        public bool? Active { get; set; }
    }
}

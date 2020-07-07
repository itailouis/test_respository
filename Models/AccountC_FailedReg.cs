namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AccountC_FailedReg
    {
        [Key]
        public int ID_ { get; set; }

        public int? RecordType { get; set; }

        public string ClientSuffix { get; set; }

        public string JointAcc { get; set; }

        public string Identification { get; set; }

        public string Title { get; set; }

        public string Initials { get; set; }

        public string OtherNames { get; set; }

        public string Surname_CompanyName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }

        public string FaxNumber { get; set; }

        public string Emailaddress { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateofBirth_Incorporation { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string Resident { get; set; }

        public int? TaxBracket { get; set; }

        public string TelephoneNumber { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }

        public string Accountnumber { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? No_of_Notes_Applied { get; set; }

        [Column(TypeName = "money")]
        public decimal? AmountPaid { get; set; }

        public string PaymentRefNo { get; set; }

        public string ClientType { get; set; }

        public string BrokerReference { get; set; }

        public string DividendDisposalPreference { get; set; }

        public string CDSC_Number { get; set; }

        public int? Notification_Sent { get; set; }

        public string Callback_Endpoint { get; set; }

        public string MNO_ { get; set; }

        public DateTime? Date_Created { get; set; }

        public int? File_Sent_DirectDebt { get; set; }

        public int? File_Sent_AccountCr { get; set; }

        public string PIN_No { get; set; }

        public string Middlename { get; set; }

        public string RNum { get; set; }

        public string Reason { get; set; }
    }
}

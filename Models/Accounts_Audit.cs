namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Audit
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string CDS_Number { get; set; }

        [StringLength(50)]
        public string BrokerCode { get; set; }

        [StringLength(50)]
        public string AccountType { get; set; }

        [StringLength(500)]
        public string Surname { get; set; }

        [StringLength(500)]
        public string Middlename { get; set; }

        [StringLength(500)]
        public string Forenames { get; set; }

        [StringLength(50)]
        public string Initials { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string IDNoPP { get; set; }

        [StringLength(50)]
        public string IDtype { get; set; }

        [StringLength(500)]
        public string Nationality { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(4000)]
        public string Add_1 { get; set; }

        [StringLength(4000)]
        public string Add_2 { get; set; }

        [StringLength(4000)]
        public string Add_3 { get; set; }

        [StringLength(4000)]
        public string Add_4 { get; set; }

        [StringLength(500)]
        public string Country { get; set; }

        [StringLength(400)]
        public string City { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Custodian { get; set; }

        [StringLength(50)]
        public string TradingStatus { get; set; }

        [StringLength(50)]
        public string Industry { get; set; }

        [StringLength(50)]
        public string Tax { get; set; }

        [StringLength(4000)]
        public string Div_Bank { get; set; }

        [StringLength(4000)]
        public string Div_Branch { get; set; }

        [StringLength(4000)]
        public string Div_AccountNo { get; set; }

        [StringLength(500)]
        public string Cash_Bank { get; set; }

        [StringLength(500)]
        public string Cash_Branch { get; set; }

        [StringLength(500)]
        public string Cash_AccountNo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Client_Image { get; set; }

        [Column(TypeName = "image")]
        public byte[] Documents { get; set; }

        [Column(TypeName = "image")]
        public byte[] BioMatrix { get; set; }

        [StringLength(4000)]
        public string Attached_Documents { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_Created { get; set; }

        [StringLength(50)]
        public string Update_Type { get; set; }

        [StringLength(50)]
        public string Created_By { get; set; }

        [StringLength(50)]
        public string AuthorizationState { get; set; }

        [StringLength(4000)]
        public string Comments { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? VerificationCode { get; set; }

        [StringLength(250)]
        public string DivPayee { get; set; }

        [StringLength(250)]
        public string SettlementPayee { get; set; }

        [StringLength(35)]
        public string idnopp2 { get; set; }

        [StringLength(35)]
        public string idtype2 { get; set; }

        [StringLength(20)]
        public string client_image2 { get; set; }

        [StringLength(20)]
        public string documents2 { get; set; }

        [StringLength(30)]
        public string isin { get; set; }

        [StringLength(30)]
        public string company_code { get; set; }

        [StringLength(50)]
        public string mobile_money { get; set; }

        [StringLength(50)]
        public string mobile_number { get; set; }
    }
}

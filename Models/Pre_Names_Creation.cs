namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pre_Names_Creation
    {
        public int id { get; set; }
        public decimal shareholder { get; set; }
        public string BrokerCode { get; set; }
        public string CDS_number { get; set; }
        public string Surname { get; set; }
        public string Forenames { get; set; }
        public string IDpp { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Add_1 { get; set; }
        public string Add_2 { get; set; }
        public string Add_3 { get; set; }
        public string Add_4 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Bank_Name { get; set; }
        public string Bank_Code { get; set; }
        public string Branch_Name { get; set; }
        public string Branch_Code { get; set; }
        public string Account { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<bool> Mandate { get; set; }
        public Nullable<bool> HFC { get; set; }
        public Nullable<bool> Locked { get; set; }
        public string Updated_By { get; set; }
        public Nullable<System.DateTime> Update_On { get; set; }
        public string Industry { get; set; }
        public decimal Approved { get; set; }
        public string Approved_By { get; set; }
        public Nullable<System.DateTime> Approved_On { get; set; }
        public string Holder_type { get; set; }
        public string RecType { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string PostalCode { get; set; }
        public string ImageID { get; set; }
        public string nominee_code { get; set; }
        public string JSurname { get; set; }
        public string JForenames { get; set; }
        public string JEmail { get; set; }
        public string JCell { get; set; }
        public string Nationality { get; set; }
        public string RejectionReason { get; set; }
        public string Old_Shareholder { get; set; }
        public string idimage { get; set; }
        public string sigimage { get; set; }
        public string ActivationCode { get; set; }
    }
}

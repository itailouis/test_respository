namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class name
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [StringLength(50)]
        public string Broker_Code { get; set; }

        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(250)]
        public string Surname { get; set; }

        [StringLength(250)]
        public string Forenames { get; set; }

        [StringLength(500)]
        public string Idpp { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string nominee_code { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Add_1 { get; set; }

        [StringLength(500)]
        public string Add_2 { get; set; }

        [StringLength(500)]
        public string Add_3 { get; set; }

        [StringLength(500)]
        public string Add_4 { get; set; }

        [StringLength(500)]
        public string City { get; set; }

        [StringLength(500)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Cellphone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Bank_Name { get; set; }

        [StringLength(500)]
        public string Bank_Code { get; set; }

        [StringLength(500)]
        public string Branch_Name { get; set; }

        [StringLength(500)]
        public string Branch_Code { get; set; }

        [StringLength(50)]
        public string Account_Type { get; set; }

        [StringLength(500)]
        public string Account { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tax { get; set; }

        public bool? Mandate { get; set; }

        public bool? hfc { get; set; }

        public bool? Locked { get; set; }

        [StringLength(50)]
        public string updated_by { get; set; }

        public DateTime? updated_on { get; set; }

        [StringLength(50)]
        public string Industry { get; set; }

        public bool? Approved { get; set; }

        [StringLength(50)]
        public string Approved_by { get; set; }

        public DateTime? Approved_on { get; set; }

        [StringLength(50)]
        public string Holder_type { get; set; }

        [StringLength(50)]
        public string ImageID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? accountstate { get; set; }

        [StringLength(50)]
        public string JSurname { get; set; }

        [StringLength(60)]
        public string JForenames { get; set; }

        [StringLength(50)]
        public string JEmail { get; set; }

        [StringLength(50)]
        public string JCell { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [StringLength(50)]
        public string Old_Shareholder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? dormantState { get; set; }
    }
}

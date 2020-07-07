namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemUser
    {
        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string companyCode { get; set; }

        [StringLength(50)]
        public string CompanyType { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Activation { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Trail { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime PasswordExpireyDate { get; set; }

        [StringLength(50)]
        public string Password1 { get; set; }

        [StringLength(50)]
        public string Password2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AuthorizePerm { get; set; }

        [StringLength(50)]
        public string AllocatePermLevel { get; set; }

        [StringLength(50)]
        public string AccountType { get; set; }

        [StringLength(50)]
        public string Forenames { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(50)]
        public string Mobile1 { get; set; }

        [StringLength(50)]
        public string Mobile2 { get; set; }

        [StringLength(50)]
        public string Idnopp { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string gender { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(50)]
        public string ContractType { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [StringLength(50)]
        public string Active_session { get; set; }
    }
}

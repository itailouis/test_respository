namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NamesUpdateAuth")]
    public partial class NamesUpdateAuth
    {
        [Required]
        [StringLength(50)]
        public string UpdatingBroker { get; set; }

        [Required]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Required]
        [StringLength(250)]
        public string Surname { get; set; }

        [StringLength(250)]
        public string Forenames { get; set; }

        [Required]
        [StringLength(50)]
        public string idpp { get; set; }

        [StringLength(250)]
        public string Add_1 { get; set; }

        [StringLength(250)]
        public string Add_2 { get; set; }

        [StringLength(250)]
        public string Add_3 { get; set; }

        [StringLength(250)]
        public string Add_4 { get; set; }

        [Required]
        [StringLength(250)]
        public string City { get; set; }

        [Required]
        [StringLength(250)]
        public string Country { get; set; }

        [StringLength(250)]
        public string Telephone { get; set; }

        [StringLength(250)]
        public string Fax { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Bank_Code { get; set; }

        [StringLength(250)]
        public string Bank_Name { get; set; }

        [StringLength(250)]
        public string Branch_Code { get; set; }

        [StringLength(250)]
        public string Branch_name { get; set; }

        [StringLength(250)]
        public string Account { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Tax { get; set; }

        [Required]
        [StringLength(250)]
        public string Updated_By { get; set; }

        public DateTime Updated_On { get; set; }

        public bool Audit { get; set; }

        [StringLength(250)]
        public string Auditor { get; set; }

        public DateTime Audited_On { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal FKey { get; set; }
    }
}

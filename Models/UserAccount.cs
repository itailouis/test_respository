namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAccount
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string client_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string User_Id { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string User_pass { get; set; }

        [StringLength(50)]
        public string UserLastName { get; set; }

        [StringLength(50)]
        public string UserNames { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Idno { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string SSN { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string company { get; set; }

        [StringLength(50)]
        public string Client_Class { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(50)]
        public string Job_Title { get; set; }

        public bool? Emplymnt { get; set; }

        public bool? Status { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime DateCreated { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string createdby { get; set; }
    }
}

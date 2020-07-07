namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemUsersProfile")]
    public partial class SystemUsersProfile
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IDKEY { get; set; }

        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Forenames { get; set; }

        public DateTime DOB { get; set; }

        [Required]
        [StringLength(50)]
        public string IDPP { get; set; }

        [StringLength(50)]
        public string EmpID { get; set; }

        [Required]
        [StringLength(50)]
        public string BROKERCODE { get; set; }

        [Required]
        [StringLength(50)]
        public string COMPANY { get; set; }

        [Required]
        [StringLength(50)]
        public string DEPARTMENT { get; set; }

        [Required]
        [StringLength(50)]
        public string WPOSITION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TEL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CEL { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(50)]
        public string HOD { get; set; }

        public DateTime DATEOFCREATION { get; set; }

        public short AuditStatus { get; set; }

        [StringLength(50)]
        public string USERROLE { get; set; }
    }
}

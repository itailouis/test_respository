namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserManagement")]
    public partial class UserManagement
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Client_Code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Client_Pass { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string User_Id { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string User_Pass { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Client_Name { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string User_Name { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Department { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string User_Role { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string Date_Created { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(50)]
        public string Created_By { get; set; }
    }
}

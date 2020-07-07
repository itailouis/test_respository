namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("immobilization")]
    public partial class immobilization
    {
        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [StringLength(50)]
        public string cdsnumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Broker_Code { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string ForeNames { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_Number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_Total { get; set; }

        public DateTime? updated_on { get; set; }
    }
}

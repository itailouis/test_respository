namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masttemp")]
    public partial class masttemp
    {
        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        public DateTime Date_Created { get; set; }

        public TimeSpan Trans_Time { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Required]
        [StringLength(50)]
        public string Update_Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Created_By { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [Required]
        [StringLength(50)]
        public string Source { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Trans_ID { get; set; }

        public bool? DebtSecurity { get; set; }
    }
}

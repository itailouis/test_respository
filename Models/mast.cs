namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mast")]
    public partial class mast
    {
        [Required]
        [StringLength(50)]
        public string company { get; set; }

        [Required]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        public DateTime Date_Created { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] Trans_Time { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Required]
        [StringLength(50)]
        public string Update_Type { get; set; }

        public bool Pladge { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Pledge_Shares { get; set; }

        [Required]
        [StringLength(50)]
        public string Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        [Required]
        [StringLength(50)]
        public string Updated_By { get; set; }

        public bool Locked { get; set; }

        [Required]
        [StringLength(8000)]
        public string Lock_Reason { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Trans_Key { get; set; }

        [StringLength(5000)]
        public string PledgeReason { get; set; }

        [StringLength(50)]
        public string SecType { get; set; }

        [Column("lock")]
        public bool? _lock { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? lockQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? cert { get; set; }
    }
}

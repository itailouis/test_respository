namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tran
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

        [StringLength(100)]
        public string Source { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Trans_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Pledge_shares { get; set; }

        [StringLength(50)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string Instrument { get; set; }
    }

    public class app_version
    {
        [Key]
        public int versionId { get; set; }
        public int versionCode { get; set; }
        public string versionName { get; set; }
        public string versionMessage { get; set; }

    }

    public class CTRADELIMITS
    {
        [Key]
        public int Id { get; set; }
        public string LimitType { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }

    }

    public class Balancess
    {
        public decimal? amt { get; set; }
    }
}

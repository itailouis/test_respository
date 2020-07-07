namespace CDSC.CDSFINSECS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tran
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CDS_Number { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Date_Created { get; set; }

        [Key]
        [Column(Order = 3)]
        public TimeSpan Trans_Time { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal Shares { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Update_Type { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Created_By { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal Batch_Ref { get; set; }

        [StringLength(100)]
        public string Source { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Trans_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Pledge_shares { get; set; }

        [StringLength(50)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string Instrument { get; set; }

        [StringLength(50)]
        public string Broker { get; set; }

        [StringLength(50)]
        public string Custodian { get; set; }
    }
}

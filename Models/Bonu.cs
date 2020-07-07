namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bonu
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short BonusNo { get; set; }

        [StringLength(10)]
        public string BType { get; set; }

        public DateTime? ValDate { get; set; }

        public DateTime? CertDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Allot { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Every { get; set; }

        [StringLength(1)]
        public string BRound { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}

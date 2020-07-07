namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempTransTo")]
    public partial class TempTransTo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string cds_number { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal shares { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal batch_Ref { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime date_of_Capture { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string CapturedBy { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Status { get; set; }

        public bool? DebtSecurity { get; set; }
    }
}

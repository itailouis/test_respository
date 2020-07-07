namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TempTransFrom")]
    public partial class TempTransFrom
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
        [Column(Order = 2)]
        [StringLength(50)]
        public string shares { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal batch_ref { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime date_of_capture { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string capturedBy { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string status { get; set; }

        public bool? DebtSecurity { get; set; }
    }
}

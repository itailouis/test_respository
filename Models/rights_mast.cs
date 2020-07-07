namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rights_mast
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Issue_no { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Origin { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string CDSBroker { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string Source { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shares_held { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rights { get; set; }
    }
}

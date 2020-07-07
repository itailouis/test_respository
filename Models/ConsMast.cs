namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsMast")]
    public partial class ConsMast
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IssueNo { get; set; }

        [StringLength(50)]
        public string Holder { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OldShares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NewShares { get; set; }

        [StringLength(50)]
        public string Ratio { get; set; }
    }
}

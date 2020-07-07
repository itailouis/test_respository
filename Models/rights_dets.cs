namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class rights_dets
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal Issue_no { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal Origin { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal RightsID { get; set; }

        [StringLength(50)]
        public string CDSBroker { get; set; }

        [StringLength(1)]
        public string Source { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? La_No { get; set; }

        public bool? Split { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rights { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Accepted_By { get; set; }

        [StringLength(1)]
        public string Accepted_By_Source { get; set; }

        [StringLength(22)]
        public string Accepted_By_ID { get; set; }

        [StringLength(22)]
        public string Origin_ID { get; set; }

        public long? Batch { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Printed { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool Accepted { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool ThirdPartyAcceptence { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class batch_header
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Batch_ref { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Traded_Shares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Traded_amount { get; set; }

        public DateTime updated_on { get; set; }

        [Required]
        [StringLength(50)]
        public string updated_by { get; set; }

        [StringLength(50)]
        public string status { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_bank
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Required]
        [StringLength(50)]
        public string bank { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string bank_name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Bank_Code { get; set; }

        public bool? eft { get; set; }
    }
}

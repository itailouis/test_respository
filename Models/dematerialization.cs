namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dematerialization")]
    public partial class dematerialization
    {
        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal batch_ref { get; set; }

        [Required]
        [StringLength(50)]
        public string broker_code { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Shareholder { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Forenames { get; set; }

        [StringLength(50)]
        public string Client_type { get; set; }

        [StringLength(50)]
        public string Oldholder { get; set; }

        [StringLength(50)]
        public string Cert { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Shares { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Status { get; set; }

        public DateTime? dateCreated { get; set; }
    }
}

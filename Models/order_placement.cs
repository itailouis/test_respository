namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class order_placement
    {
        [StringLength(50)]
        public string Broker_Code { get; set; }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Deal_Number { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Deal_Suffix { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Type { get; set; }

        public DateTime Deal_Date { get; set; }

        public DateTime? Expiry_Date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Client_Acc { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Forenames { get; set; }

        [Required]
        [StringLength(50)]
        public string Client_Type { get; set; }

        [StringLength(50)]
        public string Update_by { get; set; }

        public DateTime? Update_on { get; set; }

        public bool? Status { get; set; }
    }
}

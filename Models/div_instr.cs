namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class div_instr
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string company { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal div_no { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [StringLength(20)]
        public string div_type { get; set; }

        public DateTime? date_declared { get; set; }

        public DateTime? date_closed { get; set; }

        public DateTime? date_payment { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? rate { get; set; }

        [StringLength(60)]
        public string mess_1 { get; set; }

        [StringLength(40)]
        public string mess_2 { get; set; }

        public bool? scrip_offer { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? scrip_price { get; set; }

        [StringLength(1)]
        public string scrip_round { get; set; }

        [StringLength(40)]
        public string comment { get; set; }

        [StringLength(40)]
        public string entered_by { get; set; }

        public bool? eft_allowed { get; set; }

        public bool? ScripBeforeTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? bank_accNo { get; set; }

        public DateTime? date_Yearending { get; set; }

        public DateTime? Instruction_Date { get; set; }
    }
}

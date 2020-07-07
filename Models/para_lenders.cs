namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_lenders
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ParticipantID { get; set; }

        public bool? AllowBorrowing { get; set; }

        public bool? AllowLending { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? BorrowingLimit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? LendingLimit { get; set; }

        public bool? limitBorrows { get; set; }

        public bool? limitLends { get; set; }
    }
}

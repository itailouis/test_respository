namespace CDSC.CDS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanctionedList")]
    public partial class SanctionedList
    {
        [StringLength(100)]
        public string names { get; set; }

        [StringLength(100)]
        public string surname { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(100)]
        public string birthdate { get; set; }

        [StringLength(100)]
        public string national_id { get; set; }

        [StringLength(100)]
        public string nationality { get; set; }

        [StringLength(100)]
        public string passport_number { get; set; }

        [StringLength(100)]
        public string account_type { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounts_Joint
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(50)]
        public string Forenames { get; set; }

        [StringLength(50)]
        public string IDNo { get; set; }

        [StringLength(50)]
        public string IDType { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string CDSNo { get; set; }

        [StringLength(30)]
        public string email { get; set; }
    }
}

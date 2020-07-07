namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_country
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string fnam { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }
    }
}

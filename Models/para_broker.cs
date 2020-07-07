namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_broker
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string broker_code { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(150)]
        public string fnam { get; set; }

        [StringLength(150)]
        public string CompanyType { get; set; }

        [StringLength(350)]
        public string Address { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(250)]
        public string reason { get; set; }

        [StringLength(250)]
        public string clearing_account { get; set; }

        [StringLength(410)]
        public string comments { get; set; }
    }
}

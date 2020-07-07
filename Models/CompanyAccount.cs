namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyAccount
    {
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string CompanyType { get; set; }

        [Key]
        public bool Activation { get; set; }

        [StringLength(50)]
        public string Company_Code { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class accounts_classes
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [Column("class")]
        [StringLength(50)]
        public string _class { get; set; }

        [StringLength(250)]
        public string reason { get; set; }
    }
}

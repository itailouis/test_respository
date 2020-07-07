namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class extension
    {
        public int id { get; set; }

        [StringLength(50)]
        public string cds_number { get; set; }

        [StringLength(50)]
        public string doc { get; set; }

        [StringLength(50)]
        public string image { get; set; }
    }
}

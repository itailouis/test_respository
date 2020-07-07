namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_brokerclasses
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Broker { get; set; }

        [StringLength(50)]
        public string Class_name { get; set; }

        [StringLength(50)]
        public string Class_code { get; set; }

        public string Description { get; set; }
    }
}

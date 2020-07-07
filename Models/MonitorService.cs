namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonitorService
    {
        [Key]
        public int ID_ { get; set; }

        [StringLength(100)]
        public string Service_Description { get; set; }

        [StringLength(100)]
        public string Service_Name { get; set; }
    }
}

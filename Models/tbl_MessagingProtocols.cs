namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_MessagingProtocols
    {
        public int id { get; set; }

        [StringLength(50)]
        public string MessagingPlatform { get; set; }

        [StringLength(50)]
        public string PlatformType { get; set; }

        [StringLength(50)]
        public string MessageFormat { get; set; }

        [StringLength(500)]
        public string FormatDescription { get; set; }
    }
}

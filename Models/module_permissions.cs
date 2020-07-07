namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class module_permissions
    {
        public int id { get; set; }

        public int? moduleid { get; set; }

        public int? roleid { get; set; }
    }
}

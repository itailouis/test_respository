namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PermissionsList
    {
        public int id { get; set; }

        [StringLength(400)]
        public string PermissionType { get; set; }

        [StringLength(50)]
        public string PermissionValue { get; set; }

        [StringLength(50)]
        public string Role { get; set; }
    }
}

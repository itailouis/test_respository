namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modules_Roles
    {
        [Key]
        public int Role_id { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        [StringLength(50)]
        public string Type { get; set; }
    }
}

namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MASTER_ROLES
    {
        [Key]
        [Column(Order = 0)]
        public int RoleID { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool USER_STATUS { get; set; }

        public DateTime? USER_CREATED_DATE { get; set; }

        [StringLength(50)]
        public string USER_CREATED_BY { get; set; }

        [StringLength(50)]
        public string USER_MODIFIED_BY { get; set; }

        public DateTime? USER_MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string ROLE_DESCRIPTION { get; set; }
    }
}

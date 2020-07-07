namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MASTER_PERMISSIONS
    {
        public int ID { get; set; }

        public int RoleID { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }

        public int ModuleID { get; set; }

        [StringLength(50)]
        public string ModuleName { get; set; }

        [StringLength(1)]
        public string ALW_View { get; set; }

        [StringLength(1)]
        public string ALW_Add { get; set; }

        [StringLength(1)]
        public string ALW_Edit { get; set; }

        [StringLength(1)]
        public string ALW_Delete { get; set; }

        public DateTime? CREATED_DATE { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }

        [StringLength(50)]
        public string MODIFIED_BY { get; set; }

        [StringLength(50)]
        public string URL_NAME { get; set; }

        [StringLength(50)]
        public string ORDERING { get; set; }
    }
}

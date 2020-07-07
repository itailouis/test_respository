namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_IdentityDocuments
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TYPE { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}

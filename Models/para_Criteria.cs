namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class para_Criteria
    {
        [Key]
        [Column("int")]
        public int _int { get; set; }

        [StringLength(50)]
        public string CriteriaName { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}

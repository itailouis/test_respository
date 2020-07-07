namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Para_Batch_Type_Tsec
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Batch_Type { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BatchName { get; set; }
    }
}

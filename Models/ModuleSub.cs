namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ModuleSub
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int ModuleID { get; set; }

        [StringLength(70)]
        public string url { get; set; }

        [StringLength(100)]
        public string folder { get; set; }

        [StringLength(70)]
        public string user_type { get; set; }

        public virtual Module Module { get; set; }
    }
}

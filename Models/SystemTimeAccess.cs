namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemTimeAccess")]
    public partial class SystemTimeAccess
    {
        [Key]
        public int UpdateID { get; set; }

        public TimeSpan? SystemUptime { get; set; }

        public TimeSpan? SystemDownTime { get; set; }

        [StringLength(50)]
        public string LoginScope { get; set; }

        public int? ActivationState { get; set; }
    }
}

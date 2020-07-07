namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("confirmationsOutbox")]
    public partial class confirmationsOutbox
    {
        [StringLength(50)]
        public string REFERENCE { get; set; }

        [StringLength(50)]
        public string BROKER { get; set; }

        [StringLength(50)]
        public string TRADEPARTY { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string CONFIRMTYPE { get; set; }

        [StringLength(50)]
        public string CONFIRMDET { get; set; }

        [StringLength(50)]
        public string STATUS { get; set; }

        public DateTime? TIMENEW { get; set; }

        public DateTime? FINTIME { get; set; }

        [StringLength(50)]
        public string BROKEREMAIL { get; set; }

        [Key]
        public int msgid { get; set; }
    }
}

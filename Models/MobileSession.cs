namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MobileSession
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Input { get; set; }

        [StringLength(50)]
        public string NewRequest { get; set; }

        [StringLength(50)]
        public string CurrentMenu { get; set; }

        [StringLength(50)]
        public string NextMenu { get; set; }

        [StringLength(50)]
        public string Msisdn { get; set; }

        [StringLength(50)]
        public string SessionId { get; set; }

        [StringLength(4000)]
        public string Response { get; set; }

        public DateTime? Date { get; set; }
    }
}

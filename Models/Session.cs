namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Session
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Input { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string CurrentMenu { get; set; }

        [StringLength(50)]
        public string NextMenu { get; set; }

        [StringLength(50)]
        public string SessionId { get; set; }

        public DateTime? Date { get; set; }
    }
}

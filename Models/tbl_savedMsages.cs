namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_savedMsages
    {
        public int id { get; set; }

        [StringLength(4000)]
        public string ReceivedMsg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datereceived { get; set; }
    }
}

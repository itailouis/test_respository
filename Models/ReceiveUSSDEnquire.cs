namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReceiveUSSDEnquire")]
    public partial class ReceiveUSSDEnquire
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Reference_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string PerformFxn { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string CDS_Number { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date_Created { get; set; }
    }
}

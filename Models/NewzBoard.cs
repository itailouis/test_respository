namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewzBoard")]
    public partial class NewzBoard
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string audience { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8000)]
        public string Newz { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Post_By { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime Date_Of_Post { get; set; }
    }
}

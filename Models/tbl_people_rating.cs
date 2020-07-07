namespace CDSC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_people_rating
    {
        public int id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? QuestionNo { get; set; }

        [StringLength(4000)]
        public string QuestionData { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalSection { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IndividualWeight { get; set; }

        [StringLength(4000)]
        public string comment { get; set; }
    }
}

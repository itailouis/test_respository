using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    [Table("para_company")]
    public class paraCompanyCds
    {

        public int Id { get; set; }

        [StringLength(255)]
        public string Company { get; set; }

        public string Fnam { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Date_created { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Issued_shares { get; set; }

        public bool? Status { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDS_Ac_No { get; set; }

        [StringLength(100)]
        public string registrar { get; set; }

        [StringLength(100)]
        public string Add_1 { get; set; }

        [StringLength(100)]
        public string Add_2 { get; set; }

        [StringLength(100)]
        public string Add_3 { get; set; }

        [StringLength(100)]
        public string Add_4 { get; set; }


        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }
        

        [StringLength(50)]
        public string Contact_Person { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Cellphone { get; set; }



        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }


        [StringLength(50)]
        public string board { get; set; }

        [StringLength(200)]
        public string Index_Type { get; set; }


        [StringLength(50)]
        public string ISIN { get; set; }

        [StringLength(255)]
        public string Email { get; set; }
    }
}
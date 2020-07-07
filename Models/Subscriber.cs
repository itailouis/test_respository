using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class Vatenkecis
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public string CdsNumber { get; set; }
        
        public DateTime Date { get; set; }
    }
    public class VatenkeciNew
    {
        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string cds { get; set; }
        public string broker { get; set; }
        public bool Active { get; set; }


    }

    public class VatenkeciNewV2
    {
        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string cds { get; set; }
        public string broker { get; set; }
        public string min_value_threshold { get; set; }

        public string has_company { get; set; }
        public string Active { get; set; }
    }

    public partial class club_members
    {
        public int id { get; set; }
        public string club_phone { get; set; }
        public Nullable<bool> confirmed { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string member_cds_number { get; set; }
        public string member_phone { get; set; }
        public string member_email { get; set; }
        public Nullable<bool> rejected{ get; set; }
        public Nullable<System.DateTime> confirmation_date { get; set; }
        public int club_id { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string cdsnumber { get; set; }
    }

    public partial class investment_club
    {
        public int id { get; set; }
        public string chairman_id { get; set; }
        public string club_member_num { get; set; }
        public string club_name { get; set; }
        public string club_phone { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string phone { get; set; }
        public Nullable<bool> Active { get; set; }
        public string club_cds_number { get; set; }
    }

    public partial class investment_club_session
    {
        public int id { get; set; }
        public string chairman_id { get; set; }
        public string club_member_num { get; set; }
        public string club_name { get; set; }
        public string club_phone { get; set; }
        public Nullable<System.DateTime> created_date { get; set; }
        public string member_cds_number { get; set; }
        public string member_phone { get; set; }
        public string phone { get; set; }
    }
    public class investments_club_two
    {
        public int id { get; set; }
        public string chairman_id { get; set; }
        public string club_member_num { get; set; }
        public string club_name { get; set; }
        public string club_phone { get; set; }
        public string created_date { get; set; }
        public string phone { get; set; }
        public bool Active { get; set; }
        public string club_cds_number { get; set; }
    }
}
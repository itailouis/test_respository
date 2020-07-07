using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Helpers;
//using System.Net.Mail;
using System.Web.Mvc;
using CDSC.Migrations;
using CDSC.Models;
using CDSC.CDS;
using Vatenkecis = CDSC.Models.Vatenkecis;
using System.Security.Cryptography;
using System.Globalization;
using System.Net.Http;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Exceptions;
using CDSC.CERTS;
using CDSC.CDSFINSECS;
using System.Xml;
using System.Data.Entity;

namespace CDSC.Controllers
{
    public class SubscriberController : Controller
    {


        public string index() {

            return "test me ";
        }
        readonly cdscDbContext _cdscDbContext = new cdscDbContext();
        readonly CdDataContext _cdDataContext = new CdDataContext();
        readonly AtsDbContext _AtsDbContext = new AtsDbContext();
        readonly FINSEC cDSFINSEC = new FINSEC();
        readonly CERT cERT = new CERT();
        string connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
        string connectionStringATS = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
        readonly CDS.CDS _cdsDataContext = new CDS.CDS();
        private static readonly HttpClient client = new HttpClient();


        public JsonResult getGroupShareholdings(string cds_number, string group_cds_number)
        {


            var sql = "select  I.cds_number, I.groupid, I.company,sum(i.shares) as Mine, (select sum(shares) from trans_groups where company=i.company and groupid='" + group_cds_number + "') as [GroupTotal],sum(i.shares)/(select sum(shares) from trans_groups where company=i.company and groupid='" + group_cds_number + "')*100 as [MyPercentage]  from trans_groups i where i.cds_number='" + cds_number + "' and i.groupid='"+ group_cds_number + "'   group by i.company, i.groupid, i.cds_number ";

            var shareAllocations = new List<ShareAllocation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //string password = rdr["Password"].ToString();
                    //int id = int.Parse(rdr["Id"].ToString());
                    ShareAllocation shareAllocation = new ShareAllocation
                    {
                        MyPercentage = rdr["MyPercentage"].ToString(),
                        GroupTotal = rdr["GroupTotal"].ToString(),
                        Mine = rdr["Mine"].ToString(),
                        Company = rdr["company"].ToString()


                    };
                    shareAllocations.Add(shareAllocation);


                }

                connection.Close();
            }
            
            return Json(shareAllocations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CashTranGroup(string cdsNumber )
        {

            var sql = " select A.Email, A.FullName,A.CdsNumber,C.Amount ,C.DateCreated, C.TransType from CDSC.dbo.Vatenkecis A JOIN CDSC.dbo.CashTransGroups C ON A.CdsNumber=C.CDS_Number WHERE C.CDS_NumberGroup='" + cdsNumber + "'";

            var suserTrans = new List<CashListTransGroup>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    CashListTransGroup shareAllocation = new CashListTransGroup
                    {
                        Email= rdr["Email"].ToString(),
                        FullName= rdr["FullName"].ToString(),
                        TransType = rdr["TransType"].ToString(),
                        Amount = rdr["Amount"].ToString(),
                        CdsNumber = rdr["CdsNumber"].ToString(),
                        DateCreated= rdr["DateCreated"].ToString()


                    };
                    suserTrans.Add(shareAllocation);


                }

                connection.Close();
            }



            return Json(suserTrans, JsonRequestBehavior.AllowGet);
        }


        public JsonResult MyCashTranGroup(string cdsNumber, string groupcdsNumber)
        {

            var sql = " select A.Email, A.FullName,A.CdsNumber,C.Amount ,C.DateCreated, C.TransType from CDSC.dbo.Vatenkecis A JOIN CDSC.dbo.CashTransGroups C ON A.CdsNumber=C.CDS_Number WHERE C.CDS_NumberGroup='" + groupcdsNumber + "' and C.CDS_Number= '"+ cdsNumber + "'";

            var suserTrans = new List<CashListTransGroup>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    CashListTransGroup shareAllocation = new CashListTransGroup
                    {
                        Email = rdr["Email"].ToString(),
                        FullName = rdr["FullName"].ToString(),
                        TransType = rdr["TransType"].ToString(),
                        Amount = rdr["Amount"].ToString(),
                        CdsNumber = rdr["CdsNumber"].ToString(),
                        DateCreated = rdr["DateCreated"].ToString()


                    };
                    suserTrans.Add(shareAllocation);


                }

                connection.Close();
            }



            return Json(suserTrans, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClublistMembersWithEmail(int clubid)
        {
            var sql = " select [CDSC].[dbo].club_members.* , [CDSC].[dbo].Vatenkecis.FullName from [CDSC].[dbo].club_members left join  [CDSC].[dbo].Vatenkecis on [CDSC].[dbo].Vatenkecis.Email=club_members.member_email  where   club_members.club_id='" + clubid + "'";

            var suserTrans = new List<ClubMembers>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    ClubMembers shareAllocation = new ClubMembers
                    {
                        club_phone = rdr["club_phone"].ToString(),
                        FullName = rdr["FullName"].ToString(),
                        member_cds_number = rdr["member_cds_number"].ToString(),
                        member_phone = rdr["member_phone"].ToString(),
                        member_email = rdr["member_email"].ToString(),
                        confirmation_date = rdr["confirmation_date"].ToString(),
                        Surname = rdr["Surname"].ToString(),
                        cdsnumber = rdr["cdsnumber"].ToString(),
                        Firstname = rdr["Firstname"].ToString()
                        


                    };
                    suserTrans.Add(shareAllocation);


                }

                connection.Close();
            }
            return Json(suserTrans, JsonRequestBehavior.AllowGet);

        }


        public JsonResult sendNotificationToGroup(String CDS_NumberGroup, String notification , String id=null) {
            var tempDbContext = new cdscDbContext();
            var message = "";
            

            if (id!=null)
            {

                long n_id = long.Parse(id);
                NotificationGroup notificationGroup= tempDbContext.NotificationGroup.Single(b => b.ID == n_id);


                notificationGroup.Notification = notification;
                tempDbContext.NotificationGroup.AddOrUpdate(notificationGroup);
                tempDbContext.SaveChanges();
                message = "Edited Successfully";


            }
            else {
                NotificationGroup notificationGroup = new NotificationGroup {
                Notification = notification,
                CDS_NumberGroup= CDS_NumberGroup,
                DateCreated = DateTime.Now

            };
                message = "notification Added Successfully";
                tempDbContext.NotificationGroup.Add(notificationGroup);
                tempDbContext.SaveChanges();
            }

            return Json(message, JsonRequestBehavior.AllowGet);

        }

        public JsonResult deleteNotificationToGroup(String id) {
            var tempDbContext = new cdscDbContext();
            long n_id = long.Parse(id);
            NotificationGroup notificationGroup = tempDbContext.NotificationGroup.Single(b => b.ID == n_id);
            tempDbContext.NotificationGroup.Remove(notificationGroup);
            tempDbContext.SaveChanges();

            return Json("deleted  Successfully", JsonRequestBehavior.AllowGet);
        }






        public JsonResult getNotificationToGroup(String CDS_NumberGroup)
        {
            var tempDbContext = new cdscDbContext();
            var notifications = new List<NotificationGroupReturn>();
            var sql = "SELECT *  FROM[CDSC].[dbo].[NotificationGroups] where CDS_NumberGroup= '"+ CDS_NumberGroup + "'";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NotificationGroupReturn notificationGroup = new NotificationGroupReturn
                    {
                        ID = long.Parse(rdr["ID"].ToString()),
                        Notification = rdr["Notification"].ToString(),
                        CDS_NumberGroup = rdr["CDS_NumberGroup"].ToString(),
                        DateCreated = DateTime.Parse(rdr["DateCreated"].ToString()).ToString("dd MMM yyyy")

                    };
                    notifications.Add(notificationGroup);


                }

                connection.Close();
            }

           
         

            return Json(notifications, JsonRequestBehavior.AllowGet);

        }



        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }

        public static string EncryptIt(string theText)
        {
            int i = theText.Length;
            string theEncrypteOne = "";

            int j;
            for (j = 0; j < i; j++)
                theEncrypteOne += Strings.ChrW((Strings.AscW(theText.Substring(j, 1)) - 10));
            string EncryptIt = theEncrypteOne;
            return EncryptIt;
        }

        public JsonResult VatenkeciLoginSecure(string idNumber, string pass)
        {
            var cdDataContexts = new cdscDbContext();

            string encryptedPassword = EncryptIt(pass.Trim());

            var usernameFound = cdDataContexts.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == idNumber.Trim() || x.CdsNumber.Trim() == idNumber.Trim()) && x.Password == encryptedPassword);

            if (usernameFound != null)
            {
                if (usernameFound.Active == false)
                {
                    return Json(8, JsonRequestBehavior.AllowGet);
                }
                //                return Json("2", JsonRequestBehavior.AllowGet);
                var user = _cdDataContext.Accounts_Clients.FirstOrDefault(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()));
                if (user != null)
                {
                    Random generator = new Random();
                    string GenerateRandomNo = generator.Next(1, 10000).ToString("D4");
                    string getstatus_ = testAccountinJoint(idNumber);
                    var rets =
                        _cdDataContext.Accounts_Clients.Where(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()))
                            .OrderByDescending(x => x.ID)
                            .Select(c => new
                            {
                                id = c.CDS_Number,
                                brokerName = c.Custodian,
                                broker = c.BrokerCode,
                                cds = c.CDS_Number,
                                email = usernameFound.Email,
                                name = c.Surname + " " + c.Forenames,
                                phone = c.Mobile,
                                pin = GenerateRandomNo,
                                has_company = getstatus_
                            });

                    String sqlx = "";
                    foreach (var p in rets)
                    {

                        var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                        sqlx = "Update Vatenkecis set PIN ='" + GenerateRandomNo + "' where CdsNumber='" + p.cds.ToString() + "' ";
                        using (SqlConnection connectionsx = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                            connectionsx.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                        //connectionsx.Close();
                        break;
                    }
                    try
                    {
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        client.Timeout = 30000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        //client.Credentials = new System.Net.NetworkCredential("mobilectrade@gmail.com", "asdfghjkl2017");
                        client.Credentials = new System.Net.NetworkCredential("no-reply@ctrade.co.zw", "asdfghjkl2018");
                        MailMessage mm = new MailMessage();
                        mm.BodyEncoding = Encoding.UTF8;
                        mm.From = new MailAddress("no-reply@ctrade.co.zw");
                        mm.To.Add(user.Email);
                        mm.Subject = "C-TRADE Mobile OTP";
                        mm.Body = "Your OTP is " + GenerateRandomNo;
                        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        client.Send(mm);
                        return Json(rets, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        return Json("Error sending OTP Please try again", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("No email in accounts creation", JsonRequestBehavior.AllowGet);
            }
            //1. Checking from Accounts_Creation
            return Json("No email in registrations", JsonRequestBehavior.AllowGet);
        }

        public string EncryptPasswords()
        {
            string result = "done";

            var sql = "select * from [CDSC].[dbo].[Vatenkecis]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string password = rdr["Password"].ToString();
                    int id = int.Parse(rdr["Id"].ToString());

                    string sqlx = "Update [CDSC].[dbo].[Vatenkecis] set Password = @password where id = @id";
                    using (SqlConnection connectionsx = new SqlConnection(connectionString))
                    {
                        SqlCommand cmdU = new SqlCommand(sqlx, connectionsx)
                        {
                            CommandType = CommandType.Text
                        };
                        cmdU.Parameters.AddWithValue("@password", EncryptIt(password));
                        cmdU.Parameters.AddWithValue("@id", id);
                        cmdU.CommandTimeout = 0;
                        connectionsx.Open();
                        cmdU.ExecuteNonQuery();
                        connectionsx.Close();

                    }
                }

                connection.Close();
            }

            return result;
        }

        public string PostAmmendOrder(string ordernumber, string nprice = null, string nquantity = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");

            try
            {
                var list = new List<Pre_Order_Live>();
                Pre_Order_Live orderLiveObj = new Pre_Order_Live();
                int orderNo = int.Parse(ordernumber);

                var sql =
                    "select * FROM [testcds_ROUTER].[dbo].[Pre_Order_Live] where orderNo = '" + ordernumber + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        orderLiveObj.Company = rdr["Company"].ToString();
                        orderLiveObj.OrderType = rdr["OrderType"].ToString();
                        orderLiveObj.CDS_AC_No = rdr["CDS_AC_No"].ToString();
                        orderLiveObj.Broker_Code = rdr["Broker_Code"].ToString();
                        orderLiveObj.BrokerRef = rdr["BrokerRef"].ToString();
                        orderLiveObj.OrderStatus = rdr["OrderStatus"].ToString();
                        orderLiveObj.OrderNumber = rdr["OrderNumber"].ToString();
                        orderLiveObj.Quantity = int.Parse(rdr["Quantity"].ToString());
                        orderLiveObj.BasePrice = Math.Round(double.Parse(rdr["BasePrice"].ToString()), 4);
                        list.Add(orderLiveObj);
                    }
                }


                if (list.Any())
                {
                    int? ammendQuantity;
                    double? ammendPrice;
                    string returnstring;

                    //Get order quantity and price
                    int? oldQuantity = orderLiveObj.Quantity;
                    double? oldPrice = orderLiveObj.BasePrice;

                    //Check if price has been ammended, if not take old
                    if (string.IsNullOrEmpty(nprice))
                    {
                        ammendPrice = oldPrice;
                    }
                    else
                    {
                        ammendPrice = double.Parse(nprice);
                    }

                    //Check if quantity has been ammended, if not take old
                    if (string.IsNullOrEmpty(nquantity))
                    {
                        ammendQuantity = oldQuantity;
                    }
                    else
                    {
                        ammendQuantity = int.Parse(nquantity);
                    }

                    string sqlx = "insert into CDS_ROUTER.dbo.Orders_Amendments(OrderType, Amount, Notes, CdsNumber, BrokerCode, Company, Price, OrderRef, MatchedQty, MatchedPrice, Status, Sent, Date, PhoneNumber, LPStatus, Custodian, Oldbrokerid, Oldexchangeid) values('" + orderLiveObj.OrderType + "', '" + ammendQuantity + "', '" + ammendQuantity + "', '" + orderLiveObj.CDS_AC_No + "', '" + orderLiveObj.Broker_Code + "', '" + orderLiveObj.Company + "', '" + ammendPrice + "', '" + orderLiveObj.OrderNumber + "', 0, 0, '" + orderLiveObj.OrderStatus + "', 0, GETDATE(), '" + orderLiveObj.CDS_AC_No + "', '" + orderLiveObj.OrderStatus + "', '" + orderLiveObj.Broker_Code + "', '" + orderLiveObj.Broker_Code + "', '" + orderLiveObj.BrokerRef + "')";

                    using (SqlConnection connectionsx = new SqlConnection(connectionStringATS))
                    {
                        SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                        connectionsx.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        returnstring = "Order ammendment request successfully sent.";

                    }
                    return returnstring;
                }
                else
                {
                    return "Order does not exist.";
                }



            }
            catch (Exception ex)
            {
                //return "Error occured please contact support at ctrade@escrowgroup.org";
                return ex.ToString();
            }
        }

        //deleteOrder
        public string DeleteOrder(string cdsnumber, string ordernumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            string sqlx = "Delete from Pre_Order_Live  where OrderNo ='" + ordernumber
                + "' and CDS_AC_No='" + cdsnumber + "' ";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Successfully removed";

            }
            return returnstring;
        }

        public JsonResult CheckWhoRegisteredCtrade(string any)
        {
            var rets = _cdDataContext.Accounts_Clients.FirstOrDefault(x => x.Email.Trim() == any || x.CDS_Number == any.Trim());

            var mobAccount = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Email == any.Trim() || x.CdsNumber == any.Trim());
            if (mobAccount != null)
            {
                if (mobAccount.Active == false)
                {
                    return Json(4, JsonRequestBehavior.AllowGet);//Account not active
                }
                else
                {
                    if (rets != null)
                    {
                        return Json(1, JsonRequestBehavior.AllowGet);//its in cds and not in ctrade
                    }
                    else
                    {
                        if (mobAccount.FullName == null || mobAccount.FullName == "individual")
                        {
                            return Json(3, JsonRequestBehavior.AllowGet);//is company
                        }
                        else
                        {

                            return Json(1, JsonRequestBehavior.AllowGet);//its in  ctrade only

                        }

                    }
                }
            }
            else if (rets != null)
            {
                return Json(2, JsonRequestBehavior.AllowGet);//its in cds and not in ctrade
            }
            else
            {
                //create new account
                return Json(0, JsonRequestBehavior.AllowGet);//its not in either so create
            }

        }

        public JsonResult InvestorRegTest(string idNumber, string pass)
        {
            //            return 
            //            return Json(idNumber + "  " + pass, JsonRequestBehavior.AllowGet);
            //            x => x.Username.Trim() == "rfde@gmail.com" && x.Password.Trim() == "12341234"
            string encryptedPassword = EncryptIt(pass.Trim());

            var cdDataContexts = new cdscDbContext();
            var usernameFound = cdDataContexts.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == idNumber.Trim() || x.CdsNumber.Trim() == idNumber.Trim()) && x.Password == encryptedPassword);

            if (usernameFound != null)
            {
                if (usernameFound.Active == false)
                {
                    return Json(8, JsonRequestBehavior.AllowGet);
                }
                //                return Json("2", JsonRequestBehavior.AllowGet);
                var user = _cdDataContext.Accounts_Clients.FirstOrDefault(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()));
                if (user != null)
                {
                    Random generator = new Random();
                    string GenerateRandomNo = generator.Next(1, 10000).ToString("D4");
                    string getstatus_ = testAccountinJoint(idNumber);
                    var rets =
                        _cdDataContext.Accounts_Clients.Where(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()))
                            .OrderByDescending(x => x.ID)
                            .Select(c => new
                            {
                                id = c.CDS_Number,
                                brokerName = c.Custodian,
                                broker = c.BrokerCode,
                                cds = c.CDS_Number,
                                email = usernameFound.Email,
                                name = c.Surname + " " + c.Forenames,
                                phone = c.Mobile,
                                pin = GenerateRandomNo,
                                has_company = getstatus_
                            });

                    String sqlx = "";
                    foreach (var p in rets)
                    {

                        var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                        sqlx = "Update Vatenkecis set PIN ='" + GenerateRandomNo + "' where CdsNumber='" + p.cds.ToString() + "' ";
                        using (SqlConnection connectionsx = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                            connectionsx.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                        //connectionsx.Close();
                        break;
                    }
                    try
                    {
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        client.Timeout = 30000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        //client.Credentials = new System.Net.NetworkCredential("mobilectrade@gmail.com", "asdfghjkl2017");
                        client.Credentials = new System.Net.NetworkCredential("no-reply@ctrade.co.zw", "asdfghjkl2018");
                        MailMessage mm = new MailMessage();
                        mm.BodyEncoding = Encoding.UTF8;
                        mm.From = new MailAddress("no-reply@ctrade.co.zw");
                        mm.To.Add(user.Email);
                        mm.Subject = "C-TRADE Mobile OTP";
                        mm.Body = "Your OTP is " + GenerateRandomNo;
                        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        client.Send(mm);
                        return Json(rets, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        return Json("Error sending OTP Please try again", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("No email in accounts creation", JsonRequestBehavior.AllowGet);
            }
            //1. Checking from Accounts_Creation
            return Json("No email in registrations", JsonRequestBehavior.AllowGet);
        }
        public JsonResult AuthUser(string idNumber, string pass)
        {
            string encryptedPassword = EncryptIt(pass.Trim());
            var cdDataContexts = new cdscDbContext();
            var usernameFound = cdDataContexts.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == idNumber.Trim() || x.CdsNumber.Trim() == idNumber.Trim()) && x.Password == encryptedPassword);

            if (usernameFound != null)
            {
                if (usernameFound.Active == false)
                {
                    return Json(8, JsonRequestBehavior.AllowGet);
                }
                //                return Json("2", JsonRequestBehavior.AllowGet);
                var user = _cdDataContext.Accounts_Clients.FirstOrDefault(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()));
                if (user != null)
                {
                    Random generator = new Random();
                    string GenerateRandomNo = generator.Next(1, 10000).ToString("D4");
                    string getstatus_ = testAccountinJoint(idNumber);
                    var rets =
                        _cdDataContext.Accounts_Clients.Where(x => (x.CDS_Number.Trim() == usernameFound.CdsNumber.Trim()))
                            .OrderByDescending(x => x.ID)
                            .Select(c => new
                            {
                                id = c.CDS_Number,
                                brokerName = c.Custodian,
                                broker = c.BrokerCode,
                                cds = c.CDS_Number,
                                email = usernameFound.Email,
                                name = c.Surname + " " + c.Forenames,
                                phone = c.Mobile,
                                pin = GenerateRandomNo,
                                has_company = getstatus_
                            });

                    return Json(rets, JsonRequestBehavior.AllowGet);

                }
                //1. Checking from Accounts_Creation
                return Json("No email in registrations", JsonRequestBehavior.AllowGet);
            }

            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketWatchZSE()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql =
                "SELECT * FROM ZSE_market_data";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                    recordSummary.Ticker = rdr["Ticker"].ToString();
                    recordSummary.ISIN = rdr["ISIN"].ToString();
                    recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                    recordSummary.Best_bid = rdr["Best_bid"].ToString();
                    recordSummary.Current_price = rdr["Current_price"].ToString();
                    recordSummary.Ask_Volume = rdr["Ask_Volume"].ToString();
                    recordSummary.Bid_Volume = rdr["Bid_Volume"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetMarketData(string company)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketData>();

            var sql =
                "select top 1 * from testcds_router.dbo.prices where company_name = '" + company + "' and price_turnover > 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketData recordSummary = new MarketData();
                    recordSummary.PriceID = int.Parse(rdr["PriceID"].ToString());
                    recordSummary.company_name = rdr["company_name"].ToString();
                    recordSummary.price_close = rdr["price_close"].ToString();
                    recordSummary.price_open = rdr["price_open"].ToString();
                    recordSummary.price_low = rdr["price_low"].ToString();
                    recordSummary.price_high = rdr["price_high"].ToString();
                    recordSummary.price_best = rdr["price_best"].ToString();
                    recordSummary.price_date = rdr["price_date"].ToString();
                    recordSummary.price_volume = rdr["price_volume"].ToString();
                    recordSummary.price_market_cap = rdr["price_market_cap"].ToString();
                    recordSummary.price_turnover = rdr["price_turnover"].ToString();
                    recordSummary.price_vwap = rdr["price_vwap"].ToString();
                    recordSummary.price_change = rdr["price_change"].ToString();
                    recordSummary.price_change_per = rdr["price_change_per"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BUREAUPRICES(string company)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<Bureaus>();

            var sql =
                "SELECT BUREAU,CONVERT(varchar, DATE_UPDATED, 5) as 'date',max([SELLING]) as 'price',max([BUYING]) as 'price2' FROM [CDS_ROUTER].[dbo].[ForexMarketWatch] where BUREAU='" + company + "'  group by BUREAU,CONVERT(varchar, DATE_UPDATED, 5)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Bureaus recordSummary = new Bureaus();
                    recordSummary.Bureau = rdr["BUREAU"].ToString();
                    recordSummary.price = rdr["price"].ToString();
                    recordSummary.price2 = rdr["price2"].ToString();
                    recordSummary.date = rdr["date"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MarketWatchZSENEW()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql = @"SELECT ut.*
                        , qt.fnam
	                    ,ISNULL((SELECT TOP 1 t.price_close FROM [testcds_ROUTER].[dbo].[Prices] t
                        WHERE convert(DATE, t.price_date) = CONVERT(DATE, GETDATE() - 1)
                        and t.[company_name] = ut.Ticker order by t.PriceID desc)
	                    , ut.Current_price ) as PrevPrice
                        FROM [CDS_ROUTER].[dbo].[ZSE_market_data] ut , testcds_ROUTER.dbo.para_company qt 
                        WHERE ut.Ticker = qt.Company";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {


                    MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                    var Price_change = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) - double.Parse(rdr["Current_price"].ToString())), 4).ToString());
                    var Price_change_Per = "0.0000";
                    if (double.Parse(rdr["Current_price"].ToString()).Equals(0))
                    {
                        Price_change_Per = "0.0000";
                    }
                    else
                    {
                        Price_change_Per = Force4DecimalPlaces(Math.Round(
                                               (
                                               (double.Parse(rdr["PrevPrice"].ToString()) /
                                               double.Parse(rdr["Current_price"].ToString())) -
                                               double.Parse("1.0")
                                               ), 4).ToString());
                    }
                    recordSummary.Ticker = rdr["Ticker"].ToString();
                    recordSummary.ISIN = rdr["ISIN"].ToString();
                    recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                    recordSummary.Best_bid = rdr["Best_bid"].ToString();
                    recordSummary.Current_price = rdr["Current_price"].ToString();
                    recordSummary.Ask_Volume = rdr["Ask_Volume"].ToString();
                    recordSummary.Bid_Volume = rdr["Bid_Volume"].ToString();
                    recordSummary.FullCompanyName = rdr["fnam"].ToString();
                    recordSummary.PrevPrice = rdr["PrevPrice"].ToString();
                    recordSummary.PrevChange = Price_change;
                    recordSummary.PrevPer = Price_change_Per;
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult MarketWatchZSECommodity()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql = @"SELECT ut.*
                        , qt.fnam
	                    ,ISNULL((SELECT TOP 1 t.price_close FROM[testcds_ROUTER].[dbo].[Prices] t
                        WHERE convert(DATE, t.price_date) = CONVERT(DATE, GETDATE() - 1)
                        and t.[company_name] = ut.Ticker order by t.PriceID desc)
	                    , ut.Current_price ) as PrevPrice
                        FROM[CDS_ROUTER].[dbo].[ZSE_market_data] ut INNER JOIN  CDS_ROUTER.dbo.para_company qt on ut.Ticker=qt.ticker
                        WHERE qt.sec_type='GDR'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {


                    MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                    var Price_change = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) - double.Parse(rdr["Current_price"].ToString())), 4).ToString());
                    var Price_change_Per = "0.0000";
                    if (double.Parse(rdr["Current_price"].ToString()).Equals(0))
                    {
                        Price_change_Per = "0.0000";
                    }
                    else
                    {
                        Price_change_Per = Force4DecimalPlaces(Math.Round(
                                               (
                                               (double.Parse(rdr["PrevPrice"].ToString()) /
                                               double.Parse(rdr["Current_price"].ToString())) -
                                               double.Parse("1.0")
                                               ), 4).ToString());
                    }
                    recordSummary.Ticker = rdr["Ticker"].ToString();
                    recordSummary.ISIN = rdr["ISIN"].ToString();
                    recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                    recordSummary.Best_bid = rdr["Best_bid"].ToString();
                    recordSummary.Current_price = rdr["Current_price"].ToString();
                    recordSummary.Ask_Volume = rdr["Ask_Volume"].ToString();
                    recordSummary.Bid_Volume = rdr["Bid_Volume"].ToString();
                    recordSummary.FullCompanyName = rdr["fnam"].ToString();
                    recordSummary.PrevPrice = rdr["PrevPrice"].ToString();
                    recordSummary.PrevChange = Price_change;
                    recordSummary.PrevPer = Price_change_Per;
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MarketWatchZSENEWBUYS()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql =
                "SELECT t.* , ut.fnam FROM CDS_ROUTER.dbo.ZSE_market_data t , testcds_ROUTER.dbo.para_company  ut WHERE t.Ticker = ut.Company";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr["Ask_Volume"].ToString().Equals("0"))
                    {
                        MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                        recordSummary.Ticker = rdr["Ticker"].ToString();
                        recordSummary.ISIN = rdr["ISIN"].ToString();
                        recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                        recordSummary.Best_bid = rdr["Best_bid"].ToString();
                        recordSummary.Current_price = rdr["Current_price"].ToString();
                        recordSummary.Ask_Volume = rdr["Ask_Volume"].ToString();
                        recordSummary.Bid_Volume = rdr["Bid_Volume"].ToString();
                        recordSummary.FullCompanyName = rdr["fnam"].ToString();
                        marketWatcher.Add(recordSummary);
                    }
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult MarketWatchZSENEWSELLS()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql =
                "SELECT t.* , ut.fnam FROM CDS_ROUTER.dbo.ZSE_market_data t , testcds_ROUTER.dbo.para_company  ut WHERE t.Ticker = ut.Company";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (!rdr["Bid_Volume"].ToString().Equals("0"))
                    {
                        MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                        recordSummary.Ticker = rdr["Ticker"].ToString();
                        recordSummary.ISIN = rdr["ISIN"].ToString();
                        recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                        recordSummary.Best_bid = rdr["Best_bid"].ToString();
                        recordSummary.Current_price = rdr["Current_price"].ToString();
                        recordSummary.Ask_Volume = rdr["Ask_Volume"].ToString();
                        recordSummary.Bid_Volume = rdr["Bid_Volume"].ToString();
                        recordSummary.FullCompanyName = rdr["fnam"].ToString();
                        marketWatcher.Add(recordSummary);
                    }

                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDeliveries(string cds_number)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<Delivery>();

            var sql =
                "select *  FROM [CDS_ROUTER].[dbo].[deriv_contract] where writerNo = '" + cds_number + "' and status = 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Delivery recordSummary = new Delivery();
                    recordSummary.Commodity = rdr["Assetname"].ToString();
                    recordSummary.Category = rdr["AssetType"].ToString();
                    recordSummary.Location = rdr["AssetAddress"].ToString();
                    recordSummary.Quantity = rdr["AssetQuantity"].ToString();
                    recordSummary.Warehouse = rdr["Company"].ToString();
                    recordSummary.Expected_delivery_date = rdr["ExpiryMaturityDate"].ToString();
                    marketWatcher.Add(recordSummary);

                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCommodityTypes(string cds_number)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<Delivery>();

            var sql =
                "select *  FROM [CDS_ROUTER].[dbo].[deriv_contract] where writerNo = '" + cds_number + "' and status = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Delivery recordSummary = new Delivery();
                    recordSummary.Commodity = rdr["Ticker"].ToString();
                    recordSummary.Category = rdr["ISIN"].ToString();
                    recordSummary.Location = rdr["Best_Ask"].ToString();
                    recordSummary.Quantity = rdr["Best_bid"].ToString();
                    recordSummary.Warehouse = rdr["Current_price"].ToString();
                    recordSummary.Expected_delivery_date = rdr["Ask_Volume"].ToString();
                    marketWatcher.Add(recordSummary);

                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProductCategories()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<CommoType>();

            var sql =
                "select distinct market_segment from testcds_ROUTER.dbo.para_company WHERE  instrument='GDR'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommoType recordSummary = new CommoType();
                    recordSummary.Category = rdr["market_segment"].ToString();
                    marketWatcher.Add(recordSummary);

                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPCategoryTypes(string category)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<PSubCategory>();

            var sql =
               "select * from testcds_ROUTER.dbo.para_company WHERE Market_Segment = '" + category + "' and Index_Type='SECONDARY'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PSubCategory recordSummary = new PSubCategory();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.InitialPrice = rdr["InitialPrice"].ToString();
                    marketWatcher.Add(recordSummary);

                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
        }

        public string PostCommodity(string cds_number, string product,
            string quantity, string location, string warehouse,
            string dateofdelivery, string price, string tradetype, string description, string tif = null, string source = null , bool  borrow= false)

        {



            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var rndNum = new Random();
            var rnNum = rndNum.Next(100000, 999999);
            var r = LongRandom(0, 999999999, new Random());
            var successMessage = "Posted Successfully.";

            try
            {
                string returnstring;

                if (tradetype.ToUpper().Trim().Equals("DEPOSIT"))
                {
                    string sqlx = "insert into deriv_contract([ContractNo],[writerNo],[writerforename],[writersurname],[Assetname],[AssetDescription],[AssetType],[AssetQuantity],[AssetQuality],[AssetValue],[SettlementDate],[ExpiryMaturityDate],[StrikeExercisePrice],[Terms_Conditions],[SI_Unit],[AssetAddress],[writerAddress],[Company],[Created_By],[Created_On],[writeremail],[writerphone],[writerIDNo],[holderemail],[holderphone],[holderIDNo],[contractType],[HolderNo],[Holderforename],[Holdersurname])values('" + r.ToString() + "','" + cds_number + "',' ',' ','" + product + "',' ','" + description + "','" + quantity + "','GOOD QUALITY',0,'" + today.ToString() + "','" + dateofdelivery + "','" + price + "','VOETSTOETS','kg','" + location + " ','" + cds_number + "','" + warehouse + "','" + cds_number + "',getdate(),' ',' ',' ',' ',' ','" + cds_number + "','" + tradetype + "',' ',' ', ' ')";

                    using (SqlConnection connectionsx = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                        connectionsx.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        returnstring = successMessage;

                    }
                    return returnstring;
                }
                else
                {

                    var result = CommodityPost(product, description, "COMMODITY", tradetype, tradetype, quantity, price, cds_number, source, tif, dateofdelivery ,borrow);

                    if (result.Equals("1"))
                    {
                        return successMessage;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                //return "Error occured please contact support at ctrade@escrowgroup.org";
                return ex.ToString();
            }
        }

        public string PostForex(string cds_number, string currency,
            string quantity, string timeinforce, string bureau,
            string dateofdelivery, string price, string tradetype, string source,string option)

        {



            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var rndNum = new Random();
            var rnNum = rndNum.Next(100000, 999999);
            var r = LongRandom(0, 999999999, new Random());
            var desc = "";
            if (tradetype.ToUpper().Trim().Equals("BUY"))
            {
                desc = "Forex purchase order";
            }
            else if (tradetype.ToUpper().Trim().Equals("SELL"))
            {
                desc = "Forex sale order";
            }
                var successMessage = desc + " posted successfully.";
            var tempDbContext = new cdscDbContext();
            var user_acc = _cdDataContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cds_number);
            if (SanctionedExsistsval(user_acc.Forenames + " " + user_acc.Surname) == 1)
            {
                return "Order Posting failed.Please Contact Administrator.";
            }

            try
            {
                string returnstring="";

                if (tradetype.ToUpper().Trim().Equals("BUY"))
                {

                    bool buyforpickup = false;
                    bool buyforwallet = false;

                    if (option.ToLower()== "buyforpickup")
                    {
                       buyforpickup = true;
                       buyforwallet = false;

                    }
                    else if (option.ToLower() == "buyforwallet")
                    {
                        buyforpickup = false;
                        buyforwallet = true;
                    }
                    //validate if you have enough balance in ZWL to buy forex
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cds_number && x.TransStatus.Trim() == "1");
                    //convert money requested to zwl
                    var moneyrequested = (Convert.ToDecimal(quantity)) * (Convert.ToDecimal(price));
                    if (moneyAvail != null)
                    {

                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cds_number && x.TransStatus.Trim() == "1")
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal < moneyrequested)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                    //debit from cashtrans
                    var orderCashTranszwl = new CashTrans
                    {
                        Description = "Forex Purchase",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -1*moneyrequested,
                        CDS_Number = cds_number,
                       DateCreated = DateTime.Now
                    };
                    tempDbContext.CashTrans.Add(orderCashTranszwl);
                    //credit cashtrans forex
                    var orderCashTrans = new CashTrans_forex
                    {
                        Description = "Forex Purchase",
                        TransType = "BUY",
                        TransStatus = "0",
                        Amount = (Decimal.Parse(quantity)),
                        CDS_Number = cds_number,
                        Currency = "USD",
                        DateCreated = DateTime.Now,
                        Bureau=bureau,
                        Type_= "BUY",
                        PickUp=false,
                        Rate= (Decimal.Parse(price)),
                        Source=source,
                        BuyForPickUp=buyforpickup,
                        BuyForWallet=buyforwallet,
                        SellForBureau=false,
                        SellForWallet=false
                    };
                    tempDbContext.CashTrans_forex.Add(orderCashTrans);
                    tempDbContext.SaveChanges();
                    return successMessage;
                }
                else if(tradetype.ToUpper().Trim().Equals("SELL"))
                {
                    bool sellforbureau = false;
                    bool sellforwallet = false;
                    if (option.ToLower() == "sellforbureau")
                    {
                        sellforbureau = true;
                        sellforwallet = false;

                    }
                    else if (option.ToLower() == "sellforwallet")
                    {
                        sellforbureau =false;
                        sellforwallet =true;
                    }
                    //validate if you have enough balance in USD to sell forex
                    var moneyAvail =
                       tempDbContext.CashTrans_forex.FirstOrDefault(x => x.CDS_Number == cds_number && x.TransStatus.Trim() == "1");
                    //convert money requested to zwl
                    var moneyrequested = (Decimal.Parse(quantity));
                    if (moneyAvail != null)
                    {

                        var theCashBal =
                            tempDbContext.CashTrans_forex.Where(x => x.CDS_Number == cds_number && x.TransStatus.Trim() == "1")
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal < moneyrequested)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                    //debit cashtransforex
                    var orderCashTrans = new CashTrans_forex
                    {
                        Description = "Forex Sell",
                        TransType = "SELL",
                        TransStatus = "1",
                        Amount = -(Decimal.Parse(quantity)),
                        CDS_Number = cds_number,
                        Currency = "USD",
                        DateCreated = DateTime.Now,
                        Bureau = bureau,
                        Type_ = "SELL",
                        PickUp = false,
                        Rate = (Decimal.Parse(price)),
                        Source = source,
                        BuyForPickUp = false,
                        BuyForWallet = false,
                        SellForBureau = sellforbureau,
                        SellForWallet = sellforwallet
                    };
                    tempDbContext.CashTrans_forex.Add(orderCashTrans);
                    tempDbContext.SaveChanges();
                    return successMessage;
                }
            }
            catch (Exception ex)
            {
                //return "Error occured please contact support at ctrade@escrowgroup.org";
                return ex.ToString();
            }
            return successMessage;
        }
        public string PostBroker(string cds_number, string currency,
            string quantity, string timeinforce, string bureau,
            string price, string tradetype, string company,string custodian,string names)

        {



            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var rndNum = new Random();
            var rnNum = rndNum.Next(100000, 999999);
            var r = LongRandom(0, 999999999, new Random());
            var successMessage = "Order posted successfully.";

            try
            {
                string returnstring;

                if (tradetype.ToUpper().Trim().Equals("DEPOSIT"))
                {

                    string sqlx = "insert into [CDS_ROUTER].[dbo].[trans]([Company],[CDS_Number],[Date_Created],[Trans_Time],[Shares],[Update_Type],[Created_By],[Batch_Ref],[Source],[Pledge_shares],[Reference],[Instrument],[Broker]) values ('" + currency + "','" + cds_number + "',getdate(),cast(getdate() as time),'" + quantity + "','DEPOSIT','ONLINE','0','0','0','0','FOREX','" + bureau + "')";

                    using (SqlConnection connectionsx = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                        connectionsx.Open();
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        returnstring = successMessage;

                    }
                    return returnstring;
                }
                else
                {

                    var result = ForexBroker(company, "EQUITY", "EQUITY", tradetype, tradetype, quantity, price, cds_number, "BROKEROFFICE", timeinforce, today, currency, bureau,custodian,names);

                    if (result.Equals("1"))
                    {
                        return successMessage;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                //return "Error occured please contact support at ctrade@escrowgroup.org";
                return ex.ToString();
            }
        }
        public string ForexBroker(string product, string description, string security, string orderTrans,
  string orderType, string quantity, string price, string cdsNumber,
  string source, string tif, string date_, string currencys, string broker,string custodian,string names)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                //var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                var acc_type = "I";
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = product;
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }
                var theCds = cdsNumber + "";

                /*if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }
                */
                /*if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            shareAvail = int.Parse(rdr["Net"].ToString());
                            //break;
                        }
                    }
                    if (shareAvail < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }

                }*/
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }

                totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("0.0001");

                /*if (acc_type == "i")
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account";
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account";
                        }
                    }
                }*/
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Parse(date_);

                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + "" + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName =names,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currencys,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,
                        Source=source,
                        Affirmation = true,
                        Custodian=custodian
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return "Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return "Error occured please contact support at ctrade@escrowgroup.org. Please verify CDS Account.";
            }
        }
        public string ForexPost(string product, string description, string security, string orderTrans,
       string orderType, string quantity, string price, string cdsNumber,
       string source, string tif, string date_, string currencys, string broker)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                var acc_type = user_acc.AccountType;
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = product;
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }
                var theCds = cdsNumber + "";

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }

                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            shareAvail = int.Parse(rdr["Net"].ToString());
                            //break;
                        }
                    }
                    if (shareAvail < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }

                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }

                totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("0.0001");

                if (acc_type == "i")
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account";
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account";
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Parse(date_);

                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + "" + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currencys,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,

                        Affirmation = true
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return "Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                //return ex.ToString();
                return "Error occured please contact support at ctrade@escrowgroup.org. Please verify CDS Account.";
            }
        }


        public string CommodityPost(string product, string description, string security, string orderTrans,
      string orderType, string quantity, string price, string cdsNumber,
      string source, string tif, string date_ , bool borrow = false)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                var acc_type = user_acc.AccountType;
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = product;
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }
                var theCds = cdsNumber + "";

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }

                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            shareAvail = int.Parse(rdr["Net"].ToString());
                            //break;
                        }
                    }
                    if (shareAvail < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account. \n  Units Avalable are" + shareAvail;
                    }

                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }

                totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("0.0001");

                if (acc_type == "i")
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account";
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account";
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Parse(date_);

                var brokerCode = "IMARA";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = "IMARA" + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = brokerCode,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,
                        Source = source,
                        Affirmation = true,
                        borrowStatus = borrow 
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error occured please contact support at ctrade@escrowgroup.org1";
                    }
                }
                catch (Exception e)
                {
                    return "Error occured please contact support at ctrade@escrowgroup.org2";
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
                //return "Error occured please contact support at ctrade@escrowgroup.org3";
            }
        }

        public JsonResult portFolioAll(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<PortfolioAll>();

            var sql = "select d.*, ut.fnam as fullCompanyName, ut.Instrument from cdsc.dbo.PortfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number='" + cdsNumber + "' and d.Company = ut.Company";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PortfolioAll recordSummary = new PortfolioAll();
                    string curr_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["currePrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    string prev_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["prevdayQuantity"].ToString())), 4).ToString());
                    double ret_Port = Math.Round(double.Parse(curr_Port), 4) - Math.Round(double.Parse(prev_Port), 4);
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.Instrument = rdr["Instrument"].ToString();
                    recordSummary.prev_numbershares = rdr["prevdayQuantity"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = curr_Port;
                    recordSummary.totalPrevPortValue = prev_Port;
                    recordSummary.returns = Force4DecimalPlaces(ret_Port.ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());
                    recordSummary.companyFullName = rdr["fullCompanyName"].ToString();



                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }

        public JsonResult PortfolioByType(string cdsNumber = null, string type = null)
        {
            string cdcnumber = "";
            try
            {
                var cdc = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.CDS_Number.ToLower().Replace(" ", "") == cdsNumber.ToLower().Replace(" ", "")).FirstOrDefault();
                cdcnumber = cdc.CDC_Number;
            }
            catch (Exception)
            {


            }
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<PortfolioAll>();


            var sql = "select d.*, ut.fnam as fullCompanyName, ut.Instrument from cdsc.dbo.PortfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number='" + cdsNumber + "' and d.Company = ut.Company and ut.Instrument = '" + type + "'";
            if (string.IsNullOrEmpty(cdcnumber)==false)
            {
                sql = "select d.*, ut.fnam as fullCompanyName, ut.Instrument from cdsc.dbo.PortfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number in ('" + cdsNumber + "','" + cdcnumber + "') and d.Company = ut.Company and ut.Instrument = '" + type + "'";

            }
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PortfolioAll recordSummary = new PortfolioAll();
                    string curr_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["currePrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    string prev_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["prevdayQuantity"].ToString())), 4).ToString());
                    double ret_Port = Math.Round(double.Parse(curr_Port), 4) - Math.Round(double.Parse(prev_Port), 4);
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.Instrument = rdr["Instrument"].ToString();
                    recordSummary.prev_numbershares = rdr["prevdayQuantity"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = curr_Port;
                    recordSummary.totalPrevPortValue = prev_Port;
                    recordSummary.returns = Force4DecimalPlaces(ret_Port.ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());
                    recordSummary.companyFullName = rdr["fullCompanyName"].ToString();



                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    if (string.IsNullOrEmpty(cdcnumber) == false)
                    {
                        sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number in ('" + cdsNumber + "','" + cdcnumber + "') and d.Company='" + recordSummary.counter + "' and d.Shares>0";

                    }
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    if (string.IsNullOrEmpty(cdcnumber) == false)
                    {
                        sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number in ('" + cdsNumber + "','" + cdcnumber + "') and d.Company='" + recordSummary.counter + "' and d.Shares<0";

                    }
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketWatch()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "SELECT cp.[COMPANY] as Company, [SHARESINISSUE]  as SharesInIssue, [ClosingPrice] as ClosingPrice, [BestPrice] as CurrentPrice, UPPER(pc.fnam) as CompanyName FROM[testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProductTypeUnits(string type)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<Trust>();

            var sql = "SELECT * from testcds_ROUTER.DBO.para_company where instrument = '" + type + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Trust recordSummary = new Trust();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.Issued_shares = decimal.Parse(rdr["Issued_shares"].ToString());
                    recordSummary.InitialPrice = decimal.Parse(rdr["InitialPrice"].ToString());
                    recordSummary.fnam = rdr["fnam"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

       


        public JsonResult GetCommoditiesCat()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<Commodity>();
            List<Categories> comodities = new List<Categories>();

            var sql = "select distinct category from cds_router.dbo.commodities";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    Categories category = new Categories();
                    category.CategoryName=  rdr["category"].ToString();
                    comodities.Add(category);
                    
                }
            }

            return Json(comodities, JsonRequestBehavior.AllowGet);

        }

            public JsonResult GetCommodities(string category)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<Commodity>();

            var sql = "select * from cds_router.dbo.commodities where category='" + category + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Commodity recordSummary = new Commodity
                    {
                        Id = rdr["id"].ToString(),
                        Product = rdr["product"].ToString(),
                        Price = rdr["price"].ToString(),
                        Category = rdr["category"].ToString(),
                        Multiples = rdr["Multiples"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCommoditiesGrades()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<Commodity>();

           // var sql = "select * from cds_router.dbo.commodities where category='" + category + "'";
            var sql = "SELECT [ID],[Company],[Sector],[InitialPrice],isnull([Multiples],1) [Multiples] FROM[testcds_ROUTER].[dbo].[para_company] where Sector = 'Commodity'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Commodity recordSummary = new Commodity
                    {
                        Id = rdr["ID"].ToString(),
                        Product = rdr["Company"].ToString(),
                        Price = rdr["InitialPrice"].ToString(),
                        Category = rdr["Sector"].ToString(),
                        Multiples = rdr["Multiples"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetZipitBanks()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<ZipitBankCodes>();

            var sql = "select * FROM [CDS_ROUTER].[dbo].[BankZipitCode]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ZipitBankCodes recordSummary = new ZipitBankCodes
                    {
                        id = int.Parse(rdr["id"].ToString()),
                        bank_name = rdr["bank_name"].ToString(),
                        zipit_code = rdr["zipit_code"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetMyCommodities(string cds_number)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<Deriv_Contract>();

            var sql = " select *, Assetname as fname FROM [CDS_ROUTER].[dbo].[deriv_contract] where writerno ='" + cds_number + "' and status='1' order by id desc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Deriv_Contract recordSummary = new Deriv_Contract
                    {
                        ContractNo = rdr["ContractNo"].ToString(),
                        Assetname = rdr["Assetname"].ToString(),
                        AssetDescription = rdr["AssetDescription"].ToString(),
                        AssetQuantity = rdr["AssetQuantity"].ToString(),
                        Created_On = DateTime.Parse(rdr["Created_On"].ToString()).ToString("dd MMM yyyy HH:mm")
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetOrdersByType(string cds_number, string type)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<Pre_O_Lives>();

            string sql = "select p.*, c.fnam from testcds_router.dbo.pre_order_live p join testcds_router.dbo.para_company c  on p.company = c.company  where p.cds_ac_no = '" + cds_number + "' and p.securitytype = '" + type + "' order by p.OrderNo desc";

            if (type.ToLower() == "commodity")
            {
                //sql = "select p.*,p.Company as fnam from testcds_router.dbo.pre_order_live p where p.cds_ac_no = '" + cds_number + "' and p.OrderStatus = 'open' and p.securitytype = '" + type + "' order by p.OrderNo desc";
                sql = "select p.*,p.Company as fnam from testcds_router.dbo.pre_order_live p where p.cds_ac_no = '" + cds_number + "' and p.securitytype = '" + type + "' order by p.OrderNo desc";

            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pre_O_Lives recordSummary = new Pre_O_Lives
                    {
                        id = int.Parse(rdr["OrderNo"].ToString()),
                        counter = rdr["Company"].ToString(),
                        type = rdr["OrderType"].ToString(),
                        volume = rdr["Quantity"].ToString(),
                        price = rdr["BasePrice"].ToString(),
                        date = DateTime.Parse(rdr["Create_date"].ToString()).ToString("dd MMM yyyy"),
                        status = rdr["OrderStatus"].ToString(),
                        desc = rdr["OrderNumber"].ToString(),
                        fullname = rdr["fnam"].ToString(),
                        ordernumber = rdr["OrderNumber"].ToString(),
                        source = rdr["Source"].ToString(),

                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProdTypesCharges(string type)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<TrustCharges>();

            var sql = "SELECT p.Company, p.Issued_shares, p.InitialPrice, p.Issued_shares, p.fnam,  c.*  from testcds_ROUTER.DBO.para_company p JOIN  [CDS_ROUTER].[dbo].[Charges] c on p.instrument = c.security_type where p.instrument= '" + type + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TrustCharges recordSummary = new TrustCharges();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.Issued_shares = decimal.Parse(rdr["Issued_shares"].ToString());
                    recordSummary.InitialPrice = decimal.Parse(rdr["InitialPrice"].ToString());
                    recordSummary.Issued_shares = decimal.Parse(rdr["Issued_shares"].ToString());
                    recordSummary.fnam = rdr["fnam"].ToString();
                    recordSummary.ChargesBuy = rdr["charges_buy"].ToString();
                    recordSummary.ChargesSell = rdr["charges_sell"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetCommodityPortfolio(string cds_number)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<CommoPort>();

            var sql = " select * FROM [CDSC].[dbo].[PortfolioAll] WHERE COMPANY IN (SELECT COMPANY FROM testcds_ROUTER.DBO.para_company WHERE instrument='GDR') and CDS_Number = '" + cds_number + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommoPort recordSummary = new CommoPort();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.LastAcDate = rdr["LastAcDate"].ToString();
                    recordSummary.totAllShares = rdr["totAllShares"].ToString();
                    recordSummary.prevdayQuantity = rdr["prevdayQuantity"].ToString();
                    recordSummary.currePrice = rdr["currePrice"].ToString();
                    recordSummary.PrevPrice = rdr["PrevPrice"].ToString();
                    recordSummary.Uncleared = rdr["Uncleared"].ToString();
                    recordSummary.Net = rdr["Net"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetNewsFeeds()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<NewsFeed>();

            var sql = "  select * from cds_router.dbo.Diary ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NewsFeed recordSummary = new NewsFeed
                    {
                        Heading = rdr["Caption"].ToString(),
                        Message = rdr["Details"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetTrustsPortfolio(string cdsNumber)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<TrustBalance>();

            var sql = " select Company,sum(shares) as balance from cds_router.dbo.trans where CDS_Number ='" + cdsNumber + "' and update_type ='DEAL UT' GROUP BY COMPANY HAVING SUM(Shares)>0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TrustBalance recordSummary = new TrustBalance
                    {
                        Company = rdr["Company"].ToString(),
                        Balance = rdr["balance"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult MarketWatchZSEE()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcherZSE>();

            var sql =
                "SELECT * FROM ZSE_market_data";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcherZSE recordSummary = new MarketWatcherZSE();
                    recordSummary.Ticker = rdr["Ticker"].ToString();
                    recordSummary.ISIN = rdr["ISIN"].ToString();
                    recordSummary.Best_Ask = rdr["Best_Ask"].ToString();
                    recordSummary.Best_bid = rdr["Best_bid"].ToString();
                    recordSummary.Current_price = rdr["Current_price"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult versionControl()
        {
            List<AppVersion> version = new List<AppVersion>
            {
                new AppVersion() { appVersion = "2.1.1" }
            };
            return Json(version, JsonRequestBehavior.AllowGet);
        }


        public JsonResult marketStatus(String market)
        {
            if (market == "ZSE")
            {
                List<MarketStatus> version = new List<MarketStatus>
            {
                new MarketStatus(){openTime ="1000", closeTime ="1230"}
            };
                return Json(version, JsonRequestBehavior.AllowGet);

            }
            else if (market == "FINSEC")
            {
                List<MarketStatus> version = new List<MarketStatus>
            {
                new MarketStatus(){openTime ="900", closeTime ="1630"}
            };
                return Json(version, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }

        }


        public string MarketNews()
        {
            return "Market ";
        }

        public JsonResult Balance(string cdsNumber = null)
        {

            var sums = _cdDataContext.trans.Join(_cdDataContext.para_company, c => c.Company, d => d.Company,
                (c, d) => new
                {
                    Company = d.Fnam,
                    CompanyCode = c.Company,
                    Shares = c.Shares,
                    CdsNumber = c.CDS_Number
                })
             .Where(d => d.CdsNumber == cdsNumber)
             .GroupBy(d => d.Company)
             .Select(g =>
                 new
                 {
                     Name = g.Select(s => s.Company).FirstOrDefault(),
                     ISIN = g.Select(s => s.CompanyCode).FirstOrDefault(),
                     Shares = g.Sum(s => s.Shares),
                 });

            return Json(sums, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Balances(string cdsNumber = null)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var CompShares = new List<Balances>();

            var sql = "select tm.*,pc.Fnam from (select tx.Company,tx.CDS_Number,sum(tx.Shares) as totShares from trans tx group by tx.Company,tx.CDS_Number) tm left Join para_company pc on tm.Company = pc.Company  where tm.CDS_Number = '" + cdsNumber + "' and tm.totShares>0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Balances recordSummary = new Balances();
                    recordSummary.Name = rdr["Fnam"].ToString();
                    recordSummary.ISIN = rdr["Company"].ToString();
                    recordSummary.Shares = long.Parse(rdr["totShares"].ToString());
                    CompShares.Add(recordSummary);
                }
            }

            if (CompShares.Any())
            {
                return Json(CompShares, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult SecMovement(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<PortfolioMovement>();

            var sql = "select tx.Shares as Shares, tx.Date_Created as Date, tx.Company, pc.Fnam as CompanyName, ISNULL(tx.Instrument, 'EQUITY') as Instrument from trans tx    Join para_company pc on tx.Company = pc.Company  where CDS_Number = '" + cdsNumber + "' order by tx.Date_created asc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PortfolioMovement recordSummary = new PortfolioMovement();
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Shares = rdr["Shares"].ToString();
                    recordSummary.Date = DateTime.Parse(rdr["Date"].ToString()).ToShortDateString();
                    recordSummary.Instrument = rdr["Instrument"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        //ACCOUNT CREATION PARAMETERES
        public JsonResult GetCompanies(string company = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<GetBroker>();

            var sql = "select distinct UPPER(Company_name) as Name, [Company_Code] as Code FROM [CDS_ROUTER].[dbo].[Client_Companies]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GetBroker recordSummary = new GetBroker();
                    recordSummary.Name = rdr["Name"].ToString();
                    recordSummary.Code = rdr["Code"].ToString();

                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetBureau()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<GetBureau>();

            var sql = "select distinct UPPER(Company_name) as Name, [Company_Code] as Code,(SELECT  top 1 [BUYING] FROM [CDS_ROUTER].[dbo].[ForexMarketWatch]  where BUREAU=Company_Code   order by id desc) as 'BuyPrice',(SELECT  top 1 [SELLING] FROM [CDS_ROUTER].[dbo].[ForexMarketWatch]  where BUREAU=Company_Code   order by id desc) as 'SellPrice' FROM [CDS_ROUTER].[dbo].[Client_Companies] where Company_type='BUREAU'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GetBureau recordSummary = new GetBureau
                    {
                        Name = rdr["Name"].ToString(),
                        Code = rdr["Code"].ToString(),
                        BuyingVolume = "200",
                        BuyingPrice = rdr["BuyPrice"].ToString(),
                        SellingVolume = "111",
                        SellingPrice = rdr["SellPrice"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCurrency()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<GetBroker>();

            var sql = "SELECT TOP 1000 [CurrencyCode] As Code,[CurrencyName] as Name FROM [CDS_ROUTER].[dbo].[para_Currencies]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GetBroker recordSummary = new GetBroker();
                    recordSummary.Name = rdr["Name"].ToString();
                    recordSummary.Code = rdr["Code"].ToString();

                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult ForexMarketWatch()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var marketWatcher = new List<Forex>();

            var sql = "select * FROM ForexMarketWatch";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Forex recordSummary = new Forex();
                    recordSummary.ID = rdr["ID"].ToString();
                    recordSummary.BUREAU = rdr["BUREAU"].ToString();
                    recordSummary.BUYING = rdr["BUYING"].ToString();
                    recordSummary.SELLING = rdr["SELLING"].ToString();
                    recordSummary.DATE_UPDATED = DateTime.Parse(rdr["DATE_UPDATED"].ToString()).ToString("dd-MM-yyyy HH:ss");
                    recordSummary.UPDATED_BY = rdr["UPDATED_BY"].ToString();
                    recordSummary.ACTIVE = rdr["ACTIVE"].ToString();
                    recordSummary.CURRENCY = rdr["CURRENCY"].ToString();
                    recordSummary.BUY_LIMIT = rdr["BUY_LIMIT"].ToString();
                    recordSummary.SELL_LIMIT = rdr["SELL_LIMIT"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetCompany(string exchange, string range, string company = null)
        {
            //Selecting distinct
            var companies = _AtsDbContext.para_company.Where(x => x.exchange.Contains(exchange)).GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    Name = c.fnam,
                    c.InitialPrice
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MobileMoney(string company = null)
        {
            var mobileMoney = _cdDataContext.para_mobile_money.GroupBy(x => x.Mobile_money_name).Select(x => x.FirstOrDefault()).Select(c => new
            {
                Id = c.ID,
                Name = c.Mobile_money_name
            });
            return Json(mobileMoney, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Banks(string company = null)
        {
            var getBanks = _cdDataContext.para_bank.GroupBy(x => x.bank_name).Select(x => x.FirstOrDefault()).Select(c => new
            {
                Id = c.bank,
                Code = c.bank,
                Name = c.bank_name
            });
            return Json(getBanks, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Branch(string bank = null)
        {
            var getBranch = _cdDataContext.para_branch.GroupBy(x => x.branch_name).Select(x => x.FirstOrDefault()).Where(x => x.bank == bank).Select(c => new
            {
                Name = c.branch_name
            });
            return Json(getBranch, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetBranchFromFullName(string bank_name)
        {
            var sql =
                "   Select t.bank_name , ut.branch_name , ut.branch FROM para_bank t, para_branch ut WHERE t.bank = ut.bank and t.bank_name = '" +
                bank_name + "'";
            var marketNews = new List<Branches>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Branches recordSummary = new Branches();
                    recordSummary.Name = rdr["branch_name"].ToString();
                    recordSummary.Code = rdr["branch"].ToString();
                    marketNews.Add(recordSummary);
                }
            }


            if (marketNews.Any())
            {
                return Json(marketNews, JsonRequestBehavior.AllowGet);
            }
            return Json("HEAD", JsonRequestBehavior.AllowGet);

        }



        public JsonResult Prices(string oldpass)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "SELECT cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue ,[ClosingPrice] as ClosingPrice ,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert (decimal(10, 2),  (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100) as Change FROM [testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Exchange = "FINSEC";
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EscrosharePrices()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "select a.Company as Company,a.PricePerShare as SharesInIssue,a.PricePerShare as ClosingPrice,a.PricePerShare as CurrentPrice,UPPER(c.fnam) as CompanyName,convert (decimal(10, 2),a.PercentageChange) as Change  from PortFolio a join para_company c on a.Company=c.company where a.DateToday=(select top 1 b.DateToday from PortFolio b order by b.id desc)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Exchange = "ZSE";
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AllPrices()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var connectionString2 = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "select a.Company as Company,a.PricePerShare as SharesInIssue,a.PricePerShare as ClosingPrice,a.PricePerShare as CurrentPrice,UPPER(c.fnam) as CompanyName,convert (decimal(10, 2),a.PercentageChange) as Change  from PortFolio a join para_company c on a.Company=c.company where a.DateToday=(select top 1 b.DateToday from PortFolio b order by b.id desc)";
            var sql2 =
                "SELECT cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue ,[ClosingPrice] as ClosingPrice ,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert (decimal(10, 2),  (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100) as Change FROM [testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY ";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Exchange = "ZSE";
                    marketWatcher.Add(recordSummary);
                }
            }
            //append

            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                cmd2.CommandType = CommandType.Text;
                connection2.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    MarketWatcher recordSummary2 = new MarketWatcher();
                    recordSummary2.Company = rdr2["Company"].ToString();
                    recordSummary2.SharesInIssue = rdr2["SharesInIssue"].ToString();
                    recordSummary2.ClosingPrice = Math.Round(decimal.Parse(rdr2["ClosingPrice"].ToString()), 4);
                    recordSummary2.CurrentPrice = Math.Round(decimal.Parse(rdr2["CurrentPrice"].ToString()), 4);
                    recordSummary2.Change = decimal.Parse(rdr2["Change"].ToString());

                    recordSummary2.ChangeString = decimal.Parse(rdr2["Change"].ToString()).ToString("##.000");
                    recordSummary2.CompanyName = rdr2["CompanyName"].ToString();
                    recordSummary2.Exchange = "FINSEC";
                    marketWatcher.Add(recordSummary2);
                }
            }
            //append

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Top_Gainers()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var connectionString2 = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "select a.Company as Company,a.PricePerShare as SharesInIssue,a.PricePerShare as ClosingPrice,a.PricePerShare as CurrentPrice,UPPER(c.fnam) as CompanyName,convert (decimal(10, 2),a.PercentageChange) as Change  from PortFolio a join para_company c on a.Company=c.company where a.DateToday=(select top 1 b.DateToday from PortFolio b order by b.id desc) and a.PercentageChange>0 order by a.PercentageChange desc";
            var sql2 =
                "SELECT cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue ,[ClosingPrice] as ClosingPrice ,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert (decimal(10, 2),  (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100) as Change FROM [testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY  WHERE cp.[BestPrice] - cp.[ClosingPrice]>0 order by cp.[BestPrice] - cp.[ClosingPrice] desc";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Exchange = "ZSE";
                    marketWatcher.Add(recordSummary);
                }
            }
            //append

            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                cmd2.CommandType = CommandType.Text;
                connection2.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    MarketWatcher recordSummary2 = new MarketWatcher();
                    recordSummary2.Company = rdr2["Company"].ToString();
                    recordSummary2.SharesInIssue = rdr2["SharesInIssue"].ToString();
                    recordSummary2.ClosingPrice = Math.Round(decimal.Parse(rdr2["ClosingPrice"].ToString()), 4);
                    recordSummary2.CurrentPrice = Math.Round(decimal.Parse(rdr2["CurrentPrice"].ToString()), 4);
                    recordSummary2.Change = decimal.Parse(rdr2["Change"].ToString());

                    recordSummary2.ChangeString = decimal.Parse(rdr2["Change"].ToString()).ToString("##.000");
                    recordSummary2.CompanyName = rdr2["CompanyName"].ToString();
                    recordSummary2.Exchange = "FINSEC";
                    marketWatcher.Add(recordSummary2);
                }
            }
            //append

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Top_Losers()
        {

            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var connectionString2 = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "select a.Company as Company,a.PricePerShare as SharesInIssue,a.PricePerShare as ClosingPrice,a.PricePerShare as CurrentPrice,UPPER(c.fnam) as CompanyName,convert (decimal(10, 2),a.PercentageChange) as Change  from PortFolio a join para_company c on a.Company=c.company where a.DateToday=(select top 1 b.DateToday from PortFolio b order by b.id desc) and a.PercentageChange<0 order by a.PercentageChange asc";
            var sql2 =
                "SELECT cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue ,[ClosingPrice] as ClosingPrice ,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert (decimal(10, 2),  (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100) as Change FROM [testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY  WHERE cp.[BestPrice] - cp.[ClosingPrice]<0 order by cp.[BestPrice] - cp.[ClosingPrice] asc";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    recordSummary.Exchange = "ZSE";
                    marketWatcher.Add(recordSummary);
                }
            }
            //append

            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                cmd2.CommandType = CommandType.Text;
                connection2.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    MarketWatcher recordSummary2 = new MarketWatcher();
                    recordSummary2.Company = rdr2["Company"].ToString();
                    recordSummary2.SharesInIssue = rdr2["SharesInIssue"].ToString();
                    recordSummary2.ClosingPrice = Math.Round(decimal.Parse(rdr2["ClosingPrice"].ToString()), 4);
                    recordSummary2.CurrentPrice = Math.Round(decimal.Parse(rdr2["CurrentPrice"].ToString()), 4);
                    recordSummary2.Change = decimal.Parse(rdr2["Change"].ToString());

                    recordSummary2.ChangeString = decimal.Parse(rdr2["Change"].ToString()).ToString("##.000");
                    recordSummary2.CompanyName = rdr2["CompanyName"].ToString();
                    recordSummary2.Exchange = "FINSEC";
                    marketWatcher.Add(recordSummary2);
                }
            }
            //append

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TopGainers(string oldpass)
        {

            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql =
                "SELECT cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue , [ClosingPrice] as ClosingPrice,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert(decimal(10, 2), (([BestPrice] - [ClosingPrice]) /[ClosingPrice]) * 100) as Change FROM [CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY where (([BestPrice] - [ClosingPrice]) /[ClosingPrice]) * 100 > 0 order by Change desc  ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = Math.Round(decimal.Parse(rdr["Change"].ToString()), 4);

                    recordSummary.ChangeString = decimal.Parse(rdr["Change"].ToString()).ToString("##.000");

                    float f = float.Parse(rdr["Change"].ToString());

                    recordSummary.ChangeString = f.ToString("##,####");


                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TopLosers(string oldpass)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatcher>();

            var sql = "SELECT top 10 cp.[COMPANY] as Company ,[SHARESINISSUE]  as SharesInIssue ,[ClosingPrice] as ClosingPrice ,[BestPrice] as CurrentPrice ,UPPER(pc.fnam) as CompanyName ,convert(decimal(10, 2),  (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100) as Change FROM[testcds_ROUTER].[dbo].[CompanyPrices] cp join para_company pc on pc.Company = cp.COMPANY where (([BestPrice] - [ClosingPrice])/[ClosingPrice])*100 < 0 order by Change asc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatcher recordSummary = new MarketWatcher();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.SharesInIssue = rdr["SharesInIssue"].ToString();
                    recordSummary.ClosingPrice = Math.Round(decimal.Parse(rdr["ClosingPrice"].ToString()), 4);
                    recordSummary.CurrentPrice = Math.Round(decimal.Parse(rdr["CurrentPrice"].ToString()), 4);
                    recordSummary.Change = decimal.Parse(decimal.Parse(rdr["Change"].ToString()).ToString("f4"));
                    recordSummary.CompanyName = rdr["CompanyName"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNews()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var marketNews = new List<TheNews>();

            var sql =
                "SELECT ID,post_title,post_content,post_date,post_mime_type FROM News ORDER BY ID DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TheNews recordSummary = new TheNews();
                    recordSummary.id = long.Parse(rdr["ID"].ToString());
                    recordSummary.isImportant = true;
                    recordSummary.picture = "";
                    recordSummary.from = "FINSEC";
                    recordSummary.subject = rdr["post_title"].ToString();
                    recordSummary.message = rdr["post_content"].ToString();
                    recordSummary.timestamp = rdr["post_date"].ToString();
                    recordSummary.isRead = false;
                    marketNews.Add(recordSummary);
                }
            }

            if (marketNews.Any())
            {
                return Json(marketNews, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketWatchs(string oldpass)
        {


            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatch>();

            var sql = "SELECT [company] as Company ,[Volume] as Volume ,[Bid] as Bid ,[Volume Sell] as VolumeSell ,[Ask] ,[Last Traded Price] as LastTradedPrice ,[Lastmatched] ,[lastvolume] ,[TotalVolume],[Turnover],[Open],[High],[Low],[Average Price] as AvgPrice,[Change],[percchange],[url],[url2]FROM[testcds_ROUTER].[dbo].[MarketWatch]";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatch recordSummary = new MarketWatch();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.Volume = rdr["Volume"].ToString();
                    recordSummary.Bid = rdr["Bid"].ToString();
                    recordSummary.VolumeSell = rdr["VolumeSell"].ToString();
                    recordSummary.Ask = rdr["Ask"].ToString();
                    recordSummary.LastTradedPrice = rdr["LastTradedPrice"].ToString();
                    recordSummary.Lastmatched = rdr["Lastmatched"].ToString();
                    recordSummary.Lastvolume = rdr["Lastvolume"].ToString();
                    recordSummary.TotalVolume = rdr["TotalVolume"].ToString();
                    recordSummary.Turnover = rdr["Turnover"].ToString();
                    recordSummary.Open = rdr["Open"].ToString();
                    recordSummary.High = rdr["High"].ToString();
                    recordSummary.Low = rdr["Low"].ToString();
                    recordSummary.AveragePrice = rdr["AvgPrice"].ToString();
                    recordSummary.Change = rdr["Change"].ToString();
                    recordSummary.Percchange = rdr["Percchange"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketWatchsComs(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcher = new List<MarketWatch>();

            var sql = "SELECT [company] as Company, [Volume] as Volume ,[Bid] as Bid ,[Volume Sell] as VolumeSell ,[Ask] ,[Last Traded Price] as LastTradedPrice ,[Lastmatched] ,[lastvolume] ,[TotalVolume],[Turnover],[Open],[High],[Low],[Average Price] as AvgPrice,[Change],[percchange],[url],[url2]FROM[testcds_ROUTER].[dbo].[MarketWatch] where RTRIM(LTRIM(fnam))='" + name.Trim() + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatch recordSummary = new MarketWatch();
                    recordSummary.Company = rdr["Company"].ToString();
                    recordSummary.Volume = rdr["Volume"].ToString();
                    recordSummary.Bid = rdr["Bid"].ToString();
                    recordSummary.VolumeSell = rdr["VolumeSell"].ToString();
                    recordSummary.Ask = rdr["Ask"].ToString();
                    recordSummary.LastTradedPrice = rdr["LastTradedPrice"].ToString();
                    recordSummary.Lastmatched = rdr["Lastmatched"].ToString();
                    recordSummary.Lastvolume = rdr["Lastvolume"].ToString();
                    recordSummary.TotalVolume = rdr["TotalVolume"].ToString();
                    recordSummary.Turnover = rdr["Turnover"].ToString();
                    recordSummary.Open = rdr["Open"].ToString();
                    recordSummary.High = rdr["High"].ToString();
                    recordSummary.Low = rdr["Low"].ToString();
                    recordSummary.AveragePrice = rdr["AvgPrice"].ToString();
                    recordSummary.Change = rdr["Change"].ToString();
                    recordSummary.Percchange = rdr["Percchange"].ToString();
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            return Json("No data was found", JsonRequestBehavior.AllowGet);
            //            var thePrices = "atsDbContext.;";
            //            return Json(thePrices, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResetPassword(string email, string natId, string newpass)
        {
            //            var cdDataContext = new CdDataContext();
            if (email != null || newpass != null || natId != null)
            {
                var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Email == email);
                if (usernameFound != null)
                {

                    var IdNumberFound = _cdDataContext.Accounts_Clients.FirstOrDefault(x => x.Email == email && x.IDNoPP == natId);

                    if (IdNumberFound != null)
                    {
                        usernameFound.Password = newpass;
                        try
                        {
                            _cdscDbContext.SaveChanges();
                            return Json(1, JsonRequestBehavior.AllowGet);
                        }
                        catch (Exception)
                        {
                            return Json(3, JsonRequestBehavior.AllowGet);
                        }
                    }
                    return Json(4, JsonRequestBehavior.AllowGet);

                }
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ForgotPassword(string email, string natId, string newpass, string dob)
        {
            //            var cdDataContext = new CdDataContext();
            if (email != null || newpass != null || natId != null)
            {
                var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Email == email);
                if (usernameFound != null)
                {
                    DateTime ofBirth;
                    if (DateTime.TryParse(dob, out ofBirth))
                    {
                        var IdNumberFound = _cdDataContext.Accounts_Clients.FirstOrDefault(x => x.IDNoPP == natId && x.DOB == DateTime.Parse(dob));

                        if (IdNumberFound != null)
                        {
                            usernameFound.Password = newpass;
                            try
                            {
                                _cdscDbContext.SaveChanges();
                                return Json(1, JsonRequestBehavior.AllowGet);
                            }
                            catch (Exception)
                            {
                                return Json(3, JsonRequestBehavior.AllowGet);
                            }
                        }
                        return Json(4, JsonRequestBehavior.AllowGet);
                    }
                    return Json(5, JsonRequestBehavior.AllowGet);//failed to convert striing provided under dob into datetime

                }
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        /*public JsonResult ResetPassword(string email, string natId, string newpass)
        {
           //            var cdDataContext = new CdDataContext();
           if (email != null || newpass != null || natId != null)
           {
               var usernameFound = _cdscDbContext.Subscribers.FirstOrDefault(x => x.Email == email);
               if (usernameFound != null)
               {

                   //                    var userCtrade = cdDataContext.Accounts_Clients.FirstOrDefault(x => x.Email == email);
                   //
                   //                    if (userCtrade != null)
                   //                    {
                   //
                   //                    }

                   usernameFound.Password = newpass;
                   try
                   {
                       _cdscDbContext.SaveChanges();
                       return Json(1, JsonRequestBehavior.AllowGet);
                   }
                   catch (Exception)
                   {
                       return Json(3, JsonRequestBehavior.AllowGet);
                   }
               }
               return Json(2, JsonRequestBehavior.AllowGet);
           }
           return Json(0, JsonRequestBehavior.AllowGet);
        }*/


        public JsonResult ChangePassword(string oldpass, string newpass, string id)
        {
            if (oldpass != null || newpass != null || id != null)
            {
                //                var ids = int.Parse(id);

                var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Password == oldpass && x.Active && x.Email == id);
                if (usernameFound != null)
                {
                    usernameFound.Password = newpass;
                    try
                    {
                        _cdscDbContext.SaveChanges();
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json(3, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeactivateAccount(string username, string password)
        {
            if (username != null || password != null)
            {
                var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Username == username && x.Password == password && x.Active);
                if (usernameFound != null)
                {
                    usernameFound.Active = false;
                    try
                    {
                        _cdscDbContext.SaveChanges();
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception)
                    {
                        return Json(3, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(2, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Subscribe(string id, string toAdd, string toRemove)
        {
            var itemsToRemove = new ArrayList();
            var itemsToAdd = new ArrayList();
            var count = 0;

            var addReturn = 0;
            var remReturn = 0;
            var ret = "0";

            if (toAdd != null)
            {
                itemsToAdd.AddRange(toAdd.Split('*'));
                itemsToAdd.RemoveAt(itemsToAdd.Count - 1);

                foreach (var adds in itemsToAdd)
                {
                    var theString = adds;
                    var theProduct =
                    _cdscDbContext.Products.OrderByDescending(x => x.Id)
                        .FirstOrDefault(x => x.Name == theString.ToString());

                    if (theProduct != null)
                    {
                        var theProductId = theProduct.Id;

                        //INSERTING INTO SUBSCRIBERPRODUCTS
                        var subscriberProduct = new SubscriberProduct
                        {
                            SubscriberId = int.Parse(id),
                            ProductId = theProductId,
                            Date = DateTime.Now
                        };

                        try
                        {
                            _cdscDbContext.SubscriberProducts.Add(subscriberProduct);
                            _cdscDbContext.SaveChanges();
                            addReturn++;
                        }
                        catch (Exception exception)
                        {
                            ret = exception.ToString();
                            addReturn = 0;
                        }
                    }
                }
            }


            if (toRemove != null)
            {
                itemsToRemove.AddRange(toRemove.Split('*'));
                itemsToRemove.RemoveAt(itemsToRemove.Count - 1);

                //                for (int i = 0; i < toRemove.Length; i++)
                foreach (var rev in itemsToRemove)
                {
                    var theString = rev;
                    var theProduct =
                        _cdscDbContext.Products.OrderByDescending(x => x.Id)
                            .FirstOrDefault(x => x.Name == theString.ToString());

                    if (theProduct != null)
                    {
                        var theProductId = theProduct.Id;
                        var code = _cdscDbContext.SubscriberProducts.FirstOrDefault(x => x.ProductId == theProductId);

                        if (code != null)
                        {
                            try
                            {
                                _cdscDbContext.SubscriberProducts.Remove(code);
                                _cdscDbContext.SaveChanges();
                                count++;
                                remReturn++;
                            }
                            catch (Exception exception)
                            {
                                ret = exception.ToString();
                            }
                        }
                    }
                }
            }
            //0. For any errors
            //1. For Add only
            //2. For Rev Only
            //3. For Add and Rev

            var rets = 0;

            if (toAdd != null && toAdd.Length > 0)
            {
                if (addReturn == itemsToAdd.Count)
                {
                    rets = 1;
                }
                else
                {
                    rets = 0;
                }
            }

            if (toRemove != null && toRemove.Length > 0)
            {
                if (count == itemsToRemove.Count)
                {
                    rets = 2;
                }
                else
                {
                    rets = 0;
                }
            }

            if (toRemove != null && toAdd != null)
            {
                if (addReturn == itemsToAdd.Count && count == itemsToRemove.Count)
                {
                    rets = 3;
                }
            }
            return Json(rets, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AccountCreation(string branch, string mobile, string adress_yangu, string theTitle, string theSurname, string theName, string thenationality, string theDOB, string theGender, string theCountry, string idNums, string bank, string accountNum, string email, string password)
        {

            //        public JsonResult AccountCreation(string theTitle)
            //        {


            var rndNum = new Random();
            var rnNum = rndNum.Next(100000, 999999);
            var r = LongRandom(0, 999999999999999, new Random());

            Accounts_Clients_Web accountsClients = new Accounts_Clients_Web
            {
                Title = theTitle,
                CDS_Number = r.ToString(),
                AccountType = "I",
                BrokerCode = "CORP",
                Surname = theSurname,
                Forenames = theName,
                IDNoPP = idNums,
                DOB = DateTime.Parse(theDOB),
                Gender = theGender,
                Nationality = thenationality,
                Country = theCountry,
                Email = email,
                Div_Bank = bank,
                Div_AccountNo = accountNum,
                Middlename = "",
                Initials = "",
                IDtype = "",
                Add_1 = adress_yangu,
                Add_2 = "",
                Add_3 = "",
                Add_4 = "",
                City = "",
                Tel = mobile,
                Mobile = mobile,
                Category = "",
                Custodian = "",
                TradingStatus = "DEALING ALLOWED",
                Industry = "",
                Tax = "",
                Div_Branch = branch,
                Cash_Bank = "",
                Cash_Branch = "",
                Cash_AccountNo = "",
                Update_Type = "",
                Created_By = "",
                AccountState = "",
                Comments = "",
                DivPayee = "",
                SettlementPayee = "",
                Account_class = "",
                idnopp2 = "",
                idtype2 = "",
                client_image2 = "",
                documents2 = "",
                isin = "",
                sttupdate = true,
                company_code = "",
                mobile_money = "",
                mobile_number = "",
                Attached_Documents = "",
                Date_Created = DateTime.Now
            };



            _cdDataContext.Accounts_Clients_Web.Add(accountsClients);
            _cdDataContext.SaveChanges();

            var subscriber = new Vatenkecis
            {
                Email = email,
                Username = email,
                CdsNumber = GetCdsNumberFROMIDNUM(idNums),
                Password = password,
                Active = true,
                Date = DateTime.Now
            };
            sendmail(email, "You have successfully created C-Trade Account. CDS Number " +
                GetCdsNumberFROMIDNUM(idNums), "Access Account Opened");
            _cdscDbContext.Vatenkecis.Add(subscriber);
            _cdscDbContext.SaveChanges();

            return Json(1, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(ex, JsonRequestBehavior.AllowGet);
            //}
        }

        public JsonResult AccountMaintenance(string cdsNum, string theAddress, string theCountry, string theTelephone, string theMobile, string theEmail, string theAccName, string theAccNum, string theBank, string theBranch,
                           string theMobileMoney, string theMobileMoneyNumber)
        {
            var found = _cdDataContext.Account_Creation.FirstOrDefault(x => x.CDSC_Number == cdsNum);

            if (found != null)
            {
                found.Address1 = theAddress;
                found.Country = theCountry;
                found.TelephoneNumber = theTelephone;
                found.Emailaddress = theEmail;
                found.Accountnumber = theAccNum;
                found.Bank = theBank;
                found.Branch = theBranch;

                try
                {
                    _cdDataContext.SaveChanges();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckWhoRegistered(string any)
        {
            var rets = _cdDataContext.Accounts_Clients.FirstOrDefault(x => x.Email.Trim() == any || x.CDS_Number == any.Trim());
            if (rets != null)
            {
                var mobAccount = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Email == any.Trim() || x.CdsNumber == any.Trim());
                if (mobAccount != null)
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                return Json(rets, JsonRequestBehavior.AllowGet);
            }
            //create new account
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        public JsonResult InvestorReg(string idNumber, string pass)
        {
            //            return 
            //            return Json(idNumber + "  " + pass, JsonRequestBehavior.AllowGet);
            //            x => x.Username.Trim() == "rfde@gmail.com" && x.Password.Trim() == "12341234"


            var cdDataContexts = new cdscDbContext();
            var usernameFound = cdDataContexts.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == idNumber.Trim() || x.CdsNumber.Trim() == idNumber.Trim()) && x.Password == pass.Trim());


            if (usernameFound != null)
            {
                if (usernameFound.Active == false)
                {
                    return Json(8, JsonRequestBehavior.AllowGet);
                }
                //                return Json("2", JsonRequestBehavior.AllowGet);
                var user = _cdDataContext.Accounts_Clients.FirstOrDefault(x => (x.Email.Trim() == idNumber.Trim() || x.CDS_Number.Trim() == idNumber.Trim()));
                if (user != null)
                {
                    Random generator = new Random();
                    string GenerateRandomNo = generator.Next(1, 10000).ToString("D4");
                    var rets =
                        _cdDataContext.Accounts_Clients.Where(x => (x.Email.Trim() == idNumber.Trim() || x.CDS_Number.Trim() == idNumber.Trim()))
                            .OrderByDescending(x => x.ID)
                            .Select(c => new
                            {
                                id = c.CDS_Number,
                                brokerName = c.Custodian,
                                broker = c.BrokerCode,
                                cds = c.CDS_Number,
                                email = c.Email,
                                name = c.Surname + " " + c.Forenames,
                                phone = c.Mobile,
                                pin = GenerateRandomNo
                            });

                    String sqlx = "";
                    foreach (var p in rets)
                    {
                        var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                        sqlx = "Update Vatenkecis set PIN ='" + GenerateRandomNo + "' where CdsNumber='" + p.cds.ToString() + "' ";
                        //Console.WriteLine("Hello World!" + sqlx);
                        //return Json(sqlx, JsonRequestBehavior.AllowGet);
                        //messagesend_MOBI(p.phone, "Your pin is " + GenerateRandomNo); 
                        using (SqlConnection connectionsx = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                            connectionsx.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                        //connectionsx.Close();
                        break;
                    }

                    /*if(rets != null)
                    {
                    string subject = "CTradeMobile login pin";
                    string emailBody = "Your one time pin is " + GenerateRandomNo;
                    sendmail(user.Email, subject, emailBody);
                    }*/

                    return Json(rets, JsonRequestBehavior.AllowGet);
                }
                return Json("No email in accounts creation", JsonRequestBehavior.AllowGet);
            }
            //1. Checking from Accounts_Creation
            return Json("No email in registrations", JsonRequestBehavior.AllowGet);
        }
        public JsonResult InvestorRegAuto(string idNumber, string pass)
        {
            //            return 
            //            return Json(idNumber + "  " + pass, JsonRequestBehavior.AllowGet);
            //            x => x.Username.Trim() == "rfde@gmail.com" && x.Password.Trim() == "12341234"


            var cdDataContexts = new cdscDbContext();
            var usernameFound = cdDataContexts.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == idNumber.Trim() || x.CdsNumber.Trim() == idNumber.Trim()) && x.Password == pass.Trim());

            if (usernameFound != null)
            {
                if (usernameFound.Active == false)
                {
                    return Json(8, JsonRequestBehavior.AllowGet);
                }
                //                return Json("2", JsonRequestBehavior.AllowGet);
                var user = _cdDataContext.Accounts_Clients.FirstOrDefault(x => (x.Email.Trim() == idNumber.Trim() || x.CDS_Number.Trim() == idNumber.Trim()));
                if (user != null)
                {
                    Random generator = new Random();
                    string GenerateRandomNo = generator.Next(1, 10000).ToString("D4");
                    var rets =
                        _cdDataContext.Accounts_Clients.Where(x => (x.Email.Trim() == idNumber.Trim() || x.CDS_Number.Trim() == idNumber.Trim()))
                            .OrderByDescending(x => x.ID)
                            .Select(c => new
                            {
                                id = c.CDS_Number,
                                brokerName = c.Custodian,
                                broker = c.BrokerCode,
                                cds = c.CDS_Number,
                                email = c.Email,
                                name = c.Surname + " " + c.Forenames,
                                phone = c.Mobile,
                                pin = GenerateRandomNo
                            });

                    String sqlx = "";
                    foreach (var p in rets)
                    {

                        var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                        sqlx = "Update Vatenkecis set PIN ='" + GenerateRandomNo + "' where CdsNumber='" + p.cds.ToString() + "' ";
                        using (SqlConnection connectionsx = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                            connectionsx.Open();
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                        }
                        //connectionsx.Close();
                        break;
                    }
                    try
                    {
                        SmtpClient client = new SmtpClient();
                        client.Port = 587;
                        client.Host = "smtp.gmail.com";
                        client.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        client.Timeout = 30000;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("escrowctrade@gmail.com", "asdfghjkl2017");
                        MailMessage mm = new MailMessage();
                        mm.BodyEncoding = Encoding.UTF8;
                        mm.From = new MailAddress("info@ctrade.co.zw");
                        mm.To.Add(user.Email);
                        mm.Subject = "CTradeMobile login pin";
                        mm.Body = "Your OTP is " + GenerateRandomNo;
                        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                        client.Send(mm);
                        return Json(rets, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception e)
                    {
                        return Json("Error sending OTP Please try again", JsonRequestBehavior.AllowGet);
                    }
                }
                return Json("No email in accounts creation", JsonRequestBehavior.AllowGet);
            }
            //1. Checking from Accounts_Creation
            return Json("No email in registrations", JsonRequestBehavior.AllowGet);
        }

        string fileName = "C:\\uss\\Loggingdatarangu.txt";
        private void writetofile(String mssg)
        {

            StreamWriter objWriter3 = new System.IO.StreamWriter(fileName, true);
            objWriter3.WriteLine("Any Message ipapapa" + mssg);
            objWriter3.Close();
        }

        public string messagesend_MOBI(string mobile, string message)
        {
            String my_rteturn = "";
            try
            {
                string mob_number = mobile.Replace(" ", "");
                if (mob_number.StartsWith("0") == true)
                {
                    mob_number = Regex.Replace(mob_number, "^0", "263");
                }
                else if (mob_number.StartsWith("263") == false)
                {
                    mob_number = "263" + mob_number;
                }
                mob_number = "263772166492";
                System.Net.WebClient client = new System.Net.WebClient();
                String url_req = "http://etext.co.zw/sendsms.php?user=263773360785&password=simbaj80&mobile=" + mob_number.ToString() + "&senderid=C-TRADE&message=" + message + "";
                my_rteturn = client.DownloadString(url_req);
                writetofile("Phone " + mob_number + " " + my_rteturn + " " + url_req);
            }
            catch (Exception ex)
            {
                writetofile(ex.ToString());
                my_rteturn = "";
            }
            return my_rteturn;
        }

        public JsonResult Subscriptions(int id)
        {
            var rets = _cdscDbContext.Products.Where(x => x.Active).Select(c => new
            {
                id = c.Id,
                name = c.Name
            });
            return Json(rets, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MySubscriptions(int id)
        {

            var ret = _cdscDbContext.SubscriberProducts.Join(_cdscDbContext.Products, c => c.ProductId, cd => cd.Id,
                (c, cd) => new
                {
                    Name = cd.Name,
                    Id = c.Id,
                    ProductId = cd.Id,
                    SubscriberId = c.SubscriberId
                }).Where(cd => cd.SubscriberId == id);

            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        public string UpdateBroker(string broker, string cdsnumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            string sqlx = "Update Accounts_Clients set BrokerCode ='" + broker + "' where CDS_Number='" + cdsnumber + "' ";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Successfully Updated";

            }
            return returnstring;
        }

        public string UpdateCancelOrder(string orderType, string cdsnumber, string ordernumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            string sqlx = "Update Pre_Order_Live set OrderStatus ='PENDING CANCELLATION' where OrderNo ='" + ordernumber
                + "' and CDS_AC_No='" + cdsnumber + "' ";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Successfully Cancelled";

            }
            return returnstring;
        }

        public string updateBankDetails(string bank, string branch, string account, string cdsnumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            //string sqlx = "Update Pre_Order_Live set OrderStatus ='CANCELLED' where OrderNo ='" + ordernumber
            //    + "' and CDS_AC_No='" + cdsnumber + "' ";
            string sqlx = "update cds.dbo.Accounts_Clients set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Cash_AccountNo = '" + account + "' where CDS_Number = '" + cdsnumber + "' update CDS_ROUTER.dbo.Accounts_Clients set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Cash_AccountNo = '" + account + "' where CDS_Number = '" + cdsnumber + "' update cds_router.dbo.Accounts_Clients_Web set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Cash_AccountNo = '" + account + "' where CDS_Number = '" + cdsnumber + "'";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Bank details successfully updated.";

            }
            return returnstring;
        }

        public string updatePersonalDetails(string dob, string gender, string email, string address, string cdsnumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            //string sqlx = "Update Pre_Order_Live set OrderStatus ='CANCELLED' where OrderNo ='" + ordernumber
            //    + "' and CDS_AC_No='" + cdsnumber + "' ";
            string sqlx = "update cds.dbo.Accounts_Clients set  DOB = '" + dob + "', Gender = '" + gender + "', Email = '" + email + "', Add_1 = '" + address + "' where CDS_Number = '" + cdsnumber + "' update CDS_ROUTER.dbo.Accounts_Clients set DOB = '" + dob + "', Gender = '" + gender + "', Email = '" + email + "' , Add_1 = '" + address + "' where CDS_Number = '" + cdsnumber + "' update cds_router.dbo.Accounts_Clients_Web set DOB = '" + dob + "', Gender = '" + gender + "', Email = '" + email + "' , Add_1 = '" + address + "' where CDS_Number = '" + cdsnumber + "'";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Your details have been successfully updated. Please dial *727# again to trade";

            }
            return returnstring;
        }

        public string updateAccountDetails(string bank, string branch, string account, string address, string mobile, string cdsnumber)
        {
            string returnstring = "";
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            //string sqlx = "Update Pre_Order_Live set OrderStatus ='CANCELLED' where OrderNo ='" + ordernumber
            //    + "' and CDS_AC_No='" + cdsnumber + "' ";
            string sqlx = "update cds.dbo.Accounts_Clients set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Add_1 = '" + address + "', Mobile ='" + mobile + "',  Cash_AccountNo = '" + account + "' where CDS_Number = '" + cdsnumber + "' update CDS_ROUTER.dbo.Accounts_Clients set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Cash_AccountNo = '" + account + "', Add_1 = '" + address + "', Mobile ='" + mobile + "' where CDS_Number = '" + cdsnumber + "' update cds_router.dbo.Accounts_Clients_Web set Cash_Bank = '" + bank + "', Cash_Branch = '" + branch + "', Cash_AccountNo = '" + account + "', Add_1 = '" + address + "', Mobile ='" + mobile + "' where CDS_Number = '" + cdsnumber + "'";

            using (SqlConnection connectionsx = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlx, connectionsx);
                connectionsx.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                returnstring = "Account details successfully updated.";

            }
            return returnstring;
        }

        public JsonResult NewLog(string idNumber = null)
        {
            var getBrk = "select ac.CDS_Number as id, cc.Company_name as brokerCode, ac.CDS_Number as CdsNumber from [CDS_ROUTER].[dbo].Accounts_Clients ac join [CDS_ROUTER].[dbo].Client_Companies cc on ac.BrokerCode = cc.Company_Code where ac.IDNoPP='" + idNumber + "'";

            var newLogs = new List<NewLog>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    NewLog newLog = new NewLog();
                    newLog.Id = rdr["id"].ToString();
                    newLog.BrokerCode = rdr["brokerCode"].ToString();
                    newLog.CdsNumber = rdr["CdsNumber"].ToString();
                    newLogs.Add(newLog);
                }

                try
                {
                    var jsonResult = Json(newLogs, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }
        }

        public JsonResult Login(string username = null, string password = null)
        {
            if (username != null || password != null)
            {
                var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => (x.Username.Trim() == username.Trim() || x.CdsNumber.Trim() == username.Trim()) && (x.Password.Trim() == password.Trim() && x.Active));
                if (usernameFound != null)
                {
                    var ret = _cdscDbContext.Vatenkecis.Where(x => (x.Username.Trim() == username.Trim() || x.CdsNumber.Trim() == username.Trim()) && x.Password.Trim() == password.Trim()).OrderByDescending(x => x.Id).Select(v => new
                    {
                        id = v.Id,
                        username = v.Username,
                        email = v.Email,
                        cds = v.CdsNumber,

                        //fullname = getAccountFullname(cds)
                    }).Take(1);

                    return Json(ret, JsonRequestBehavior.AllowGet);
                }
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NewLogin(string username = null, string password = null)
        {

            if (username != null || password != null)
            {

                var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                var CompShares = new List<VatenkeciNew>();

                var sql = "SELECT t.* , ut.BrokerCode  FROM [CDSC].[dbo].[Vatenkecis] t , [CDS_ROUTER].[dbo].[Accounts_Clients] ut where t.Email ='" + username + "' and t.Password = '" + password + "' and t.CdsNumber = ut.CDS_Number";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VatenkeciNew recordSummary = new VatenkeciNew();
                        recordSummary.id = int.Parse(rdr["id"].ToString());
                        recordSummary.username = rdr["username"].ToString();
                        recordSummary.email = rdr["email"].ToString();
                        recordSummary.broker = rdr["BrokerCode"].ToString();
                        recordSummary.cds = rdr["CdsNumber"].ToString();
                        recordSummary.Active = Convert.ToBoolean(rdr["Active"].ToString());
                        CompShares.Add(recordSummary);
                    }
                }

                if (CompShares.Any())
                {
                    return Json(CompShares, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);

        }
        // GET: Subscriber
        public JsonResult Registration(string email = null, string username = null, string password = null)
        {
            var usernameFound = _cdscDbContext.Vatenkecis.FirstOrDefault(x => x.Username == username && x.Active && x.Email == email);
            if (usernameFound == null)
            {
                if (email != null || username != null || password != null)
                {
                    var subscriber = new Vatenkecis
                    {
                        Email = email,
                        Username = username,
                        CdsNumber = username,
                        Password = password,
                        Active = true,
                        Date = DateTime.Now
                    };
                    try
                    {
                        _cdscDbContext.Vatenkecis.Add(subscriber);
                        _cdscDbContext.SaveChanges();

                        sendmail(email, "You have successfully created C-Trade Account. Kindly note that this is not a trading account, its just an account to access market information. You will be requested to open a trading  account if you want to trade", "Access Account Opened");
                        return Json(1, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception exception)
                    {
                        return Json(exception.ToString(), JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            return Json(2, JsonRequestBehavior.AllowGet);
        }
        public string SendMailAgain(string Message, string Subject)
        {
            try
            {
                bool retVal;
                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();

                MailAddress fromAddres = new MailAddress("info@ctrade.co.zw", "Test");
                message.From = fromAddres;
                // To address collection of MailAddress
                message.To.Add("makazatinashe2000@gmail.com");
                message.Subject = Subject;
                smtpClient.Host = "192.168.3.241";
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("info@ctrade.co.zw", "asdfghjkl2017");
                message.IsBodyHtml = true;
                // Message body content
                message.Body = Message;

                smtpClient.Send(message);

                retVal = true;
                message.Dispose();
                return "Message Sent";
            }
            catch (Exception ex)
            {
                return "Error " + ex;
            }

        }

        public string sendmail(string emailAdd, string subject, string emailbody)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                //client.Host = "smtp.office365.com";
                client.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Timeout = 30000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("escrowctrade@gmail.com", "asdfghjkl2017");
                //client.Credentials = new System.Net.NetworkCredential("info@ctrade.co.zw", "asdfghjkl.2017");
                MailMessage mm = new MailMessage();
                mm.BodyEncoding = Encoding.UTF8;
                mm.From = new MailAddress("info@ctrade.co.zw");
                mm.To.Add(emailAdd);
                mm.Subject = subject;
                mm.Body = emailbody;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);

                return "1";
            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public void SendMail2(string emailAddess, string message, string subject)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("makazatinashe2000@gmail.com", "Lockthemout@2017");

                MailMessage mm = new MailMessage();
                mm.BodyEncoding = Encoding.UTF8;
                mm.From = new MailAddress("makazatinashe2000@gmail.com");
                mm.To.Add(emailAddess);
                mm.Subject = subject;
                mm.Body = message;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                //                return "1";
            }
            catch (Exception e)
            {
                //                return e.ToString();
            }
        }
        public JsonResult CashTrans(string cdsNumber = null)
        {
            var ret = _cdscDbContext.CashTrans.Where(x => x.CDS_Number.Trim() == cdsNumber.Trim()).OrderByDescending(x => x.ID).Select(v => new
            {
                id = v.ID,
                desc = v.Description,
                type = v.TransType,
                ammount = v.Amount,
                date = v.DateCreated,
                status = v.TransStatus
            });
            List<CashTranss> my = new List<CashTranss>();
            foreach (var p in ret)
            {
                my.Add(new CashTranss() { id = p.id.ToString(), desc = p.desc, type = p.type, ammount = p.ammount, date = p.date.ToString("dd MMM yyyy"), status = p.status });
            }

            return Json(my, JsonRequestBehavior.AllowGet);
        }

        


        public JsonResult getCashBalance(string cdsNumber = null)
        {
            var CashBalancc = new List<CashBalancV2>();
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var ComptotalAccount = 0.00;
            var sql = @"
                    SELECT
                  isnull(SUM(totAllShares * currePrice), 0) as MyPotValue,
                  isnull(SUM(totAllShares * PrevPrice), 0) as MyPrevPotValue,
                  ISNULL(SUM((totAllShares * currePrice) - (prevdayQuantity *PrevPrice) ),0) AS MyProfitLoss,
                  (select isnull(sum(Amount), 0) from [CDSC].[dbo].CashTrans where CDS_Number = '" + cdsNumber + @"' ) as CashBal , 
                   (select isnull(sum(Amount), 0) from [CDSC].[dbo].CashTrans where CDS_Number = '" + cdsNumber + @"' and [TransStatus] = '1'  and TransType='SELL') as VirtCashBal ,
                   (select isnull(sum(Amount), 0)-(SELECT  isnull(SUM(AMOUNT),0) FROM CDSC.DBO.CashTrans  WHERE CDS_NUMBER='" + cdsNumber + @"' AND TransType='SELL' and TransStatus='1') from [CDSC].[dbo].CashTrans where CDS_Number = '" + cdsNumber + @"' ) as ActualCashBal
                  FROM [CDSC].[dbo].[PortfolioAll] WHERE CDS_NUMBER = '" + cdsNumber + @"'
                ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var ix = 1;
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CashBalancV2 recordSummary = new CashBalancV2();
                    recordSummary.id = ix.ToString();
                    recordSummary.CashBal = Force2DecimalPlaces(rdr["CashBal"].ToString());
                    recordSummary.VirtCashBal = Force2DecimalPlaces(rdr["VirtCashBal"].ToString());
                    recordSummary.ActualCashBal = Force2DecimalPlaces(rdr["ActualCashBal"].ToString());
                    recordSummary.MyPotValue = Force4DecimalPlaces(rdr["MyPotValue"].ToString());
                    recordSummary.MyProfitLoss = Force4DecimalPlaces(rdr["MyProfitLoss"].ToString());
                    recordSummary.MyPrevPotValue = Force4DecimalPlaces(rdr["MyPrevPotValue"].ToString());
                    ComptotalAccount = double.Parse(rdr["CashBal"].ToString()) + double.Parse(rdr["MyPotValue"].ToString());
                    recordSummary.totalAccount = Force4DecimalPlaces(ComptotalAccount.ToString());
                    CashBalancc.Add(recordSummary);
                }
            }
            return Json(CashBalancc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getCashBalanceForex(string cdsNumber = null)
        {
            var CashBalancc = new List<CashBalancV22>();
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var ComptotalAccount = 0.00;
            var sql = @" select isnull(sum(Amount), 0) as ActualCashBal from [CDSC].[dbo].CashTrans_forex where CDS_Number = '" + cdsNumber + @"' and [TransStatus] = '1' ";          
               
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var ix = 1;
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CashBalancV22 recordSummary = new CashBalancV22();
                      recordSummary.ActualCashBal = Force2DecimalPlaces(rdr["ActualCashBal"].ToString());
                    CashBalancc.Add(recordSummary);
                }
            }
            return Json(CashBalancc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MarketWatchbidoffer()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcherNeww = new List<MarketWatchNeww>();

            //var sql = "SELECT * FROM [testcds_ROUTER].[dbo].[MarketWatch]";
            var sql = "SELECT a.*, b.fnam as full_company_name FROM [testcds_ROUTER].[dbo].[MarketWatch] a, testcds_ROUTER.dbo.para_company b WHERE a.company = b.Company";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatchNeww recordSummary = new MarketWatchNeww();
                    recordSummary.market_company = rdr["company"].ToString();
                    recordSummary.market_bbv = rdr["Volume"].ToString();
                    recordSummary.market_bp = Force4DecimalPlaces(rdr["Bid"].ToString());
                    recordSummary.market_va = rdr["Volume Sell"].ToString();
                    recordSummary.market_ap = Force4DecimalPlaces(rdr["Ask"].ToString());
                    recordSummary.market_vwap = Force4DecimalPlaces(rdr["Average Price"].ToString());
                    recordSummary.market_lp = Force4DecimalPlaces(rdr["Lastmatched"].ToString());
                    recordSummary.market_lv = rdr["lastvolume"].ToString();
                    recordSummary.market_tv = rdr["TotalVolume"].ToString();
                    recordSummary.market_to = Force4DecimalPlaces(rdr["Turnover"].ToString());
                    recordSummary.market_open = Force4DecimalPlaces(rdr["Open"].ToString());
                    recordSummary.market_high = Force4DecimalPlaces(rdr["High"].ToString());
                    recordSummary.market_low = Force4DecimalPlaces(rdr["Low"].ToString());
                    recordSummary.market_change = Force4DecimalPlaces(rdr["Change"].ToString());
                    recordSummary.market_per_change = Force4DecimalPlaces(Math.Round(double.Parse(rdr["percchange"].ToString()), 4).ToString());
                    recordSummary.details = rdr["company"].ToString();
                    recordSummary.FullCompanyName = rdr["full_company_name"].ToString();
                    recordSummary.Category = rdr["Category"].ToString();
                    //get bids
                    var retBids = _AtsDbContext.LiveTradingMasters.OrderByDescending(y => y.BasePrice).Where(x => x.OrderType == "BUY" && x.Company == recordSummary.market_company).Select(v => new
                    {
                        idd = v.OrderNo,
                        volumed = v.Quantity,
                        priced = v.BasePrice
                    });
                    var bidPriceser = new List<bidPrices_correct>();

                    foreach (var p in retBids)
                    {
                        bidPrices_correct recordSum1 = new bidPrices_correct();
                        recordSum1.id = p.idd.ToString();
                        recordSum1.price = Force4DecimalPlaces(p.priced.ToString());
                        recordSum1.volume = p.volumed.ToString();
                        bidPriceser.Add(recordSum1);
                        recordSummary.bids = bidPriceser;
                    }


                    //get bids

                    //get offers
                    var retOffers = _AtsDbContext.LiveTradingMasters.OrderBy(y => y.BasePrice).Where(x => x.OrderType == "SELL" && x.Company == recordSummary.market_company).Select(v => new
                    {
                        ido = v.OrderNo,
                        volumeo = v.Quantity,
                        priceo = v.BasePrice
                    });
                    var offerPriceser = new List<offerPrices>();

                    foreach (var p in retOffers)
                    {
                        offerPrices recordSum2 = new offerPrices();
                        recordSum2.id = p.ido.ToString();
                        recordSum2.price = Force4DecimalPlaces(p.priceo.ToString());
                        recordSum2.volume = p.volumeo.ToString();
                        offerPriceser.Add(recordSum2);
                        recordSummary.asks = offerPriceser;
                    }


                    //get offers

                    marketWatcherNeww.Add(recordSummary);
                }
            }
            return Json(marketWatcherNeww, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MarketWatchByCategory(string category)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
            var marketWatcherNeww = new List<MarketWatchNeww>();

            //var sql = "SELECT * FROM [testcds_ROUTER].[dbo].[MarketWatch]";
            var sql = "SELECT a.*, b.fnam as full_company_name FROM [testcds_ROUTER].[dbo].[MarketWatch] a, testcds_ROUTER.dbo.para_company b WHERE a.company = b.Company and a.category ='" + category + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MarketWatchNeww recordSummary = new MarketWatchNeww();
                    recordSummary.market_company = rdr["company"].ToString();
                    recordSummary.market_bbv = rdr["Volume"].ToString();
                    recordSummary.market_bp = Force4DecimalPlaces(rdr["Bid"].ToString());
                    recordSummary.market_va = rdr["Volume Sell"].ToString();
                    recordSummary.market_ap = Force4DecimalPlaces(rdr["Ask"].ToString());
                    recordSummary.market_vwap = Force4DecimalPlaces(rdr["Average Price"].ToString());
                    recordSummary.market_lp = Force4DecimalPlaces(rdr["Lastmatched"].ToString());
                    recordSummary.market_lv = rdr["lastvolume"].ToString();
                    recordSummary.market_tv = rdr["TotalVolume"].ToString();
                    recordSummary.market_to = Force4DecimalPlaces(rdr["Turnover"].ToString());
                    recordSummary.market_open = Force4DecimalPlaces(rdr["Open"].ToString());
                    recordSummary.market_high = Force4DecimalPlaces(rdr["High"].ToString());
                    recordSummary.market_low = Force4DecimalPlaces(rdr["Low"].ToString());
                    recordSummary.market_change = Force4DecimalPlaces(rdr["Change"].ToString());
                    recordSummary.market_per_change = Force4DecimalPlaces(Math.Round(double.Parse(rdr["percchange"].ToString()), 4).ToString());
                    recordSummary.details = rdr["company"].ToString();
                    recordSummary.FullCompanyName = rdr["full_company_name"].ToString();
                    recordSummary.Category = rdr["Category"].ToString();
                    //get bids
                    var retBids = _AtsDbContext.LiveTradingMasters.OrderByDescending(y => y.BasePrice).Where(x => x.OrderType == "BUY" && x.Company == recordSummary.market_company).Select(v => new
                    {
                        idd = v.OrderNo,
                        volumed = v.Quantity,
                        priced = v.BasePrice
                    });
                    var bidPriceser = new List<bidPrices_correct>();

                    foreach (var p in retBids)
                    {
                        bidPrices_correct recordSum1 = new bidPrices_correct();
                        recordSum1.id = p.idd.ToString();
                        recordSum1.price = Force4DecimalPlaces(p.priced.ToString());
                        recordSum1.volume = p.volumed.ToString();
                        bidPriceser.Add(recordSum1);
                        recordSummary.bids = bidPriceser;
                    }


                    //get bids

                    //get offers
                    var retOffers = _AtsDbContext.LiveTradingMasters.OrderBy(y => y.BasePrice).Where(x => x.OrderType == "SELL" && x.Company == recordSummary.market_company).Select(v => new
                    {
                        ido = v.OrderNo,
                        volumeo = v.Quantity,
                        priceo = v.BasePrice
                    });
                    var offerPriceser = new List<offerPrices>();

                    foreach (var p in retOffers)
                    {
                        offerPrices recordSum2 = new offerPrices();
                        recordSum2.id = p.ido.ToString();
                        recordSum2.price = Force4DecimalPlaces(p.priceo.ToString());
                        recordSum2.volume = p.volumeo.ToString();
                        offerPriceser.Add(recordSum2);
                        recordSummary.asks = offerPriceser;
                    }


                    //get offers

                    marketWatcherNeww.Add(recordSummary);
                }
            }
            return Json(marketWatcherNeww, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getIPOISSUES()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var para_hold = new List<para_holding>();

            var sql = "SELECT * FROM para_holding WHERE IPOSTATUS = '0' ORDER BY ID_ DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    para_holding recordSummary = new para_holding();

                    recordSummary.Category = rdr["Category"].ToString();
                    recordSummary.Issuer_Code = rdr["Issuer_Code"].ToString();
                    recordSummary.Debt_Type = rdr["Debt_Type"].ToString();
                    recordSummary.Security_Description = rdr["Security_Description"].ToString();
                    recordSummary.GlobalLimit = Decimal.Parse(rdr["GlobalLimit"].ToString());
                    recordSummary.IndividualLimit = Decimal.Parse(rdr["IndividualLimit"].ToString());
                    recordSummary.DailyLimit = Decimal.Parse(rdr["DailyLimit"].ToString());
                    recordSummary.BidRatio = Decimal.Parse(rdr["BidRatio"].ToString());
                    recordSummary.IPOSTATUS = int.Parse(rdr["IPOSTATUS"].ToString());
                    recordSummary.globLowerlimit = Decimal.Parse(rdr["globLowerlimit"].ToString());
                    recordSummary.InterestRate = Decimal.Parse(rdr["InterestRate"].ToString());
                    //recordSummary.IPOClosedDate = DateTime.Parse(rdr["IPOClosedDate"].ToString());
                    //recordSummary.Transaction_Limit = Decimal.Parse(rdr["Transaction_Limit"].ToString());
                    //recordSummary.firstlimit = Decimal.Parse(rdr["FirstLimit"].ToString());
                    //recordSummary.multiples = Decimal.Parse(rdr["Multiples"].ToString());
                    para_hold.Add(recordSummary);
                }
            }
            return Json(para_hold, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyOrders(string cdsNumber = null)
        {
            // var retID = 0;
            var rets = _AtsDbContext.Pre_Order_Live.Where(x => x.CDS_AC_No == cdsNumber.Trim()).OrderByDescending(x => x.OrderNo).Select(c => new
            {
                //id = retID+1,
                id = c.OrderNo,
                counter = c.Company,
                type = c.OrderType,
                volume = c.Quantity.ToString(),
                price = c.BasePrice.ToString(),
                date_ = c.Create_date.ToString(),
                status = c.OrderStatus,
                desc = c.trading_platform + " - " + c.Broker_Code
            });
            List<Pre_Order_Lives> my = new List<Pre_Order_Lives>();
            foreach (var p in rets)
            {
                my.Add(new Pre_Order_Lives() { date = p.date_, id = p.id.ToString(), counter = p.counter.ToString(), type = p.type.ToString(), volume = p.volume.ToString(), price = p.price.ToString(), status = p.status.ToString(), desc = p.desc.ToString() });
            }
            return Json(my, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyOrders1(string cdsNumber = null)
        {
            // var retID = 0;
            var order = (from c in _AtsDbContext.Pre_Order_Live.Where(x => x.CDS_AC_No == cdsNumber.Trim())
                         join t in _AtsDbContext.para_company on c.Company equals t.Company
                         let companyFullName = t.fnam
                         let id = c.OrderNo
                         let counter = c.Company
                         let type = c.OrderType
                         let volume = c.Quantity.ToString()
                         let price = c.BasePrice.ToString()
                         let date_ = c.Create_date.ToString()
                         let status = c.OrderStatus
                         let desc = c.trading_platform + " - " + c.Broker_Code
                         let ordernumber = c.OrderNumber
                         select new
                         {
                             id,
                             companyFullName,
                             counter,
                             type,
                             volume,
                             price,
                             date_,
                             status,
                             desc,
                             ordernumber,
                         }).ToList().OrderByDescending(a => a.id);

            List<Pre_Order_Lives> my = new List<Pre_Order_Lives>();
            foreach (var p in order)
            {
                my.Add(new Pre_Order_Lives() { date = p.date_, id = p.id.ToString(), counter = p.counter.ToString(), type = p.type.ToString(), volume = p.volume.ToString(), price = p.price.ToString(), status = p.status.ToString(), desc = p.desc.ToString(), fullname = p.companyFullName.ToString(), ordernumber = p.ordernumber.ToString() });
            }
            //my = my.OrderByDescending(a => a.id).ToList();
            return Json(my, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyIPOOrders(string cdsNumber = null)
        {
            // var retID = 0;
            var rets = _cdscDbContext.PreOrderLivesIPOes.Where(x => x.CDS_AC_No == cdsNumber.Trim()).OrderByDescending(x => x.ID).Select(c => new
            {
                //id = retID+1,
                id = c.ID,
                counter = c.Company,
                type = c.OrderType,
                volume = c.Quantity.ToString(),
                price = c.BasePrice.ToString(),
                date = c.Create_date,
                status = c.OrderStatus,
                desc = c.Source + " - " + c.Broker_Code
            });
            List<PreOrderLivesIPOTest> my = new List<PreOrderLivesIPOTest>();
            foreach (var p in rets)
            {
                my.Add(new PreOrderLivesIPOTest() { id = p.id.ToString(), counter = p.counter.ToString(), type = p.type.ToString(), volume = p.volume.ToString(), price = p.price.ToString(), date = p.date.ToString("dd MMM yyyy"), status = p.status.ToString(), desc = p.desc.ToString() });
            }
            return Json(my, JsonRequestBehavior.AllowGet);
        }
        public decimal getTransPrice(decimal transID)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            decimal pricee = 0;
            var sql = "SELECT ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = a.Reference) AND (Account1 = a.CDS_Number)) OR ((ReportID = a.Reference) AND (Account2 = a.CDS_Number))),0) AS THEPRICE FROM CDS_ROUTER.DBO.trans A  WHERE A.Trans_ID='" + transID + "'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pricee = decimal.Parse(rdr["THEPRICE"].ToString());
                }
            }
            return pricee;
        }
        public JsonResult getMyPortFolioOriginal(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortfolio>();

            var sql = "select * from cdsc.dbo.MyportfolioAll d where d.CDS_Number='" + cdsNumber + "'";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyPortfolio recordSummary = new MyPortfolio();
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = Force4DecimalPlaces(rdr["TotPottValue"].ToString());
                    recordSummary.totalPrevPortValue = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());

                    recordSummary.returns = Force4DecimalPlaces(Math.Round(double.Parse(rdr["totReturnValue"].ToString()), 4).ToString());
                    //get my buys
                    ////var retBids = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares > 0 && x.Company == recordSummary.counter).Select(v => new
                    ////{
                    ////    comp = v.Company,
                    ////    volum = v.Shares,
                    ////    pric = v.Shares,
                    ////    totVal = v.Shares
                    ////});
                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMyPortFolioNew(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortfolioNew>();

            //var sql = "select  from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "'";

            var sql = "select d.*, ut.fnam as fullCompanyName from cdsc.dbo.PortfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number='" + cdsNumber + "' and d.Company = ut.Company";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //Company CDS_Number  LastAcDate totAllShares    prevdayQuantity currePrice  PrevPrice Uncleared   Net
                    //prev_numbershares
                    MyPortfolioNew recordSummary = new MyPortfolioNew();
                    string curr_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["currePrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    string prev_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["prevdayQuantity"].ToString())), 4).ToString());
                    double ret_Port = Math.Round(double.Parse(curr_Port), 4) - Math.Round(double.Parse(prev_Port), 4);
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.prev_numbershares = rdr["prevdayQuantity"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = curr_Port;
                    recordSummary.totalPrevPortValue = prev_Port;
                    recordSummary.returns = Force4DecimalPlaces(ret_Port.ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());
                    recordSummary.companyFullName = rdr["fullCompanyName"].ToString();

                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select ,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    recordSummary.BuyDetail = BuysBymes;
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select ,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMyPortFolio(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortfolioNew>();

            var sql = "select d.*, ut.fnam as fullCompanyName from cdsc.dbo.PortfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number='" + cdsNumber + "' and d.Company = ut.Company";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyPortfolioNew recordSummary = new MyPortfolioNew();
                    string curr_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["currePrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    string prev_Port = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["prevdayQuantity"].ToString())), 4).ToString());
                    double ret_Port = Math.Round(double.Parse(curr_Port), 4) - Math.Round(double.Parse(prev_Port), 4);
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.prev_numbershares = rdr["prevdayQuantity"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = curr_Port;
                    recordSummary.totalPrevPortValue = prev_Port;
                    recordSummary.returns = Force4DecimalPlaces(ret_Port.ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());
                    recordSummary.companyFullName = rdr["fullCompanyName"].ToString();



                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMyPortFolio1(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortfolio>();

            var sql = "select d.*, ut.fnam as fullCompanyName from cdsc.dbo.MyportfolioAll d,testcds_ROUTER.dbo.para_company ut  where d.CDS_Number='" + cdsNumber + "' and d.Company = ut.Company";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyPortfolio recordSummary = new MyPortfolio();
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = Force4DecimalPlaces(rdr["TotPottValue"].ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());
                    recordSummary.totalPrevPortValue = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    recordSummary.companyFullName = rdr["fullCompanyName"].ToString();
                    recordSummary.returns = Force4DecimalPlaces(Math.Round(double.Parse(rdr["totReturnValue"].ToString()), 4).ToString());
                    //get my buys
                    ////var retBids = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares > 0 && x.Company == recordSummary.counter).Select(v => new
                    ////{
                    ////    comp = v.Company,
                    ////    volum = v.Shares,
                    ////    pric = v.Shares,
                    ////    totVal = v.Shares
                    ////});
                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public string getAccountFullname(string any = null)
        {
            var getBrk = "select ISNULL(ac.Surname,'') + ' ' + ISNULL(ac.Forenames,'') as fullName from [CDS_ROUTER].[dbo].Accounts_Clients ac where ac.CDS_Number='" + any + "'";
            var theFullName = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    theFullName = rdr["fullName"].ToString();
                }
                return theFullName;
            }
        }
        public JsonResult getPortfolioStatement(string cdsNumber = null, string company = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortStatement>();
            var addStr = "";
            if (company != null)
            {
                addStr = " and d.company='" + company + "'";
            }
            var sql = "select *,[DealShares]*[Average Price] as PurchaceValue,([Average Price]-[DEAL_PRICE])*[DealShares] as Returnss from cdsc.dbo.MyPortStatement d where d.CDS_Number='" + cdsNumber + "' " + addStr + "";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyPortStatement recordSummary = new MyPortStatement();
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.date = rdr["LastActDate"].ToString();
                    recordSummary.pricepershare = rdr["DEAL_PRICE"].ToString();
                    recordSummary.volume = rdr["DealShares"].ToString();
                    recordSummary.purchasevalue = rdr["PurchaceValue"].ToString();
                    recordSummary.currentmarketprice = rdr["Average Price"].ToString();
                    recordSummary.returns = rdr["Returnss"].ToString();

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGraphPrices(string company = null)
        {
            var rets = _AtsDbContext.CompanyLivePrices.Where(x => x.COMPANY == company.Trim()).OrderByDescending(x => x.id).Select(c => new
            {
                price = c.CurrentPrice,
                vol = c.ShareVOL
            }).Take(5);
            List<CompanyLivePricess> my = new List<CompanyLivePricess>();
            foreach (var p in rets)
            {
                my.Add(new CompanyLivePricess() { CurrentPrice = p.price.ToString(), currentVolume = p.vol.ToString() });
            }
            return Json(my, JsonRequestBehavior.AllowGet);
        }
        public string OrderPosting(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string source)

        {
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "";
            double basePrice = 0;
            var theOrderTrans = "";

            try
            {
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                if (orderType != null && orderType.Equals("Market"))
                {
                    orderPref = "M";
                    basePrice = 0;
                }
                else
                {
                    basePrice = double.Parse(price);
                    orderPref = "L";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.Company == company)
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                decimal shares = 0;
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {
                    var shareAvail =
                        cdsDbContext.trans.FirstOrDefault(x => x.CDS_Number == cdsNumber && x.Company == myCompany);

                    if (shareAvail != null)
                    {
                        var theShare =
                            cdsDbContext.trans.Where(x => x.CDS_Number == cdsNumber && x.Company == myCompany)
                                .Select(x => x.Shares)
                                .Sum();
                        if (theShare <= 0)
                        {
                            return "You have insufficient shares, check with your broker";
                        }
                        if (theShare < int.Parse(quantity))
                        {
                            return "You have insufficient shares, check with your broker";
                        }

                    }
                    else
                    {
                        return "You have insufficient shares, check with your broker";
                    }
                }


                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price) * decimal.Parse("1.01693");


                if (orderTrans.ToString().ToUpper().Equals("BUY"))
                {
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                    if (moneyAvail != null)
                    {
                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                //SAVING TO DB


                var orderStatus = "OPEN";
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now;
                var theQuantity = 0;


                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }


                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = "Day Order (DO)";
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = "",
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,

                        Affirmation = true
                    };
                    //save to cdsc tempPreorderLive too
                    var orderPreorderCdsc = new PreOrderLives
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        OrderNumber = orderNum,
                        Source = source
                    };
                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {
                        //                      var emailAdd = theBroker.Email;
                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        //                      SendMail2(emailAdd, "Your order was successfully posted", "Order Posting");
                        tempDbContext.PreOrderLives.Add(orderPreorderCdsc);
                        tempDbContext.SaveChanges();

                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {
                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error Occured trying to send order please try again" + e;
                    }
                }
                catch (Exception e)
                {
                    return "Assigning values => " + e.ToString();
                }

            }
            catch (Exception ex)
            {
                return "All errors => " + ex.ToString();
            }
        }
        public string GetBrokerFromCDS(string cds)
        {
            var getBrk =
                "SELECT TOP 1 BrokerCode FROM Accounts_Clients WHERE CDS_Number = '" +
                cds.Trim() + "'";

            var ret = "";

            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret += rdr["BrokerCode"];
                    }
                    try
                    {
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "1";
                    }
                }
                return "0";
            }
        }
        public string OrderPostingMobile(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string source)

        {
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "";
            double basePrice = 0;
            var theOrderTrans = "";

            try
            {
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                if (orderType != null && orderType.Equals("Market"))
                {
                    orderPref = "M";
                    basePrice = 0;
                }
                else
                {
                    basePrice = double.Parse(price);
                    orderPref = "L";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.fnam == company)
                        .FirstOrDefault(x => x.fnam == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                myCompany = theCompnay.Company;

                var theCds = cdsNumber + "";

                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                //if (theBroker1 == null)
                //{
                //    return "Enter valid broker";
                //}


                decimal shares = 0;
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {
                    var shareAvail =
                        cdsDbContext.trans.FirstOrDefault(x => x.CDS_Number == cdsNumber && x.Company == myCompany);

                    if (shareAvail != null)
                    {
                        var theShare = decimal.Parse(getCurrentBalance(company, cdsNumber));
                        //cdsDbContext.trans.Where(x => x.CDS_Number == cdsNumber && x.Company == myCompany)
                        //    .Select(x => x.Shares)
                        //    .Sum();
                        if (theShare <= 0)
                        {
                            return "You have insufficient shares, check with your broker";
                        }
                        if (theShare < int.Parse(quantity))
                        {
                            return "You have insufficient shares, check with your broker";
                        }

                    }
                    else
                    {
                        return "You have insufficient shares, check with your broker";
                    }
                }


                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price) * decimal.Parse("1.01693");
                if (orderTrans.ToString().ToUpper().Equals("BUY"))
                {
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                    if (moneyAvail != null)
                    {
                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                //SAVING TO DB


                var orderStatus = "OPEN";
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now;
                var theQuantity = 0;


                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }


                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = "Day Order (DO)";
                var brokerRef = broker + orderNumber;
                var contraBrokerId = "";
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = "",
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = "None",
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        FOK = false,
                        trading_platform = GetTradingPlaform(myCompany),
                        Affirmation = true
                    };
                    //save to cdsc tempPreorderLive too
                    var orderPreorderCdsc = new PreOrderLives
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        TimeInForce = timeInForce,
                        OrderQualifier = "None",
                        BrokerRef = brokerRef,
                        OrderNumber = orderNum,
                        Source = source
                    };
                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {
                        //                      var emailAdd = theBroker.Email;
                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        //                      SendMail2(emailAdd, "Your order was successfully posted", "Order Posting");

                        /*
                        *Saving to CDSC Table 
                        */
                        tempDbContext.PreOrderLives.Add(orderPreorderCdsc);
                        tempDbContext.SaveChanges();

                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {
                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "Your Order has been successfully placed";
                    }
                    catch (Exception e)
                    {
                        return e.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "Assigning values => " + e.ToString();
                }

            }
            catch (Exception ex)
            {
                return "All errors => " + ex.ToString();
            }
        }
        public string OrderPostingMobile1(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string expiresOn, string source)

        {
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "";
            double basePrice = 0;
            var theOrderTrans = "";

            try
            {
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                if (orderType != null && orderType.Equals("Market"))
                {
                    orderPref = "M";
                    basePrice = 0;
                }
                else
                {
                    basePrice = double.Parse(price);
                    orderPref = "L";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.fnam == company)
                        .FirstOrDefault(x => x.fnam == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                myCompany = theCompnay.Company;

                var theCds = cdsNumber + "";

                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                //if (theBroker1 == null)
                //{
                //    return "Enter valid broker";
                //}


                decimal shares = 0;
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {
                    var shareAvail =
                        cdsDbContext.trans.FirstOrDefault(x => x.CDS_Number == cdsNumber && x.Company == myCompany);

                    if (shareAvail != null)
                    {
                        var theShare =
                            cdsDbContext.trans.Where(x => x.CDS_Number == cdsNumber && x.Company == myCompany)
                                .Select(x => x.Shares)
                                .Sum();
                        if (theShare <= 0)
                        {
                            return "You have insufficient shares, check with your broker";
                        }
                        if (theShare < int.Parse(quantity))
                        {
                            return "You have insufficient shares, check with your broker";
                        }

                    }
                    else
                    {
                        return "You have insufficient shares, check with your broker";
                    }
                }


                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price) * decimal.Parse("1.01693");
                if (orderTrans.ToString().ToUpper().Equals("BUY"))
                {
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                    if (moneyAvail != null)
                    {
                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                //SAVING TO DB


                var orderStatus = "OPEN";
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                //var expiryDate =  DateTime.Now; 
                var expiryDate = DateTime.Now;
                DateTime testExpiryDate;

                if ((expiresOn != null || expiresOn != "") && (DateTime.TryParse(expiresOn, out testExpiryDate)))//if expires on date has been provided
                {
                    //expiryDate = Convert.ToDateTime(expiresOn);
                    expiryDate = DateTime.Parse(expiresOn);
                }
                else
                {
                    expiryDate = DateTime.Now;
                }

                var theQuantity = 0;


                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }


                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = "Day Order (DO)";
                var brokerRef = broker + orderNumber;
                var contraBrokerId = "";
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = "",
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = "None",
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        FOK = false,
                        trading_platform = GetTradingPlaform(myCompany),
                        Affirmation = true
                    };
                    //save to cdsc tempPreorderLive too
                    var orderPreorderCdsc = new PreOrderLives
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        TimeInForce = timeInForce,
                        OrderQualifier = "None",
                        BrokerRef = brokerRef,
                        OrderNumber = orderNum,
                        Source = source
                    };
                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {
                        //                      var emailAdd = theBroker.Email;
                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        //                      SendMail2(emailAdd, "Your order was successfully posted", "Order Posting");

                        /*
                        *Saving to CDSC Table 
                        */
                        tempDbContext.PreOrderLives.Add(orderPreorderCdsc);
                        tempDbContext.SaveChanges();

                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {
                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }

                        return "Your Order has been successfully placed";
                    }
                    catch (Exception e)
                    {
                        //return e.ToString();
                        return "Timeout, please check your Internet connection.";
                    }
                }
                catch (Exception e)
                {
                    return "An error has occured in posting your order, please try again.";
                }

            }
            catch (Exception ex)
            {
                return "An error has occured in posting your order, please try again.";
            }
        }
        public string OrderPostingIPO(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string source)

        {
            var tot = Math.Round(decimal.Parse(price) * int.Parse(quantity), 2);
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "";
            double basePrice = 0;
            var theOrderTrans = "";

            try
            {
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                if (orderType != null && orderType.Equals("Market"))
                {
                    orderPref = "M";
                    basePrice = 0;
                }
                else
                {
                    basePrice = double.Parse(price);
                    orderPref = "L";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                //var theCompnay =
                //    atsDbContext.para_company.OrderByDescending(x => x.ID)
                //        .Where(x => x.Company == company)
                //        .FirstOrDefault(x => x.Company == company);

                //if (theCompnay == null)
                //{
                //    return "Select a valid company";
                //}

                myCompany = company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }

                var returnVal = LIMITS_CHECK(myCompany, cdsNumber, quantity);
                if (returnVal != "0")
                {
                    return returnVal;
                }

                decimal shares = 0;
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {
                    var shareAvail =
                        cdsDbContext.trans.FirstOrDefault(x => x.CDS_Number == cdsNumber && x.Company == myCompany);

                    if (shareAvail != null)
                    {
                        var theShare =
                            cdsDbContext.trans.Where(x => x.CDS_Number == cdsNumber && x.Company == myCompany)
                                .Select(x => x.Shares)
                                .Sum();
                        if (theShare <= 0)
                        {
                            return "You have insufficient shares, check with your broker";
                        }
                    }
                    else
                    {
                        return "You have insufficient shares, check with your broker";
                    }
                }


                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price);
                if (orderTrans.ToString().ToUpper().Equals("BUY"))
                {
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                    if (moneyAvail != null)
                    {
                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                //SAVING TO DB


                var orderStatus = "OPEN";
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now;
                var theQuantity = 0;


                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }


                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = "Day Order (DO)";
                var orderQualifier = "None";
                var brokerRef = broker + orderNumber;
                var contraBrokerId = "";
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "USD";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = theBroker1.Company_Code,
                        Client_Type = "",
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        //                                                                    AvailableShares = availableShares,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        FOK = false,
                        Affirmation = true
                    };
                    //save to cdsc tempPreorderLive too
                    var orderPreorderCdsc = new PreOrderLivesIPOes
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = theBroker1.Company_Code,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        OrderNumber = orderNum,
                        Source = source
                    };

                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "BUY - IPO",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };
                    try
                    {
                        //                      var emailAdd = theBroker.Email;
                        //atsDbContext.Pre_Order_Live.Add(orderLive);
                        //atsDbContext.SaveChanges();
                        //                      SendMail2(emailAdd, "Your order was successfully posted", "Order Posting");
                        tempDbContext.PreOrderLivesIPOes.Add(orderPreorderCdsc);
                        tempDbContext.SaveChanges();

                        tempDbContext.CashTrans.Add(orderCashTrans);
                        tempDbContext.SaveChanges();

                        var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand cmdn = new SqlCommand();
                            cmdn.Connection = connection;
                            cmdn.CommandType = CommandType.StoredProcedure;
                            cmdn.CommandText = "AReceiveBidsIPO";
                            cmdn.Parameters.AddWithValue("@Bank", "0");
                            cmdn.Parameters.AddWithValue("@Branch", "0");
                            cmdn.Parameters.AddWithValue("@Accountnumber", "0");
                            cmdn.Parameters.AddWithValue("@No_of_Notes_Applied", quantity);
                            cmdn.Parameters.AddWithValue("@AmountPaid", tot);
                            cmdn.Parameters.AddWithValue("@PaymentRefNo", "Escrow");
                            cmdn.Parameters.AddWithValue("@ClientType", "LI");
                            cmdn.Parameters.AddWithValue("@BrokerReference", "OMSEC");
                            cmdn.Parameters.AddWithValue("@DividendDisposalPreference", "M");
                            cmdn.Parameters.AddWithValue("@MNO_", "ONLINE");
                            cmdn.Parameters.AddWithValue("@Identification", cdsNumber);
                            cmdn.Parameters.AddWithValue("@TelephoneNumber", cdsNumber);
                            cmdn.Parameters.AddWithValue("@CDSC_Number", cdsNumber);
                            cmdn.Parameters.AddWithValue("@ReceiptNumber", "Escrow");
                            cmdn.Parameters.AddWithValue("@Company", company);
                            //cmdn.Parameters.AddWithValue("@Custodian", "0");
                            //cmdn.Parameters.AddWithValue("@TransNum", "0");
                            //cmdn.Parameters.AddWithValue("@PledgeIndicator", "0");
                            //cmdn.Parameters.AddWithValue("@PledgeeBPID", cdsNumber);
                            connection.Open();
                            if (cmdn.ExecuteNonQuery() > 0)
                            {
                                connection.Close();
                                return "1";
                            }
                            else
                            {
                                connection.Close();
                                return "Error saving IPO";
                            }
                        }
                        //return "1";
                    }
                    catch (Exception e)
                    {
                        return e.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "Assigning values => " + e.ToString();
                }

            }
            catch (Exception ex)
            {
                return "All errors => " + ex.ToString();
            }
        }
        public string OrderIPOPostingPOSTANDROIDTwo(string company, string quantity, string price, string cdsNumber)
        {
            var tot = Math.Round(decimal.Parse(price) * int.Parse(quantity), 2);


            var returnVal = LIMITS_CHECK(company, cdsNumber, quantity);
            if (returnVal != "0")
            {
                return returnVal;
            }
            //IF BUY ORDER
            var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price);
            var tempDbContext = new cdscDbContext();
            var moneyAvail =
                    tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

            if (moneyAvail != null)
            {
                var theCashBal =
                    tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                        .Select(x => x.Amount)
                        .Sum();
                if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                {
                    return "You have insufficient balance in your Cash account";
                }
            }
            else
            {
                return "You have insufficient balance in your Cash account";
            }

            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //String mycds_ = GetCdsNumberFROMMOBILE(mobile);
                SqlCommand cmdn = new SqlCommand();
                cmdn.Connection = connection;
                cmdn.CommandType = CommandType.StoredProcedure;
                cmdn.CommandText = "AReceiveBidsIPO";
                cmdn.Parameters.AddWithValue("@Bank", "0");
                cmdn.Parameters.AddWithValue("@Branch", "0");
                cmdn.Parameters.AddWithValue("@Accountnumber", "0");
                cmdn.Parameters.AddWithValue("@No_of_Notes_Applied", quantity);
                cmdn.Parameters.AddWithValue("@AmountPaid", tot);
                cmdn.Parameters.AddWithValue("@PaymentRefNo", "Escrow");
                cmdn.Parameters.AddWithValue("@ClientType", "LI");
                cmdn.Parameters.AddWithValue("@BrokerReference", "OMSEC");
                cmdn.Parameters.AddWithValue("@DividendDisposalPreference", "M");
                cmdn.Parameters.AddWithValue("@MNO_", "ANDROID");
                cmdn.Parameters.AddWithValue("@Identification", cdsNumber);
                cmdn.Parameters.AddWithValue("@TelephoneNumber", "");
                cmdn.Parameters.AddWithValue("@CDSC_Number", cdsNumber);
                cmdn.Parameters.AddWithValue("@ReceiptNumber", "Escrow");
                cmdn.Parameters.AddWithValue("@Company", company);
                //cmdn.Parameters.AddWithValue("@Custodian", "0");
                //cmdn.Parameters.AddWithValue("@TransNum", "0");
                //cmdn.Parameters.AddWithValue("@PledgeIndicator", "0");
                //cmdn.Parameters.AddWithValue("@PledgeeBPID", cdsNumber);
                connection.Open();
                if (cmdn.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "IPO - BUY",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    tempDbContext.CashTrans.Add(orderCashTrans);
                    tempDbContext.SaveChanges();
                    return "Order placed successfully";
                }
                else
                {
                    connection.Close();
                    return "Error placing order";
                }
            }

        }
        public string GetCdsNumber(string cdsNumber)
        {
            var getBrk =
                "SELECT TOP 1 [CDS_Number], [Surname] , [Forenames] FROM [CDS_ROUTER].[dbo].[Accounts_Clients] where CDS_Number = '" +
                cdsNumber + "'";
            var order = new Accounts_Clients();
            var ret = "";

            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        //                        order.CDS_Number = rdr["CDS_Number"].ToString();
                        ret += rdr["Surname"].ToString() + " " + rdr["Forenames"].ToString();

                        //                        order.Surname = rdr["Surname"].ToString();
                        //                        order.Forenames = rdr["Forenames"].ToString();
                        //                        listOfOrders.Add(order);
                    }

                    try
                    {
                        //                        var jsonResult = Json(listOfOrders, JsonRequestBehavior.AllowGet);
                        //                        jsonResult.MaxJsonLength = int.MaxValue;
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "1";
                    }
                }
                else
                {
                    return "0";
                }
            }
        }
        public JsonResult GetCompaniies(string company = null)
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies = atsDbContext.para_company.Select(c =>
                new
                {
                    CompayCode = c.Company,
                    CompanyName = c.fnam
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSecurities(String exchange, string company = null)
        {
            var atsDbContext = new AtsDbContext();
            var statement =
                atsDbContext.para_company.OrderByDescending(x => x.ID).Where(x => x.fnam == company && x.exchange == exchange).Select(c => new
                {
                    Id = c.ID,
                    Instrument = c.Instrument,
                    IsinNo = c.Company,
                    InitialPrice = c.InitialPrice
                });
            return Json(statement, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyCompanies(string exchange, string company = null)
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.Where(x => x.exchange == exchange).GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    compInitial = c.Company,
                    Name = c.fnam,
                    InitialPrice = c.InitialPrice
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompanyFullName(string exchange)
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.Where(x => x.exchange == exchange).GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    company = c.Company,
                    Name = c.fnam,
                    InitialPrice = c.InitialPrice
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public string Widthdraw(string cdsnumber, string ammount)
        {
            var tempDbContext = new cdscDbContext();
            try
            {

                var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsnumber && x.TransStatus.Trim() == "1");
                decimal? theCashBalSell = 0;
                decimal? theCashBal = 0;
                string message = "";
                if (moneyAvail != null)
                {


                    var result = tempDbContext.Database.SqlQuery<Balancess>("SELECT amt  FROM New_Balz  where cds_number = '" + cdsnumber + "'").FirstOrDefault();
                    //get withdraw balance
                    var withd = _cdDataContext.CTRADELIMITS.ToList().Where(a => a.LimitType.ToLower().Replace(" ", "") == "withdraw").FirstOrDefault();

                    // var limits = tempDbContext.Database.SqlQuery<CTRADELIMITS>("SELECT * FROM[CDS_ROUTER].[dbo].[CTRADELIMITS] where LimitType = 'WITHDRAW'").FirstOrDefault();
                    //message = "Balance from db " + theCashBal + " , cashbal " + theCashBal + " amount"+ammount;
                    if (Convert.ToDecimal(ammount) < Convert.ToDecimal(withd.Minimum))
                    {
                        return "You  amount to withdraw is below the limit";
                    }

                    theCashBal = result.amt;

                    if (String.IsNullOrEmpty(theCashBal.ToString()) == true)
                    {
                        theCashBal = 0;
                    }

                    //message = "Balance from db " + theCashBal + " , cashbal " + theCashBal + " amount"+ammount;
                    if (theCashBal < (Convert.ToDecimal(withd.Minimum)) || theCashBal < (Convert.ToDecimal(ammount)))
                    {
                        return "You have insufficient balance in your Cash account";
                    }

                }
                else
                {
                    return "You have insufficient balance in your Cash account";
                }

                var isCompany = _cdDataContext.Accounts_Clients_Web.Where(a => a.CDS_Number == cdsnumber);
               

                DateTime nowDate = DateTime.Now;
                decimal myAmount = Convert.ToDecimal(ammount);
                var hasWithdrawal = _cdscDbContext.CashTrans
                                                                
.Where(b => b.Amount == -myAmount)
                                                              .Where(a => a.CDS_Number == cdsnumber)
                                                            .Where(c => c.DateCreated >= DbFunctions.CreateDateTime(nowDate.Year, nowDate.Month, nowDate.Day, nowDate.Hour - 1, nowDate.Minute, nowDate.Second))


                                                            .ToList();


                if (hasWithdrawal.Count == 0)
                {
                    if (isCompany.First().AccountType.ToLower().Equals("c"))
                    {
                        //Selecting distinct
                        var tempCashTrans = new CashTransTemp
                        {
                            Description = "Withdrawal",
                            TransType = "Withdraw",
                            TransStatus = "0",
                            Amount = (Decimal.Parse(ammount)) * -1,
                            CDS_Number = cdsnumber,
                            DateCreated = DateTime.Now,
                            Paid = false,
                            Reference = "None"
                        };
                        tempDbContext.CashTransTemps.Add(tempCashTrans);
                        tempDbContext.SaveChanges();
                        return "Withdraw request sent and pending authorization.";
                    }
                    else
                    {
                        //Selecting distinct
                        var orderCashTrans = new CashTrans
                        {
                            Description = "Withdrawal",
                            TransType = "Withdraw",
                            TransStatus = "1",
                            Amount = -(Decimal.Parse(ammount)),
                            CDS_Number = cdsnumber,
                            DateCreated = DateTime.Now
                        };
                        tempDbContext.CashTrans.Add(orderCashTrans);
                        tempDbContext.SaveChanges();
                        // return message;
                        return "Withdraw Successful";
                    }
                }
                else
                {
                    return "Withdraw not Successful";
                }
            }
            catch (Exception ex)
            {
                return "Failed to make withdrawal" + ex;
            }
            //return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public string WidthdrawForex(string cdsnumber, string ammount)
        {
            var tempDbContext = new cdscDbContext();
            try
            {

                var moneyAvail =
                        tempDbContext.CashTrans_forex.FirstOrDefault(x => x.CDS_Number == cdsnumber && x.TransStatus.Trim() == "1");

                if (moneyAvail != null)
                {

                    var theCashBal =
                        tempDbContext.CashTrans_forex.Where(x => x.CDS_Number == cdsnumber && x.TransStatus.Trim() == "1")
                            .Select(x => x.Amount)
                            .Sum();
                    if (theCashBal <= 10 || theCashBal < (Decimal.Parse(ammount)))
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                else
                {
                    return "You have insufficient balance in your Cash account";
                }

                //Selecting distinct
                var orderCashTrans = new CashTrans_forex
                {
                    Description = "Withdrawal",
                    TransType = "Withdraw",
                    TransStatus = "1",
                    Amount = -(Decimal.Parse(ammount)),
                    CDS_Number = cdsnumber,
                    Currency="USD",
                    DateCreated = DateTime.Now
                };
                tempDbContext.CashTrans_forex.Add(orderCashTrans);
                tempDbContext.SaveChanges();
                return "Conversion Successfull";
            }
            catch (Exception ex)
            {
                return "Failed to make conversion" + ex;
            }
            //return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompaniesListForGraph(string exchange)
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.Where(x => x.exchange == exchange).GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    Name = c.Company,
                    InitialPrice = c.InitialPrice,
                    Instrument = c.Instrument,

                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompaniesListForGraphAll()
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    Name = c.Company,
                    InitialPrice = c.InitialPrice,
                    Instrument = c.Instrument,

                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompaniesMaPriceList(string cmpny)
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.Where(x => x.Company == cmpny).Select(c =>
                new
                {
                    InitialPrice = c.InitialPrice
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public string GetTradingPlaform(string company)
        {
            var getBrk =
                "SELECT exchange FROM para_company where Company  = '" +
                company.Trim() + "'";

            var ret = "";

            using (var connection = new SqlConnection(connectionStringATS))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret += rdr["exchange"];
                    }

                    try
                    {
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "FINSEC";
                    }
                }
                return "FINSEC";
            }
        }
        public JsonResult GetCompaniesPriceList(string company)
        {
            var getBrk = @"  select DISTINCT CONVERT(date , b.price_date) as date_ ,(select TOP 1 a.[price_close] from Prices a WHERE CONVERT(date , a.price_date)=CONVERT(date , b.price_date) and a.company_name=b.company_name ORDER BY a.price_date DESC) AS PriceClose
  from prices b
  WHERE b.company_name = '" + company + @"'";

            var listOfBrokers = new List<MYPriceGRAPH>();
            using (SqlConnection connection = new SqlConnection(connectionStringATS))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MYPriceGRAPH broker = new MYPriceGRAPH();
                    broker.Price = rdr["PriceClose"].ToString();
                    broker.Date = DateTime.Parse(rdr["date_"].ToString()).ToString("dd/MM/yyyy");
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }

        }
        public JsonResult GetCompaniesPriceFromList(string company)
        {
            var getBrk = @" select TOP 1 DISTINCT CONVERT(date , b.price_date) as date_ ,(select TOP 1 a.[price_close] from Prices a WHERE CONVERT(date , a.price_date)=CONVERT(date , b.price_date) and a.company_name=b.company_name ORDER BY a.price_date ASC) AS PriceClose
  from prices b
  WHERE b.company_name = '" + company + @"'";

            var listOfBrokers = new List<MYPriceGRAPH>();
            using (SqlConnection connection = new SqlConnection(connectionStringATS))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MYPriceGRAPH broker = new MYPriceGRAPH();
                    broker.Price = rdr["PriceClose"].ToString();
                    broker.Date = DateTime.Parse(rdr["date_"].ToString()).ToString("dd/MM/yyyy");
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }

        }
        private string LIMITS_CHECK(string isin, string cds_acc, string quantity)
        {
            string return_str = "";
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("declare @cdsnumber nvarchar(50)='" + cds_acc + "' declare @issue nvarchar(50)='" + isin + "' select Bidratio, IPOSTATUS, IndividualLimit, GlobalLimit, globLowerlimit, DailyLimit,Transaction_Limit,FirstLimit,isnull((select cds_number from Accounts_Clients where CDS_Number=@cdsnumber),'NotExisting') as [CDSExist], (SELECT isnull(SUM(isnull(No_of_Notes_Applied,0)),0) as BidToDate FROM [Bond_Payment_Audit] where Company =@issue) as [Bidstodate],(SELECT isnull(SUM(isnull(No_of_Notes_Applied,0)),0) as BidToDate FROM [Bond_Payment_Audit] where Company =@issue and CDSC_Number=@cdsnumber) as [InvestorTotalBidsGlobal],(SELECT isnull(SUM(isnull(No_of_Notes_Applied,0)),0) as BidToDate FROM [Bond_Payment_Audit] where Company =@issue and CDSC_Number=@cdsnumber and convert(date,date_created)=convert(date,getdate())) as InvestorTotalToday, isnull((select Mobile from Accounts_Clients where CDS_Number=@cdsnumber),'NotExisting') as [Telephone], isnull((select IDNoPP from Accounts_Clients where CDS_Number=@cdsnumber),'NotExisting') as [Idnumber]  from para_holding WITH (NOLOCK) where NewIssuerCode=@issue", con))
                {
                    DataSet dsi = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dsi, "para_holding");
                    if (dsi.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsi.Tables[0].Rows[0];
                        if (Convert.ToInt32(dr["IPOSTATUS"]) == 1)
                        {
                            return_str = "Primary Issuance Has Been Closed";
                        }
                        else if (dr["CDSExist"].ToString() == "NotExisting")
                        {
                            return_str = "CDS Account Number does Not Exist";
                        }
                        else if (Convert.ToInt64(dr["Bidstodate"]) >= Convert.ToInt64(dr["GlobalLimit"]))
                        {
                            return_str = "Global Limit Already Reached";
                        }
                        else if (Convert.ToInt64(dr["Bidstodate"]) + Convert.ToInt64(quantity) > Convert.ToInt64(dr["GlobalLimit"]))
                        {
                            return_str = "Quantity will exceed Global Limit";
                        }
                        else if (Convert.ToInt64(dr["InvestorTotalBidsGlobal"]) >= Convert.ToInt64(dr["IndividualLimit"]))
                        {
                            return_str = "Individual Limit Already Reached";
                        }
                        else if (Convert.ToInt64(dr["InvestorTotalBidsGlobal"]) + Convert.ToInt64(quantity) > Convert.ToInt64(dr["IndividualLimit"]))
                        {
                            return_str = "Individual Limit will be exceeded";

                        }
                        else if (Convert.ToInt64(dr["InvestorTotalToday"]) >= Convert.ToInt64(dr["DailyLimit"]))
                        {
                            return_str = "Daily Limit Already Reached";

                        }
                        else if (Convert.ToInt64(dr["InvestorTotalToday"]) + Convert.ToInt64(quantity) > Convert.ToInt64(dr["DailyLimit"]))
                        {
                            return_str = "Daily Limit will be exceeded";

                        }
                        //else if (Convert.ToInt64(dr["InvestorTotalBidsGlobal"]) == 0 & Convert.ToInt64(quantity) < Convert.ToInt64(dr["FirstLimit"]))
                        //{
                        //    return_str = "First Bid. The Amount Entered is Less than the First Bid limit which is " + dr["FirstLimit"].ToString();

                        //}
                        else if (Convert.ToInt64(quantity) < Convert.ToInt64(dr["globLowerlimit"]))
                        {
                            return_str = "The Amount Entered is Less than the Lower Bid limit which is " + dr["globLowerlimit"].ToString();

                        }
                        else
                        {
                            return_str = "0";
                        }
                    }
                    else
                    {
                        return_str = "Limits Not set";

                    }
                }
            }
            return return_str;
        }
        public static string Force4DecimalPlaces(string input)
        {
            decimal parsed = decimal.Parse(input, CultureInfo.InvariantCulture);
            string intermediate = parsed.ToString("0.0000", CultureInfo.InvariantCulture);
            return decimal.Parse(intermediate, CultureInfo.InvariantCulture).ToString();
        }
        public static string Force2DecimalPlaces(string input)
        {
            decimal parsed = decimal.Parse(input, CultureInfo.InvariantCulture);
            string intermediate = parsed.ToString("0.00", CultureInfo.InvariantCulture);
            return decimal.Parse(intermediate, CultureInfo.InvariantCulture).ToString();
        }
        public string GetCdsNumberFROMIDNUM(string idnumb)
        {
            var getBrk =
                "SELECT TOP 1 [CDS_Number] FROM [CDS_ROUTER].[dbo].[Accounts_Clients] where IDNoPP = '" +
                idnumb + "'";
            var order = new Accounts_Clients();
            var ret = "";
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret += rdr["CDS_Number"].ToString();
                    }

                    try
                    {
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "1";
                    }
                }
                else
                {
                    return "0";
                }
            }
        }
        public string getCurrentBalance(string company, string cdsnumber)
        {
            var getBrk =
                "select isnull(Net,0) as NetShares from cdsc.dbo.MyportfolioAll d where d.CDS_Number='" +
                cdsnumber.Trim() + "' AND D.COMPANY = '" + company.Trim() + "'";

            var ret = "";

            using (var connection = new SqlConnection(connectionStringATS))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret = rdr["NetShares"].ToString();
                    }

                    try
                    {
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "0";
                    }
                }
                return "0";
            }
        }

        ///////////////////////////////////////////////////////////////////////////////V2 METHODS////////////////////////////////////////////////////////////////////


        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        public JsonResult NewLoginEncry(string username = null, string password = null)
        {

            if (username != null || password != null)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                var CompShares = new List<VatenkeciNewV2>();

                //var sql = "SELECT t.* , ut.BrokerCode . ISNULL(ut.min_value_threshold , 10) as min_value_threshold  FROM [CDSC].[dbo].[Vatenkecis] t , [CDS_ROUTER].[dbo].[Accounts_Clients] ut where (t.Email ='" + username + "' or t.CdsNumber = '" + username + "')  and (t.CdsNumber = ut.CDS_Number)  and t.Active = '1' ";
                var sql = "SELECT t.* , ut.BrokerCode ,ISNULL(vt.min_value_threshold , 10) as min_value_threshold  FROM [CDSC].[dbo].[Vatenkecis] t , [CDS_ROUTER].[dbo].[Accounts_Clients] ut left join [CDS_ROUTER].[dbo].[Client_Companies] vt on ut.BrokerCode = vt.Company_Code where (t.Email ='" + username + "' or t.CdsNumber = '" + username + "')  and (t.CdsNumber = ut.CDS_Number)  and t.Active = '1' ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    String getstatus_;

                    string encyptedPassword = EncryptIt(password.Trim());

                    while (rdr.Read())
                    {
                        //if (sha256_hash(rdr["Password"].ToString()).Equals(password))
                        if (encyptedPassword.Equals(rdr["Password"].ToString()))
                        {
                            VatenkeciNewV2 recordSummary = new VatenkeciNewV2();
                            recordSummary.id = int.Parse(rdr["id"].ToString());
                            recordSummary.username = rdr["username"].ToString();
                            recordSummary.email = rdr["email"].ToString();
                            recordSummary.broker = rdr["BrokerCode"].ToString();
                            recordSummary.cds = rdr["CdsNumber"].ToString();
                            //recordSummary.Active = rdr["Active"].ToString();
                            recordSummary.Active = rdr["Active"].ToString();
                            recordSummary.min_value_threshold = rdr["min_value_threshold"].ToString();
                            getstatus_ = testAccountinJoint(rdr["CdsNumber"].ToString());
                            recordSummary.has_company = getstatus_;
                            CompShares.Add(recordSummary);
                        }
                        else
                        {
                            return Json(7, JsonRequestBehavior.AllowGet);
                        }
                    }
                }

                if (CompShares.Any())
                {
                    return Json(CompShares, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(0, JsonRequestBehavior.AllowGet);

        }
        // GET: Subscriber
        public string sendemail(string emailAdd, string subject, string emailbody)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.office365.com"; //outlook.office365.com
                client.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Timeout = 30000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("info@ctrade.co.zw", "asdfghjkl.2017");
                client.TargetName = "STARTTLS/smtp.office365.com";
                MailMessage mm = new MailMessage();
                mm.BodyEncoding = Encoding.UTF8;
                mm.From = new MailAddress("info@ctrade.co.zw");
                mm.To.Add(emailAdd);
                mm.Subject = subject;
                mm.Body = emailbody;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(mm);
                return "Message Sent";
            }
            catch (Exception e)
            {
                return "Error occured please try again" + e;
            }
        }
        [HttpPost]
        public string sendmail(FormCollection formCollection)
        {
            string emailAdd = formCollection["emailAdd"];
            string subject = formCollection["subject"];
            string emailbody = formCollection["emailbody"];
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("escrowctrade@gmail.com", "asdfghjkl2017");

                MailMessage mm = new MailMessage();
                mm.BodyEncoding = Encoding.UTF8;
                mm.From = new MailAddress("escrowctrade@gmail.com");
                mm.To.Add(emailAdd);
                mm.Subject = subject;
                mm.Body = emailbody;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return "Email Send";
            }
            catch (Exception ex)
            {
                return "Error sending email ";
            }
            //try
            //{

            //    MailMessage Mail = new MailMessage();
            //    Mail.Subject = subject;
            //    Mail.To.Add("" + emailAdd + "");
            //    // Mail.From = New MailAddress("corpservesharepower@googlemail.com")
            //    Mail.From = new MailAddress("notifications@ctrade.co.zw");
            //    Mail.Body = emailbody;
            //    // Dim SMTP As New SmtpClient("smtp.googlemail.com")
            //    System.Net.ServicePointManager.ServerCertificateValidationCallback = (object se, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslerror) => true;
            //    //Dim SMTP As New SmtpClient("64.233.167.16")
            //    SmtpClient SMTP = new SmtpClient("192.168.3.241");
            //    SMTP.EnableSsl = true;
            //    //Mail.Attachments.Add(new Attachment(AttachName));
            //    //SMTP.Credentials = New System.Net.NetworkCredential("corpservesharepower@googlemail.com", "pavilion$")
            //    SMTP.Credentials = new System.Net.NetworkCredential("notifications@ctrade.co.zw", "asdfghjkl2017");
            //    SMTP.Port = 587;
            //    // SMTP.Port = SMTPport
            //    SMTP.Send(Mail);
            //    return "Email Send";
            //}
            //catch (Exception ex)
            //{
            //    return "Error sending email " + ex;
            //}
        }
        public JsonResult getMyPortFolioOLD(string cdsNumber = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<MyPortfolio>();

            var sql = "select * from cdsc.dbo.MyportfolioAll d where d.CDS_Number='" + cdsNumber + "'";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyPortfolio recordSummary = new MyPortfolio();
                    recordSummary.id = ix.ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.numbershares = rdr["totAllShares"].ToString();
                    recordSummary.lastactivitydate = rdr["LastAcDate"].ToString();
                    recordSummary.currentprice = Force4DecimalPlaces(rdr["currePrice"].ToString());
                    recordSummary.prevprice = Force4DecimalPlaces(rdr["PrevPrice"].ToString());
                    recordSummary.totalportvalue = Force4DecimalPlaces(rdr["TotPottValue"].ToString());
                    recordSummary.totalPrevPortValue = Force4DecimalPlaces(Math.Round((double.Parse(rdr["PrevPrice"].ToString()) * double.Parse(rdr["totAllShares"].ToString())), 4).ToString());
                    recordSummary.returns = Force4DecimalPlaces(Math.Round(double.Parse(rdr["totReturnValue"].ToString()), 4).ToString());
                    recordSummary.uncleared = Force4DecimalPlaces(rdr["Uncleared"].ToString());
                    recordSummary.net = Force4DecimalPlaces(rdr["Net"].ToString());

                    var BuysBymes = new List<BuysByme>();
                    var sql2 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares>0";
                    using (SqlConnection connection2 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd2 = new SqlCommand(sql2, connection2);
                        cmd2.CommandType = CommandType.Text;
                        connection2.Open();
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            BuysByme recordSum1 = new BuysByme();
                            recordSum1.company = rdr2["Company"].ToString();
                            recordSum1.volume = rdr2["Shares"].ToString();
                            recordSum1.price = Force4DecimalPlaces(rdr2["TradePrice"].ToString());
                            recordSum1.totalValue = Force4DecimalPlaces((decimal.Parse(rdr2["TradePrice"].ToString()) * decimal.Parse(rdr2["Shares"].ToString())).ToString());
                            BuysBymes.Add(recordSum1);
                        }
                    }
                    // foreach (var p in retBids)
                    //{

                    //}
                    recordSummary.BuyDetail = BuysBymes;
                    //get my buys

                    //get my sells
                    //var retOffers = _cdDataContext.trans.Where(x => x.CDS_Number == cdsNumber.ToString() && x.Shares < 0 && x.Company == recordSummary.counter).Select(v => new
                    //{
                    //    comp = v.Company,
                    //    volum = v.Shares,
                    //    pric = v.Shares,
                    //    totVal = v.Shares
                    //});
                    //var sellBymes = new List<SellsByme>();

                    //foreach (var p in retOffers)
                    //{
                    //    SellsByme recordSum2 = new SellsByme();
                    //    recordSum2.company = p.comp.ToString();
                    //    recordSum2.volume = p.volum.ToString();
                    //    recordSum2.price = p.pric.ToString();
                    //    recordSum2.totalValue = p.totVal.ToString();
                    //    sellBymes.Add(recordSum2);
                    //}
                    var sellBymes = new List<SellsByme>();
                    var sql3 = "select *,ISNULL((SELECT TOP (1) TradePrice FROM CDS_ROUTER.dbo.tblMatchedOrders AS q WHERE ((ReportID = d.Reference) AND (Account1 = d.CDS_Number)) OR ((ReportID = d.Reference) AND (Account2 = d.CDS_Number))),1) AS TradePrice from cds_router.dbo.trans d where d.CDS_Number='" + cdsNumber + "' and d.Company='" + recordSummary.counter + "' and d.Shares<0";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd3 = new SqlCommand(sql3, connection3);
                        cmd3.CommandType = CommandType.Text;
                        connection3.Open();
                        SqlDataReader rdr3 = cmd3.ExecuteReader();
                        while (rdr3.Read())
                        {
                            SellsByme recordSum2 = new SellsByme();
                            recordSum2.company = rdr3["Company"].ToString();
                            recordSum2.volume = rdr3["Shares"].ToString();
                            recordSum2.price = Force4DecimalPlaces(rdr3["TradePrice"].ToString());
                            recordSum2.totalValue = Force4DecimalPlaces((decimal.Parse(rdr3["TradePrice"].ToString()) * decimal.Parse(rdr3["Shares"].ToString())).ToString());
                            sellBymes.Add(recordSum2);
                        }
                    }
                    recordSummary.SellDetail = sellBymes;
                    //get my sells

                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getMarketCap()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var myPortf = new List<market_cap_>();

            var sql = "select TOP 2 * from cdsc.dbo.market_cap ";
            var ix = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    market_cap_ recordSummary = new market_cap_();
                    recordSummary.id = ix.ToString();
                    recordSummary.exchange = rdr["exchange"].ToString().Trim();
                    recordSummary.market_cap = rdr["market_cap"].ToString().Trim();
                    recordSummary.trades = rdr["trades"].ToString().Trim();
                    recordSummary.turnover = rdr["turnover"].ToString().Trim();
                    myPortf.Add(recordSummary);
                    ix = ix + 1;
                }
            }
            return Json(myPortf, JsonRequestBehavior.AllowGet);
        }
        public string OrderPostingMakeNew(string company, string security, string orderTrans,
           string orderType, string quantity, string price, string cdsNumber,
           string broker, string source, string tif, string date_ = null, string corp_name = null, string corp_id = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                //check for CRT
                var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='"+ cdsNumber +"' ").ToList().FirstOrDefault();
                var acc_type = user_acc.AccountType;

                try
                {
                    //check if account is locked
                    if (user_acc.AccountState.ToLower().Replace(" ", "") == "locked")
                    {
                        return "Your account is locked.Please Contact C-Trade Team.";
                    }
                }
                catch (Exception)
                {

                 
                }

                //check if user is sanctioned
                if (SanctionedExsistsval(user_acc.Forenames+" "+user_acc.Surname)==1)
                {
                    return "Order Posting failed.Please Contact C-Trade Team.";
                }

                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.Company == company)
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number=@cdsNumber and Company =@myCompany ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cdsNumber", cdsNumber);
                        cmd.Parameters.AddWithValue("@myCompany", myCompany);
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (security.Trim().ToString() == "UNIT TRUST")
                            {
                                shareAvail = int.Parse(rdr["totAllShares"].ToString());
                            }
                            else
                            {
                                shareAvail = int.Parse(rdr["Net"].ToString());
                            }
                        }
                    }
                    decimal? finsec = 0;
                    try
                    {
                        finsec = FinsecSharessBal(cdsNumber, myCompany);
                    }
                    catch (Exception)
                    {

                        finsec = 0;
                    }
                    if (string.IsNullOrEmpty(shareAvail.ToString()) == true)
                    {
                        shareAvail = 0;
                    }

                    var trading = GetTradingPlaform(myCompany).ToLower();
                    //if (shareAvail < int.Parse(quantity))
                    //{
                    //    return "You have insufficient units in your account.";
                    //}
                    if (string.IsNullOrEmpty(finsec.ToString()) == false && trading == "finsec")
                    {
                        if (finsec < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account. shareAvail"+ shareAvail+ "int.Parse(quantity) " + int.Parse(quantity);
                        }
                        else
                        {
                            shareAvail = Convert.ToInt32(finsec);
                        }
                    }
                    else
                    {
                        if (shareAvail < int.Parse(quantity))
                        {
                            return int.Parse(quantity)+"You have insufficient units in your account.shareAvail" + shareAvail;
                        }
                    }
                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }
                if (GetTradingPlaform(myCompany).Equals("ZSE"))
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                else
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                if (!acc_type.Equals("c"))
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account theCashBal" + theCashBal+ " totalAmountToSpent:" + totalAmountToSpent;
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account moneyAvail"+ moneyAvail;
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    if (string.IsNullOrEmpty(chk_cdc.CDC_Number) == false)
                    {
                        source = "CDC";
                        cdsNumber = chk_cdc.CDC_Number;
                    }


                        var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        Source = source,
                        FOK = false,
                        Affirmation = true,
                        Custodian=chk_cdc.BIC
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }


                        return "1";
                    }
                    catch (Exception e)
                    {
                        return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                return ex.Message + " \n " + ex.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
            }
        }
        public string OrderPostingMakeNewTrust(string company, string security, string orderTrans,
     string orderType, string quantity, string price, string cdsNumber,
     string broker, string source, string tif, string date_ = null, string corp_name = null, string corp_id = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                //check for CRT
                var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='" + cdsNumber + "' ").ToList().FirstOrDefault();
                var acc_type = user_acc.AccountType;

                try
                {
                    //check if account is locked
                    if (user_acc.AccountState.ToLower().Replace(" ", "") == "locked")
                    {
                        return "Your account is locked.Please Contact C-Trade Team.";
                    }
                }
                catch (Exception)
                {


                }

                //check if user is sanctioned
                if (SanctionedExsistsval(user_acc.Forenames + " " + user_acc.Surname) == 1)
                {
                    return "Order Posting failed.Please Contact C-Trade Team.";
                }

                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.fnam.ToLower().Replace(" ", "") == company.ToLower().Replace(" ",""))
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number=@cdsNumber and Company =@myCompany ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cdsNumber", cdsNumber);
                        cmd.Parameters.AddWithValue("@myCompany", myCompany);
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (security.Trim().ToString() == "UNITTRUST")
                            {
                                shareAvail = int.Parse(rdr["totAllShares"].ToString());
                            }
                            else
                            {
                                shareAvail = int.Parse(rdr["Net"].ToString());
                            }
                            //break;
                        }
                    }
                    decimal? finsec = 0;
                    try
                    {
                        finsec = FinsecSharessBal(cdsNumber, myCompany);
                    }
                    catch (Exception)
                    {

                        finsec = 0;
                    }
                    if (string.IsNullOrEmpty(shareAvail.ToString()) == true)
                    {
                        shareAvail = 0;
                    }

                    var trading = GetTradingPlaform(myCompany).ToLower();
                    //if (shareAvail < int.Parse(quantity))
                    //{
                    //    return "You have insufficient units in your account.";
                    //}
                    if (string.IsNullOrEmpty(finsec.ToString()) == false && trading == "finsec")
                    {
                        if (finsec < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account.";
                        }
                        else
                        {
                            shareAvail = Convert.ToInt32(finsec);
                        }
                    }
                    else
                    {
                        if (shareAvail < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account.";
                        }
                    }
                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }
                if (GetTradingPlaform(myCompany).Equals("ZSE"))
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                else
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                if (!acc_type.Equals("c"))
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail = tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal = tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber).Select(x => x.Amount).Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account theCashBal:"+ theCashBal+ " totalAmountToSpent:" + totalAmountToSpent;
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account moneyAvail " + moneyAvail+" totalAmountToSpent: " + totalAmountToSpent;
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    if (string.IsNullOrEmpty(chk_cdc.CDC_Number) == false)
                    {
                        source = "CDC";
                        cdsNumber = chk_cdc.CDC_Number;
                    }


                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        Source = source,
                        FOK = false,
                        Affirmation = true,
                        Custodian = chk_cdc.BIC
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }


                        return "1";
                    }
                    catch (Exception e)
                    {
                        return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                return ex.Message + " \n " + ex.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
            }
        }

        public string OrderPostingMakeNewGroup(string company, string security, string orderTrans,
         string orderType, string quantity, string price, string cdsNumber,
         string broker, string source, string tif, string date_ = null, string corp_name = null, string corp_id = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var acc_type = "1";
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.Company == company)
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber; 

                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number=@cdsNumber and Company =@myCompany ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cdsNumber", cdsNumber);
                        cmd.Parameters.AddWithValue("@myCompany", myCompany);
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            shareAvail = int.Parse(rdr["Net"].ToString());
                            //break;
                        }
                    }
                    decimal? finsec = 0;
                    try
                    {
                        finsec = FinsecSharessBal(cdsNumber, myCompany);
                    }
                    catch (Exception)
                    {

                        finsec = 0;
                    }
                    if (string.IsNullOrEmpty(shareAvail.ToString()) == true)
                    {
                        shareAvail = 0;
                    }

                    var trading = GetTradingPlaform(myCompany).ToLower();
                    //if (shareAvail < int.Parse(quantity))
                    //{
                    //    return "You have insufficient units in your account.";
                    //}
                    if (string.IsNullOrEmpty(finsec.ToString()) == false && trading == "finsec")
                    {
                        if (finsec < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account.";
                        }
                        else
                        {
                            shareAvail = Convert.ToInt32(finsec);
                        }
                    }
                    else
                    {
                        if (shareAvail < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account.";
                        }
                    }
                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }
                if (GetTradingPlaform(myCompany).Equals("ZSE"))
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                else
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                if (!acc_type.Equals("c"))
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient funds in your cash account";
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account";
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        Source = source,
                        FOK = false,

                        Affirmation = true
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }


                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return "Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                return "Error occured please contact support at ctrade@escrowgroup.org";
            }
        }

        public string OrderPostingAutoTrade(string company, string security, string orderTrans,
           string orderType, string quantity, string price, string cdsNumber,
           string broker, string source, string tif, string date_ = null, string ostatus = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                var acc_type = user_acc.AccountType;
                //SanctionedList
                //check if user is sanctioned
                if (SanctionedExsistsval(user_acc.Forenames + " " + user_acc.Surname) == 1)
                {
                    return "Order Posting failed.Please Contact C-Trade Team.";
                }
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.Company == company)
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                //if (orderTrans.ToString().ToUpper().Equals("SELL"))
                //{

                //    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                //    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                //    var shareAvail = 0;
                //    using (SqlConnection connection = new SqlConnection(connectionString))
                //    {
                //        SqlCommand cmd = new SqlCommand(sql, connection);
                //        cmd.CommandType = CommandType.Text;
                //        connection.Open();
                //        SqlDataReader rdr = cmd.ExecuteReader();
                //        while (rdr.Read())
                //        {
                //            shareAvail = int.Parse(rdr["Net"].ToString());
                //            //break;
                //        }
                //    }
                //    if (shareAvail < int.Parse(quantity))
                //    {
                //        return "You have insufficient units in your account.";
                //    }

                //}
                ////}

                ////IF BUY ORDER
                //var totalAmountToSpent = decimal.Parse("0.0");
                //var theQuantity = 0;
                //if (quantity != null)
                //{
                //    theQuantity = int.Parse(quantity);
                //}
                //if (GetTradingPlaform(myCompany).Equals("ZSE"))
                //{
                //    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                //}
                //else
                //{
                //    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                //}
                //if (acc_type == "i")
                //{
                //    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                //    {
                //        var moneyAvail =
                //            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                //        if (moneyAvail != null)
                //        {
                //            var theCashBal =
                //                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                //                    .Select(x => x.Amount)
                //                    .Sum();
                //            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                //            {
                //                return "You have insufficient funds in your cash account";
                //            }
                //        }
                //        else
                //        {
                //            return "You have insufficient funds in your cash account";
                //        }
                //    }
                //}
                //SAVING TO DB
                var orderStatus = ostatus;
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = int.Parse(quantity),
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,

                        Affirmation = true
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -1,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            //tempDbContext.SaveChanges();
                        }


                        return "1";
                    }
                    catch (Exception e)
                    {
                        return "error 1 " + e.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "Error 2 " + e.ToString();
                }

            }
            catch (Exception ex)
            {
                return "Error 3 " + ex.ToString();
            }
        }

        public string OrderPostingInvestmentGroup(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string source, string tif, string clubphone, string date_ = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                var acc_type = user_acc.AccountType;
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.fnam == company)
                        .FirstOrDefault(x => x.fnam == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            shareAvail = int.Parse(rdr["Net"].ToString());
                            //break;
                        }
                    }
                    if (shareAvail < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }

                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                var checkaccounts = from club in _cdscDbContext.club_members
                                    where club.club_phone == clubphone
                                    select club;
                var membercontribution = decimal.Parse("0.0");

                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }

                if (GetTradingPlaform(myCompany).Equals("ZSE"))
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }
                else
                {
                    totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
                }

                if (!acc_type.Equals(""))
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {

                        bool commit = true;

                        var membercount = checkaccounts.Count();

                        if (int.Parse(quantity) % membercount != 0)
                        {
                            return "Number of shares placed not equally distributable amongst club members";
                        }

                        membercontribution = totalAmountToSpent / membercount;

                        foreach (var chk in checkaccounts)
                        {

                            if (chkAmounts(chk.member_cds_number) < membercontribution)
                            {
                                commit = false;
                            }
                        }

                        if (commit == false)
                        {
                            return "One or more members do not have sufficient funds";
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        FOK = false,

                        Affirmation = true
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    foreach (var chk in checkaccounts)
                    {

                        orderCashTrans = new CashTrans
                        {
                            Description = "BUY - Order",
                            TransType = "BUY",
                            TransStatus = "1",
                            Amount = -membercontribution,
                            CDS_Number = chk.member_cds_number,
                            DateCreated = DateTime.Now
                        };

                        tempDbContext.CashTrans.Add(orderCashTrans);

                    }

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.SaveChanges();
                        }


                        return "Your order has been posted successfully";
                    }
                    catch (Exception e)
                    {
                        return "1 " + e.ToString();
                    }
                }
                catch (Exception e)
                {
                    return "2 " + e.ToString();
                }

            }
            catch (Exception ex)
            {
                return "3 " + ex.ToString();
            }
        }
        public decimal? chkAmounts(string cds)
        {
            decimal? cashAmt = _cdscDbContext.CashTrans.Where(a => a.CDS_Number == cds && a.TransStatus == "1").Sum(a => a.Amount);

            if (cashAmt == null)
            {
                return 0;
            }

            return cashAmt;
        }
        public string OrderPostingIPO(string company, string security, string orderTrans,
    string orderType, string quantity, string price, string cdsNumber,
    string broker, string source, string corp_name = null, string corp_id = null)

        {
            var tot = Math.Round(decimal.Parse(price) * int.Parse(quantity), 2);
            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture);
            var theOrderTrans = "";

            try
            {
                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }





                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                //var theCompnay =
                //    atsDbContext.para_company.OrderByDescending(x => x.ID)
                //        .Where(x => x.Company == company)
                //        .FirstOrDefault(x => x.Company == company);

                //if (theCompnay == null)
                //{
                //    return "Select a valid company";
                //}

                myCompany = company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }

                var returnVal = LIMITS_CHECK(myCompany, cdsNumber, quantity);
                if (returnVal != "0")
                {
                    return returnVal;
                }

                //decimal shares = 0;
                if (corp_name == null)
                {
                    if (orderTrans.ToString().ToUpper().Equals("SELL"))
                    {

                        var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                        var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                        var shareAvail = 0;
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand(sql, connection);
                            cmd.CommandType = CommandType.Text;
                            connection.Open();
                            SqlDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                shareAvail = int.Parse(rdr["Net"].ToString());
                                //break;
                            }
                        }
                        if (shareAvail < int.Parse(quantity))
                        {
                            return "You have insufficient shares, please contact Support at ctrade@escrowgroup.org";
                        }

                    }
                }


                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price);
                if (corp_name == null)
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                                tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                            {
                                return "You have insufficient balance in your Cash account";
                            }
                        }
                        else
                        {
                            return "You have insufficient balance in your Cash account";
                        }
                    }
                }
                //SAVING TO DB


                var orderStatus = "OPEN";
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now;
                var theQuantity = 0;


                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }


                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = "Day Order (DO)";
                var orderQualifier = "None";
                var brokerRef = broker + orderNumber;
                var contraBrokerId = "";
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "USD";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                try
                {

                    //save to cdsc tempPreorderLive too
                    var orderPreorderCdsc = new PreOrderLivesIPOesV2
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = theBroker1.Company_Code,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Expiry_Date = createdDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        OrderNumber = orderNum,
                        Source = source,
                        corp_name = corp_name,
                        corp_id = corp_id,
                        authorised_status = "not authorised"
                    };

                    //save to cdsc tempPreorderLive too
                    var orderCashTrans = new CashTrans
                    {
                        Description = "BUY - IPO",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -totalAmountToSpent,
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };
                    try
                    {
                        //                      var emailAdd = theBroker.Email;
                        //atsDbContext.Pre_Order_Live.Add(orderLive);
                        //atsDbContext.SaveChanges();
                        //                      SendMail2(emailAdd, "Your order was successfully posted", "Order Posting");



                        if (corp_name == null)
                        {
                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();

                            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                SqlCommand cmdn = new SqlCommand();
                                cmdn.Connection = connection;
                                cmdn.CommandType = CommandType.StoredProcedure;
                                cmdn.CommandText = "AReceiveBidsIPO";
                                cmdn.Parameters.AddWithValue("@Bank", "0");
                                cmdn.Parameters.AddWithValue("@Branch", "0");
                                cmdn.Parameters.AddWithValue("@Accountnumber", "0");
                                cmdn.Parameters.AddWithValue("@No_of_Notes_Applied", quantity);
                                cmdn.Parameters.AddWithValue("@AmountPaid", tot);
                                cmdn.Parameters.AddWithValue("@PaymentRefNo", "Escrow");
                                cmdn.Parameters.AddWithValue("@ClientType", "LI");
                                cmdn.Parameters.AddWithValue("@BrokerReference", "OMSEC");
                                cmdn.Parameters.AddWithValue("@DividendDisposalPreference", "M");
                                cmdn.Parameters.AddWithValue("@MNO_", "ONLINE");
                                cmdn.Parameters.AddWithValue("@Identification", cdsNumber);
                                cmdn.Parameters.AddWithValue("@TelephoneNumber", cdsNumber);
                                cmdn.Parameters.AddWithValue("@CDSC_Number", cdsNumber);
                                cmdn.Parameters.AddWithValue("@ReceiptNumber", "Escrow");
                                cmdn.Parameters.AddWithValue("@Company", company);
                                //cmdn.Parameters.AddWithValue("@Custodian", "0");
                                //cmdn.Parameters.AddWithValue("@TransNum", "0");
                                //cmdn.Parameters.AddWithValue("@PledgeIndicator", "0");
                                //cmdn.Parameters.AddWithValue("@PledgeeBPID", cdsNumber);
                                connection.Open();
                                if (cmdn.ExecuteNonQuery() > 0)
                                {
                                    connection.Close();
                                    return "1";
                                }
                                else
                                {
                                    connection.Close();
                                    return "Error saving IPO";
                                }
                            }
                        }
                        else
                        {
                            tempDbContext.PreOrderLivesIPOesV2.Add(orderPreorderCdsc);
                            tempDbContext.SaveChanges();
                            return "1";
                        }

                        //return "1";
                    }
                    catch (Exception e)
                    {
                        return "Error occured please try again";
                    }
                }
                catch (Exception e)
                {
                    return "Error occured please try again";
                }

            }
            catch (Exception ex)
            {
                return "Error occured please try again";
            }
        }
        public string OrderIPOPostingPOSTANDROID(string company, string quantity, string price, string cdsNumber, string corp_name = null, string corp_id = null)
        {
            var tot = Math.Round(decimal.Parse(price) * int.Parse(quantity), 2);


            var returnVal = LIMITS_CHECK(company, cdsNumber, quantity);
            if (returnVal != "0")
            {
                return returnVal;
            }
            //IF BUY ORDER
            var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(price);
            var tempDbContext = new cdscDbContext();
            var moneyAvail =
                    tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

            var orderStatus = "OPEN";
            var createdDate = DateTime.Now;
            var dealBeginDate = DateTime.Now;
            var expiryDate = DateTime.Now;
            var theQuantity = 0;
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture);
            var timeInForce = "Day Order (DO)";
            var orderQualifier = "None";
            //save to cdsc tempPreorderLive too
            var orderPreorderCdsc = new PreOrderLivesIPOesV2
            {
                OrderType = "Buy",
                Company = company,
                SecurityType = "Equity",
                CDS_AC_No = cdsNumber,
                Broker_Code = "OMSEC",
                OrderStatus = "OPEN",
                Create_date = createdDate,
                Expiry_Date = createdDate,
                Quantity = theQuantity,
                BasePrice = basePrice,
                TimeInForce = timeInForce,
                OrderQualifier = orderQualifier,
                BrokerRef = "OMSEC",
                OrderNumber = "12",
                Source = "Online",
                corp_name = corp_name,
                corp_id = corp_id,
                authorised_status = "not authorised"
            };


            if (corp_name == null)
            {
                if (moneyAvail != null)
                {
                    var theCashBal =
                        tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                            .Select(x => x.Amount)
                            .Sum();
                    if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                else
                {
                    return "You have insufficient balance in your Cash account";
                }


                var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //String mycds_ = GetCdsNumberFROMMOBILE(mobile);
                    SqlCommand cmdn = new SqlCommand();
                    cmdn.Connection = connection;
                    cmdn.CommandType = CommandType.StoredProcedure;
                    cmdn.CommandText = "AReceiveBidsIPO";
                    cmdn.Parameters.AddWithValue("@Bank", "0");
                    cmdn.Parameters.AddWithValue("@Branch", "0");
                    cmdn.Parameters.AddWithValue("@Accountnumber", "0");
                    cmdn.Parameters.AddWithValue("@No_of_Notes_Applied", quantity);
                    cmdn.Parameters.AddWithValue("@AmountPaid", tot);
                    cmdn.Parameters.AddWithValue("@PaymentRefNo", "Escrow");
                    cmdn.Parameters.AddWithValue("@ClientType", "LI");
                    cmdn.Parameters.AddWithValue("@BrokerReference", "OMSEC");
                    cmdn.Parameters.AddWithValue("@DividendDisposalPreference", "M");
                    cmdn.Parameters.AddWithValue("@MNO_", "ANDROID");
                    cmdn.Parameters.AddWithValue("@Identification", cdsNumber);
                    cmdn.Parameters.AddWithValue("@TelephoneNumber", "");
                    cmdn.Parameters.AddWithValue("@CDSC_Number", cdsNumber);
                    cmdn.Parameters.AddWithValue("@ReceiptNumber", "Escrow");
                    cmdn.Parameters.AddWithValue("@Company", company);
                    //cmdn.Parameters.AddWithValue("@Custodian", "0");
                    //cmdn.Parameters.AddWithValue("@TransNum", "0");
                    //cmdn.Parameters.AddWithValue("@PledgeIndicator", "0");
                    //cmdn.Parameters.AddWithValue("@PledgeeBPID", cdsNumber);
                    connection.Open();
                    if (cmdn.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        //save to cdsc tempPreorderLive too
                        var orderCashTrans = new CashTrans
                        {
                            Description = "IPO - BUY",
                            TransType = "BUY",
                            TransStatus = "1",
                            Amount = -totalAmountToSpent,
                            CDS_Number = cdsNumber,
                            DateCreated = DateTime.Now
                        };

                        tempDbContext.CashTrans.Add(orderCashTrans);
                        tempDbContext.SaveChanges();
                        return "Order placed successfully";
                    }
                    else
                    {
                        connection.Close();
                        return "Error placing order";
                    }
                }
            }
            else
            {
                tempDbContext.PreOrderLivesIPOesV2.Add(orderPreorderCdsc);
                tempDbContext.SaveChanges();
                return "Company Primary Order placed successfully";
            }

        }
        public JsonResult getAllDetails(string cdsNumber)
        {
            var getBrk = "SELECT  TOP 1  ISNULL(ut.min_value_threshold , 10) as min_value_threshold , " +
                            " t.* From[CDS_ROUTER].[dbo].[Accounts_Clients] t left join[CDS_ROUTER].[dbo].[Client_Companies] ut on " +
                            " ut.Company_Code = t.BrokerCode " +
                            " where t. CDS_Number = '" + cdsNumber + "' ";

            var order = new Accounts_Clients_MYPROF();
            var listOfBrokers = new List<Accounts_Clients_MYPROF>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        order.BrokerCode = rdr["BrokerCode"].ToString();
                        order.Title = rdr["Title"].ToString();
                        order.Nationality = rdr["Nationality"].ToString();
                        order.Add_1 = rdr["Add_1"].ToString();
                        order.Country = rdr["Country"].ToString();
                        order.Mobile = rdr["Mobile"].ToString();
                        order.Email = rdr["Email"].ToString();
                        order.Custodian = rdr["Custodian"].ToString();
                        order.Cash_Bank = rdr["Cash_Bank"].ToString();
                        order.Cash_Branch = rdr["Cash_Branch"].ToString();
                        order.Cash_AccountNo = rdr["Cash_AccountNo"].ToString();
                        order.idnopp = rdr["idnopp"].ToString();
                        order.mobile_number = rdr["mobile_number"].ToString();
                        order.CDS_Number = rdr["CDS_Number"].ToString();
                        order.Surname = rdr["Surname"].ToString();
                        order.Forenames = rdr["Forenames"].ToString();
                        order.min_value_threshold = rdr["min_value_threshold"].ToString();
                        listOfBrokers.Add(order);
                    }

                    try
                    {
                        var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                        jsonResult.MaxJsonLength = int.MaxValue;
                        return jsonResult;
                    }
                    catch (Exception)
                    {
                        return Json("Error loading details", JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json("Error loading details", JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetBrokers(string company = null)
        {
            var getBrk =
                "  select Company_Code as Code, ISNULL(min_value_threshold , 10) as min_value_threshold , upper(Company_name) as Name  FROM [CDS_ROUTER].[dbo].[Client_Companies] where Company_type='BROKER'";


            var listOfBrokers = new List<Broker>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Broker broker = new Broker();
                    broker.Code = rdr["Code"].ToString();
                    broker.threshold = rdr["min_value_threshold"].ToString();
                    broker.Name = rdr["Name"].ToString();
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetCatalyst(string company_type)
        {
            var getBrk =
                "  select Company_Code as Code, ISNULL(min_value_threshold , 1) as min_value_threshold , upper(Company_name) as Name  FROM [CDS_ROUTER].[dbo].[Client_Companies] where Company_type='" + company_type + "'";


            var listOfBrokers = new List<Broker>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Broker broker = new Broker
                    {
                        Code = rdr["Code"].ToString(),
                        threshold = rdr["min_value_threshold"].ToString(),
                        Name = rdr["Name"].ToString()
                    };
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetCustodian(string company = null)
        {
            var getBrk =
                "select Company_Code as Code, ISNULL(min_value_threshold , 10) as  min_value_threshold, upper(Company_name) as Name  FROM [CDS_ROUTER].[dbo].[Client_Companies] where Company_type='CUSTODIAN'";

            var listOfBrokers = new List<Broker>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Broker broker = new Broker();
                    broker.Code = rdr["Code"].ToString();
                    broker.threshold = rdr["min_value_threshold"].ToString();
                    broker.Name = rdr["Name"].ToString();
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult GetCompaniesandPrices()
        {
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    Name = c.Company,
                    InitialPrice = c.InitialPrice,
                    Instrument = c.Instrument,
                    fnam = c.fnam,
                    WebCompanyName = c.fnam + "(" + c.Company + ") - $" + c.InitialPrice,
                    WebCompanyValue = c.Company + "," + c.InitialPrice,
                });
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCompaniesandPricesEXCHANGE(string exchange)
        {
            var companies = new List<CompanyPrices>();
            //load finsec 
            if (exchange.ToLower() == "zse")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                var sql = @"SELECT cast(ut.id as nvarchar) as 'Id' ,qt.fnam + '(' + ut.Ticker + ') - $' + cast(ut.Current_price as nvarchar) as 'WebCompanyName', ut.Ticker + ',' + cast(ut.Current_price as nvarchar) as 'WebCompanyValue'
                        FROM[CDS_ROUTER].[dbo].[ZSE_market_data] ut , testcds_ROUTER.dbo.para_company qt
                        WHERE ut.Ticker = qt.Company";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CompanyPrices recordSummary = new CompanyPrices();
                        recordSummary.Id = rdr["Id"].ToString();
                        recordSummary.WebCompanyName = rdr["WebCompanyName"].ToString();
                        recordSummary.WebCompanyValue = rdr["WebCompanyValue"].ToString();
                        companies.Add(recordSummary);
                    }
                }

            }
            else if (exchange.ToLower() == "finsec")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
                var sql = @"  SELECT cast(1 as nvarchar) as 'Id' ,b.fnam + '(' + b.company + ') - $' + cast(cast([Average Price] as numeric(18,4)) as nvarchar) as 'WebCompanyName', b.company + ',' + cast(cast([Average Price] as numeric(18,4)) as nvarchar) as 'WebCompanyValue' FROM [testcds_ROUTER].[dbo].[MarketWatch] a, testcds_ROUTER.dbo.para_company b WHERE a.company = b.Company";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CompanyPrices recordSummary = new CompanyPrices();
                        recordSummary.Id = rdr["Id"].ToString();
                        recordSummary.WebCompanyName = rdr["WebCompanyName"].ToString();
                        recordSummary.WebCompanyValue = rdr["WebCompanyValue"].ToString();
                        companies.Add(recordSummary);
                    }
                }
            }

            //load zse

            /*
            var atsDbContext = new AtsDbContext();
            //Selecting distinct
            var companies =
                atsDbContext.para_company.Where(x => x.exchange == exchange).GroupBy(x => x.fnam).Select(x => x.FirstOrDefault()).Select(c =>
                new
                {
                    Id = c.ID,
                    WebCompanyName = c.fnam + "(" + c.Company + ") - $" + c.InitialPrice,
                    WebCompanyValue = c.Company + "," + c.InitialPrice,
                });
                */
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        public string testOrder(String quantity, String ammt)
        {
            var totalAmountToSpent = decimal.Parse(quantity) * decimal.Parse(ammt) * decimal.Parse("1.01693");
            return totalAmountToSpent + " ";
        }
        public string GetCustodianNumberFROMCDSNo(string cds)
        {
            var getBrk =
                "SELECT TOP 1 Custodian FROM [CDS_ROUTER].[dbo].[Accounts_Clients] where CDS_Number = '" +
                cds + "'";
            var order = new Accounts_Clients();
            var ret = "";
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                var rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ret += rdr["Custodian"].ToString();
                    }

                    try
                    {
                        return ret;
                    }
                    catch (Exception)
                    {
                        return "1";
                    }
                }
                else
                {
                    return "0";
                }
            }
        }
        public string testAccountinJoint(string cdsNo)
        {

            try
            {
                var getBrk =
                    "select * from CDS_ROUTER.DBO.Accounts_Joint WHERE PermissionPost = 'yes' and ( cds_number = '" + cdsNo + "' or email = '" + cdsNo + "' )  ";

                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand(getBrk, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    connection.Open();
                    var rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            catch (Exception ex)
            {

                return "false";
            }
        }
        public JsonResult myCompanylistToPOST(string cds_number = null)
        {

            if (cds_number == null)
            {
                cds_number = "none";
            }

            var getBrk =
                "SELECT t.cds_number as account_number ,  t.CDSNo as company_code , ut.Surname as company_name FROM [CDS_ROUTER].[dbo].[Accounts_Joint] t , [CDS_ROUTER].[dbo].[Accounts_Audit] ut WHERE t.CDSNo = ut.CDS_Number and t.PermissionPost = 'yes' and t.cds_number = '" + cds_number + "'";

            var listOfBrokers = new List<MyCompanyLists>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(getBrk, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MyCompanyLists broker = new MyCompanyLists();
                    broker.CompanyCode = rdr["company_code"].ToString();
                    broker.CompanyName = rdr["company_name"].ToString();
                    broker.AccountNumber = rdr["account_number"].ToString();
                    listOfBrokers.Add(broker);
                }

                try
                {
                    var jsonResult = Json(listOfBrokers, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Data set too large", JsonRequestBehavior.AllowGet);
                }
            }
        }
        public JsonResult getCompanyOrdersLists(string cds_number = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
            var preorder_live = new List<PreOrderLivess_new>();

            var sql =
                "SELECT t.* , ut.[fnam] FROM [CDSC].[dbo].[PreOrderLives] t , [testcds_ROUTER].[dbo].[para_company] ut WHERE t.Company  = ut.[Company] and t.corp_id = '" + cds_number + "' order by t.ID desc ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //SELECT t.* , ut.[fnam]  
                    //FROM[CDSC].[dbo].[PreOrderLives] t , [testcds_ROUTER].[dbo].[para_company]
                    //ut where t.Company  = ut.[Company]
                    //ID, OrderType, Company, SecurityType, CDS_AC_No, Broker_Code, OrderStatus, Expiry_date, Create_date, Quantity, BasePrice, 
                    //TimeInForce, OrderQualifier, BrokerRef, OrderNumber, Source, corp_name, corp_id, authorised_status

                    PreOrderLivess_new recordSummary = new PreOrderLivess_new();
                    recordSummary.id = rdr["ID"].ToString();
                    recordSummary.price = rdr["BasePrice"].ToString();
                    recordSummary.volume = rdr["Quantity"].ToString();
                    recordSummary.type = rdr["OrderType"].ToString();
                    recordSummary.desc = GetTradingPlaform(rdr["Company"].ToString()) + "-" + rdr["Broker_Code"].ToString();
                    recordSummary.counter = rdr["Company"].ToString();
                    recordSummary.date = rdr["Create_date"].ToString();
                    recordSummary.status = rdr["authorised_status"].ToString();
                    recordSummary.fullname = rdr["fnam"].ToString();
                    preorder_live.Add(recordSummary);
                }
            }

            if (preorder_live.Any())
            {
                return Json(preorder_live, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("No data was found", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetMyOrderslists(string cdsNumber = null)
        {
            string cdcnumber = "";
            try
            {
                var cdc = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.CDS_Number.ToLower().Replace(" ", "") == cdsNumber.ToLower().Replace(" ", "")).FirstOrDefault();
                cdcnumber = cdc.CDC_Number;
            }
            catch (Exception)
            {

               
            }
            var sql = @" SELECT 
	                (select top 1 qt.fnam from [testCDS_ROUTER].[dbo].[para_company] qt where qt.Company=ut.Company) fnam ,	ut.*,t.* 
	                FROM [testcds_ROUTER].[dbo].[Pre_Order_Live] ut
	                left outer join
	                [CDS_ROUTER].[dbo].[ZSE_market_data] t on t.Ticker=ut.Company
	                  where CDS_AC_No ='" + cdsNumber.Trim() + @"' order by ut.OrderNo desc
                ";
            if (string.IsNullOrEmpty(cdcnumber)==false)
            {
                sql = @" SELECT 
	                (select top 1 qt.fnam from [testCDS_ROUTER].[dbo].[para_company] qt where qt.Company=ut.Company) fnam ,	ut.*,t.* 
	                FROM [testcds_ROUTER].[dbo].[Pre_Order_Live] ut
	                left outer join
	                [CDS_ROUTER].[dbo].[ZSE_market_data] t on t.Ticker=ut.Company
	                  where CDS_AC_No in ('" + cdsNumber.Trim() + @"','" + cdcnumber.Trim() + @"') order by ut.OrderNo desc
                ";
            }
            List<Pre_Order_Lives_new> my = new List<Pre_Order_Lives_new>();
            using (SqlConnection connection = new SqlConnection(connectionStringATS))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["Company"].ToString() != "OMZIL")
                    {
                        my.Add(new Pre_Order_Lives_new()
                        {
                            date = rdr["Create_date"].ToString(),
                            id = rdr["OrderNo"].ToString(),
                            counter = rdr["Company"].ToString(),
                            type = rdr["OrderType"].ToString(),
                            volume = rdr["Quantity"].ToString(),
                            price = rdr["BasePrice"].ToString(),
                            status = rdr["OrderStatus"].ToString(),
                            desc = rdr["trading_platform"].ToString() + " - " + rdr["Broker_Code"].ToString(),
                            fullname = rdr["fnam"].ToString(),
                            current_price = rdr["Current_price"].ToString(),
                            askprice = rdr["Best_Ask"].ToString(),
                            askvolume = rdr["Ask_Volume"].ToString(),
                            bidprice = rdr["Best_bid"].ToString(),
                            bidvolume = rdr["Bid_Volume"].ToString(),
                            AmountValue = rdr["AmountValue"].ToString(),

                           security_type = rdr["SecurityType"].ToString()


                        });
                    }

                }
                var connectionStrings = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;

                var sqls = @"SELECT ut.* , t.* , qt.fnam FROM  [testCDS_ROUTER].[dbo].[Pre_Order_Live] ut ,
                    [testCDS_ROUTER].[dbo].[para_company] qt ,  [testcds_ROUTER].[dbo].[marketwatch] t 
                    WHERE ut.Company = qt.Company and t.company = ut.Company and ut.CDS_AC_No = '" + cdsNumber.Trim() + @"' order by  ut.OrderNo DESC 
                ";

                using (SqlConnection connections = new SqlConnection(connectionStrings))
                {
                    SqlCommand cmds = new SqlCommand(sqls, connections);
                    cmds.CommandType = CommandType.Text;
                    connections.Open();
                    SqlDataReader rdrs = cmds.ExecuteReader();
                    while (rdrs.Read())
                    {
                        if (rdrs["Company"].ToString() == "OMZIL")
                        {
                            my.Add(new Pre_Order_Lives_new()
                            {
                                date = rdrs["Create_date"].ToString(),
                                id = rdrs["OrderNo"].ToString(),
                                counter = rdrs["Company"].ToString(),
                                type = rdrs["OrderType"].ToString(),
                                volume = rdrs["Quantity"].ToString(),
                                price = rdrs["BasePrice"].ToString(),
                                status = rdrs["OrderStatus"].ToString(),
                                desc = rdrs["trading_platform"].ToString() + " - " + rdrs["Broker_Code"].ToString(),
                                fullname = rdrs["fnam"].ToString(),
                                current_price = rdrs["Average Price"].ToString(),
                                askprice = rdrs["Ask"].ToString(),
                                askvolume = rdrs["Volume Sell"].ToString(),
                                bidprice = rdrs["Bid"].ToString(),
                                bidvolume = rdrs["Volume"].ToString(),
                                security_type = rdrs["SecurityType"].ToString()

                            });
                        }
                    }
                }



                try
                {
                    var jsonResult = Json(my, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }

                catch (Exception)
                {
                    return Json("Error loading data", JsonRequestBehavior.AllowGet);
                }
            }

        }
        public JsonResult GetEquityOrders(string cdsNumber = null)
        {


            var sql = @"  SELECT 
	                (select top 1 qt.fnam from [testCDS_ROUTER].[dbo].[para_company] qt where qt.Company=ut.Company) fnam ,	ut.*,t.* 
	                FROM [testcds_ROUTER].[dbo].[Pre_Order_Live] ut
	                left outer join
	                [CDS_ROUTER].[dbo].[ZSE_market_data] t on t.Ticker=ut.Company
	                  where CDS_AC_No ='" + cdsNumber.Trim() + @"' order by ut.OrderNo desc
                ";

            List<Pre_Order_Lives_new> my = new List<Pre_Order_Lives_new>();
            using (SqlConnection connection = new SqlConnection(connectionStringATS))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["Company"].ToString() != "OMZIL")
                    {
                        my.Add(new Pre_Order_Lives_new()
                        {
                            date = rdr["Create_date"].ToString(),
                            id = rdr["OrderNo"].ToString(),
                            counter = rdr["Company"].ToString(),
                            type = rdr["OrderType"].ToString(),
                            volume = rdr["Quantity"].ToString(),
                            price = rdr["BasePrice"].ToString(),
                            status = rdr["OrderStatus"].ToString(),
                            desc = rdr["trading_platform"].ToString() + " - " + rdr["Broker_Code"].ToString(),
                            fullname = rdr["fnam"].ToString(),
                            current_price = rdr["Current_price"].ToString(),
                            askprice = rdr["Best_Ask"].ToString(),
                            askvolume = rdr["Ask_Volume"].ToString(),
                            bidprice = rdr["Best_bid"].ToString(),
                            bidvolume = rdr["Bid_Volume"].ToString(),
                            security_type = rdr["SecurityType"].ToString()

                        });
                    }

                }
                var connectionStrings = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;

                var sqls = @"SELECT ut.* , t.* , qt.fnam FROM  [testCDS_ROUTER].[dbo].[Pre_Order_Live] ut ,
                    [testCDS_ROUTER].[dbo].[para_company] qt ,  [testcds_ROUTER].[dbo].[marketwatch] t 
                    WHERE ut.Company = qt.Company and t.company = ut.Company and ut.CDS_AC_No = '" + cdsNumber.Trim() + @"' order by  ut.OrderNo DESC 
                ";

                using (SqlConnection connections = new SqlConnection(connectionStrings))
                {
                    SqlCommand cmds = new SqlCommand(sqls, connections);
                    cmds.CommandType = CommandType.Text;
                    connections.Open();
                    SqlDataReader rdrs = cmds.ExecuteReader();
                    while (rdrs.Read())
                    {
                        if (rdrs["Company"].ToString() == "OMZIL")
                        {
                            my.Add(new Pre_Order_Lives_new()
                            {
                                date = rdrs["Create_date"].ToString(),
                                id = rdrs["OrderNo"].ToString(),
                                counter = rdrs["Company"].ToString(),
                                type = rdrs["OrderType"].ToString(),
                                volume = rdrs["Quantity"].ToString(),
                                price = rdrs["BasePrice"].ToString(),
                                status = rdrs["OrderStatus"].ToString(),
                                desc = rdrs["trading_platform"].ToString() + " - " + rdrs["Broker_Code"].ToString(),
                                fullname = rdrs["fnam"].ToString(),
                                current_price = rdrs["Average Price"].ToString(),
                                askprice = rdrs["Ask"].ToString(),
                                askvolume = rdrs["Volume Sell"].ToString(),
                                bidprice = rdrs["Bid"].ToString(),
                                bidvolume = rdrs["Volume"].ToString(),
                                security_type = rdrs["SecurityType"].ToString()

                            });
                        }
                    }
                }



                try
                {
                    var jsonResult = Json(my, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Error loading data", JsonRequestBehavior.AllowGet);
                }
            }

        }
        public JsonResult getqueslists(string cdsNumber = null)
        {


            var sql = @"SELECT TOP 1 * FROM [CDSC].[dbo].[signup_qsn] where cds_number = '" + cdsNumber.Trim() + @"' ";

            List<Signup_qsn> my = new List<Signup_qsn>();
            using (SqlConnection connection = new SqlConnection(connectionStringATS))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    my.Add(new Signup_qsn()
                    {
                        id = rdr["id"].ToString(),
                        cds_number = rdr["cds_number"].ToString(),
                        qsn_one = rdr["qsn_one"].ToString(),
                        qsn_two = rdr["qsn_two"].ToString(),
                        qsn_three = rdr["qsn_three"].ToString(),


                    });

                }

                try
                {
                    var jsonResult = Json(my, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    return Json("Error loading data", JsonRequestBehavior.AllowGet);
                }
            }

        }
        public String insertQuestions(string cdsNumber = null, string qsn_one = null, string qsn_two = null, string qsn_three = null)
        {


            var sql = @"INSERT INTO [CDSC].[dbo].[signup_qsn]
                               ([cds_number]
                               ,[qsn_one]
                               ,[qsn_two]
                               ,[qsn_three])
                         VALUES
                               ('" + cdsNumber.Trim() + @"'
                               ,'" + qsn_one.Trim() + @"'
                               ,'" + qsn_two.Trim() + @"'
                               ,'" + qsn_three.Trim() + @"') ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringATS))
                {


                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return "Inserted questions successfully";


                }

            }
            catch (Exception ex)
            {
                return "Error loading data" + sql + ex;
            }

        }


        public String SubscribersInsert(string username = null, string email = null, string password = null,
          string phone = null, string cdsnumber = null, string fullname = null, string comp_authorizer = null, string comp_initiator = null,string isCompany = null)
        {
            string newcds = "";
    
            int activate = 1;
            if (isCompany == "c")
            {
                activate = 0;
            }

            try
            {

                var cds = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefault();
                newcds = cds.CDS_Number;

            }
            catch (Exception)
            {


            }
            if (newcds=="")
            {
                newcds = cdsnumber;
            }
            var sql = "INSERT INTO [CDSC].[dbo].[Vatenkecis] ([Username],[Email],[Password],[PhoneNumber],[CdsNumber],[Active],[Date],[EmailSend],[FullName],[comp_authorizer],[comp_initiator]) VALUES (@username,@email,@password,@phone,@cdsnumber,@activate,GETDATE(),0,@fullname,@comp_authorizer,@comp_initiator)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringATS))
                {

                    string encryptedPassword = EncryptIt(password.Trim());

                    SqlCommand cmd = new SqlCommand(sql, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@username", username.Trim());
                    cmd.Parameters.AddWithValue("@email", email.Trim());
                    cmd.Parameters.AddWithValue("@password", encryptedPassword);
                    cmd.Parameters.AddWithValue("@phone", phone.Trim());
                    cmd.Parameters.AddWithValue("@cdsnumber", newcds);
                    cmd.Parameters.AddWithValue("@activate", activate);
                    cmd.Parameters.AddWithValue("@fullname", fullname.Trim());
                    cmd.Parameters.AddWithValue("@comp_authorizer", comp_authorizer.Trim());
                    cmd.Parameters.AddWithValue("@comp_initiator", comp_initiator.Trim());
                    cmd.CommandTimeout = 0;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    try
                    {
                        investmentclubs(email, cdsnumber);
                    }
                    catch (Exception)
                    {

                    }
                    return "1";


                }

            }
            catch (Exception ex)
            {
                return "0" + sql + ex;
            }

        }
        public String insertAlerts(string company = null, string cds_number = null, string price = null)
        {

            var today = DateTime.Today.ToString();

            var sql = @"INSERT INTO [CDS_ROUTER].[dbo].[Alerts]
                               ([company]
                               ,[cds_number]
                               ,[price]
                               ,[sent]
                               ,[active]
                               ,[update_on])
                         VALUES
                               ('" + company.Trim() + @"'
                               ,'" + cds_number.Trim() + @"'
                               ,'" + price.Trim() + @"'
                               ,0
                                ,0
                               ,'" + today + @"') ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringATS))
                {


                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                  
                    return "Alert request submitted successfully";


                }

            }
            catch (Exception ex)
            {
                return "Error loading data" + sql + ex;
            }

        }

        public void investmentclubs(string email,string cds){

            string sql= "Update club_members set cdsnumber='"+cds+ "' where member_email='" + email+"'";
            var updt = _cdscDbContext.Database.ExecuteSqlCommand(sql);

            }

        public String executeDemat(string cds_number = null, string certificate_number = null, string shares = null, string company = null)
        {
            var sql = @"INSERT INTO [CDS_ROUTER].[dbo].[batch_certs]
                               ([batch_no],
                                [cds_number]
                               ,[certificate_no]
                               ,[shares]
                               ,[company])
                         VALUES
                               ('1'
                               ,'" + cds_number.Trim() + @"'
                               ,'" + certificate_number.Trim() + @"'
                               ,'" + shares.Trim() + @"'
                               ,'" + company.Trim() + @"') ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringATS))
                {


                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return "Request has been received. You will be notified after processing.";


                }

            }
            catch (Exception ex)
            {
                return "Error loading data" + sql + ex;
            }

        }

        // club methods
        public JsonResult CreateClub(string chairmain,int clubnumber,string clubname,string clubphone,string phone)
        {
           string result = "";
            try
            {
                //            var cdDataContext = new CdDataContext();
                investment_club investment_Club = new investment_club();
                investment_Club.chairman_id = chairmain;
                investment_Club.club_member_num = clubnumber.ToString();
                investment_Club.club_name = clubname;
                investment_Club.club_phone = clubphone;
                investment_Club.created_date = DateTime.Now;
                investment_Club.phone = phone;
                investment_Club.Active = true;
                _cdscDbContext.investment_club.Add(investment_Club);
                _cdscDbContext.SaveChanges();
                result = "Club successfully created";

            }
            catch (Exception)
            {

                result = "Club not successfully created";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateClubID(string chairmain, int clubnumber, string clubname, string clubphone, string phone)
        {
            string result ="Blue";
            try
            {
                // var cdDataContext = new CdDataContext();
                investment_club investment_Club = new investment_club();
                investment_Club.chairman_id = chairmain;
                investment_Club.club_member_num = clubnumber.ToString();
                investment_Club.club_name = clubname;
                investment_Club.club_phone = clubphone;
                investment_Club.created_date = DateTime.Now;
                investment_Club.phone = phone;
                investment_Club.Active = true;
                investment_Club.club_cds_number = RandomNumber(100000, 90000000).ToString() + "/" + RandomNumber(1000, 90000).ToString() + RandomString(4, true);

                _cdscDbContext.investment_club.Add(investment_Club);
                _cdscDbContext.SaveChanges();
                var max = _cdscDbContext.investment_club.ToList().Max(a => a.id);
               var result2 = max.ToString();
                return Json(result2, JsonRequestBehavior.AllowGet);
            }
            catch (Exception f)
            {
       
                return Json(f.Message, JsonRequestBehavior.AllowGet);
            }

            return Json("blue", JsonRequestBehavior.AllowGet);
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public JsonResult EditClub(string chairmain, int clubnumber, string clubname, string clubphone, string phone, int clubid)
        {
            string result = "";
            try
            {
                //            var cdDataContext = new CdDataContext();
                investment_club investment_Club =_cdscDbContext.investment_club.Find(clubid);
                investment_Club.chairman_id = chairmain;
                investment_Club.club_member_num = clubnumber.ToString();
                investment_Club.club_name = clubname;
                investment_Club.club_phone = clubphone;
                investment_Club.created_date = DateTime.Now;
                investment_Club.phone = phone;
                investment_Club.Active = true;
                _cdscDbContext.investment_club.AddOrUpdate(investment_Club);
                _cdscDbContext.SaveChanges();
                result = "Club successfully updated";

            }
            catch (Exception)
            {

                result = "Club not successfully updated";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveClub(int clubid)
        {
            string result = "";
            try
            {
                //            var cdDataContext = new CdDataContext();
                investment_club investment_Club = _cdscDbContext.investment_club.Find(clubid);
      
                investment_Club.Active = false;
                _cdscDbContext.investment_club.AddOrUpdate(investment_Club);
                _cdscDbContext.SaveChanges();
                result = "Club successfully removed";

            }
            catch (Exception)
            {

                result = "Club removed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Clublist(string cdsno)
        {
            string result = "";
            List<investment_club> clublist = (from s in _cdscDbContext.investment_club
                                             where s.chairman_id == cdsno && s.Active==true
                                             select s).ToList();

            //return Json(clublist, JsonRequestBehavior.AllowGet);
            return new CustomJsonResult { Data = new { clublist } };
        }
        public JsonResult ClublistMember(string cdsno)
        {
            string result = "";
            var clublist = (from s in _cdscDbContext.club_members
                            join v in _cdscDbContext.investment_club on s.club_id equals v.id
                            let ClubName=v.club_name
                            let Clubid=v.id
                                              where s.cdsnumber==cdsno 
                                              select new { ClubName,Clubid}).ToList();

         
            return new CustomJsonResult { Data = new { clublist } };
        }
        public JsonResult ClublistById(int id)
        {
            string result = "";
            List<investment_club> clublist = (from s in _cdscDbContext.investment_club
                                            where s.id == id
                                              select s).ToList();

            //return Json(clublist, JsonRequestBehavior.AllowGet);
            return new CustomJsonResult { Data = new { clublist } };
        }
        public JsonResult ClublistMembers(int clubid)
        {
            string result = "";
            List<club_members> clublist = (from s in _cdscDbContext.club_members where s.club_id == clubid && s.Active == true && s.rejected==false select s).ToList();
            //return Json(clublist, JsonRequestBehavior.AllowGet);
            return new CustomJsonResult { Data = new { clublist } };
        }

        
        //membermethods

        public JsonResult ClubMemberAdd(string clubphone,string clubcds,string phone,string email,string surname,string firstname,string club_id)
        {
           string result = "Member successfully added";
            try
            {

                club_members club_Members = new club_members();
                club_Members.club_phone = clubphone;
                club_Members.member_cds_number = clubcds;
                club_Members.member_phone = phone;
                club_Members.member_email = email;
                club_Members.club_id = Convert.ToInt32(club_id);
                club_Members.confirmed = false;
                club_Members.rejected = false;
                club_Members.created_date = DateTime.Now;
                club_Members.Surname = surname;
                club_Members.Firstname = firstname;
                club_Members.Active = true;
                club_Members.cdsnumber = "n/a";
               _cdscDbContext.club_members.Add(club_Members);
                _cdscDbContext.SaveChanges();

                var mynames = _cdscDbContext.investment_club.ToList().Where(a => a.id == club_Members.club_id).FirstOrDefault();
                //send invite
               //var sent=SendSms("you have been invited to join C-Trade Investment Club " + mynames.club_name + " download Ctrade App https://play.google.com/store/apps/details?id=zw.co.escrow.ctradelive&hl=en or dial *727# to view More", phone);
            }
            catch (Exception f)
            {

                result = f.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClubMemberUpdate(string clubphone, string clubcds, string phone, string email,string surname, string firstname,string club_id,int clubmemberid)
        {
            string result = "Member successfully updated";
            try
            {

                club_members club_Members = _cdscDbContext.club_members.Find(clubmemberid);
                club_Members.member_phone = phone;
                club_Members.member_email = email;
               _cdscDbContext.club_members.AddOrUpdate(club_Members);
                _cdscDbContext.SaveChanges();
            }
            catch (Exception)
            {

                result = "Member not updated";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClubMemberRemove(int clubmemberid)
        {
            string result = "Member successfully removed";
            try
            {

                club_members club_Members = _cdscDbContext.club_members.Find(clubmemberid);
                club_Members.Active = false;
                _cdscDbContext.club_members.AddOrUpdate(club_Members);
                _cdscDbContext.SaveChanges();
            }
            catch (Exception)
            {

                result = "Member not removed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //check if member exsist
        public int Confirmmember(string email)
        {
            int result = 0;
            try
            {

                var membercount = _cdDataContext.Accounts_Clients_Web.ToList().Where(a=>a.Email.ToLower()==email.ToLower()).Count();

                if (membercount>0)
                {
                    result = 1;
                }
            }
            catch (Exception)
            {

                result =0;
            }
            return result;
        }
        public JsonResult CheckIfUserExists(string email)
        {
            var cdDataContexts = new cdscDbContext();
            var usernameFound = cdDataContexts.Vatenkecis.Where(x => x.Email.Trim() == email.Trim()).Count();

            if (usernameFound > 0)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            var usernameFound2 = _cdDataContext.Accounts_Clients_Web.Where(x => x.Email.Trim() == email.Trim()).Count();
            if (usernameFound2 > 0)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet); ;
        }

        public JsonResult LoadFunds(string isin)
        {

            var fundlist = (from v in _AtsDbContext.para_company
                           where v.ISIN_No == isin
                           let ID=v.ID
                           let Company = v.Company
                           let FundType = v.fnam
                           let InitialPrice = v.InitialPrice
                           let IssueDate = v.Date_created
                           let IssuePricePerUnit = v.InitialPrice
                           select new { ID,Company, FundType, InitialPrice, IssueDate, IssuePricePerUnit }).ToList();

    
          
            return new CustomJsonResult { Data = new { fundlist } };
        }
        //paynow
        [HttpGet]
        public async Task<ActionResult> PaynowPayments(
     string cdsNumber,
     string price,
     string quantity,
     string email,string currency)
        {
            cdscDbContext cdscDbContext = new cdscDbContext();
            if (cdsNumber == null && price == null && (quantity == null && email == null))
                return (ActionResult)this.View();
            Decimal num1 = Math.Round(Decimal.Parse(price) * Decimal.Parse(quantity), 2);
            BuyOrderPayments entity = new BuyOrderPayments()
            {
                CdsNumber = cdsNumber,
                Company = "None",
                Price = price,
                Security = "Equity",
                Total = num1.ToString((IFormatProvider)CultureInfo.InvariantCulture),
                Quantity = quantity,
                PaymentStatus = "PENDING",
                PostedStatus = "PENDING",
                Date = new DateTime?(DateTime.Now),
                Broker = "None",
                EmailAddress = email,
                Currency=currency
            };
            cdscDbContext.BuyOrderPayments.Add(entity);
            cdscDbContext.SaveChanges();
            BuyOrderPayments buyOrderPayments = new cdscDbContext().BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.CdsNumber == cdsNumber && x.PaymentStatus == "PENDING" && x.PostedStatus == "PENDING"));
            if (buyOrderPayments == null)
                return (ActionResult)this.View();
            Guid.NewGuid();
            int num2 = 5333;
            string guid = "2044befe-9f70-4ca2-9d59-d46e380ea284";
            /* return urlhttps://ctrade.co.zw/online/paynow/thankyou.php 
             * resulturlhttp://197.155.235.78:8446/CTRADEAPI/subscriber/PaynowPaymentsResultUrl
             * */
            string twoWayHash = SubscriberController.GenerateTwoWayHash(new Dictionary<string, string>()
      {
        {
          "id",
          num2.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          num1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/ctrade_v2/paynow/thankyou.php"
       
        },
        {
          "resulturl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrl"
        },
        {
          "status",
          "Message"
        }
      }, guid);
            FormUrlEncodedContent urlEncodedContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>()
      {
        {
          "id",
          num2.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          num1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/ctrade_v2/paynow/thankyou.php"
        },
        {
          "resulturl",
           "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrl"
        },
        {
          "status",
          "Message"
        },
        {
          "hash",
          twoWayHash
        }
      });
            string str = HttpUtility.UrlDecode(await (await SubscriberController.client.PostAsync("https://www.paynow.co.zw/interface/initiatetransaction", (HttpContent)urlEncodedContent)).Content.ReadAsStringAsync());
            List<string> stringList = new List<string>();
            if (str == null)
                return (ActionResult)this.View();
            stringList.AddRange((IEnumerable<string>)str.Split('&'));
            return (ActionResult)this.Redirect(stringList[1].Split('=')[1].Trim());
        }

        [HttpPost]
        public async Task<ActionResult> PaynowPayments(FormCollection formCollection)
        {
            string cdsNumber = formCollection["cdsNumber"];
            string form1 = formCollection["total"];
            string form2 = formCollection["security"];
            string form3 = formCollection["quantity"];
            string form4 = formCollection["company"];
            string form5 = formCollection["price"];
            BuyOrderPayments buyOrderPayments = new cdscDbContext().BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.CdsNumber == cdsNumber && x.PaymentStatus == "PENDING" && x.PostedStatus == "PENDING"));
            if (buyOrderPayments == null)
                return (ActionResult)this.View();
            Guid.NewGuid();
            int num = 5333;
            string guid = "2044befe-9f70-4ca2-9d59-d46e380ea284";
            string twoWayHash = SubscriberController.GenerateTwoWayHash(new Dictionary<string, string>()
      {
        {
          "id",
          num.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          form1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "http://197.155.235.78:8446/SSX/Ssx/PaynowPaymentsReturnUrl"
        },
        {
          "resulturl",
          "http://197.155.235.78:8446/SSX/Ssx/PaynowPaymentsResultUrl"
        },
        {
          "status",
          "Message"
        }
      }, guid);
            FormUrlEncodedContent urlEncodedContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>()
      {
        {
          "id",
          num.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          form1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "http://197.155.235.78:8446/SSX/Ssx/PaynowPaymentsReturnUrl"
        },
        {
          "resulturl",
          "http://197.155.235.78:8446/SSX/Ssx/PaynowPaymentsResultUrl"
        },
        {
          "status",
          "Message"
        },
        {
          "hash",
          twoWayHash
        }
      });
            string str = HttpUtility.UrlDecode(await (await SubscriberController.client.PostAsync("https://www.paynow.co.zw/interface/initiatetransaction", (HttpContent)urlEncodedContent)).Content.ReadAsStringAsync());
            List<string> stringList = new List<string>();
            if (str == null)
                return (ActionResult)this.View();
            stringList.AddRange((IEnumerable<string>)str.Split('&'));
            return (ActionResult)this.Redirect(stringList[1].Split('=')[1].Trim());
        }

        private static string GenerateTwoWayHash(Dictionary<string, string> items, string guid)
        {
            return SubscriberController.ByteArrayToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(string.Join("", items.Select<KeyValuePair<string, string>, string>((Func<KeyValuePair<string, string>, string>)(c =>
            {
                if (c.Value == null || !(c.Key.ToLower() != "hash"))
                    return "";
                return c.Value.Trim();
            })).ToArray<string>()) + guid)));
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
            foreach (byte num in ba)
                stringBuilder.AppendFormat("{0:x2}", (object)num);
            return stringBuilder.ToString().ToUpper();
        }

        public string PaynowPaymentsReturnUrl()
        {
            return "Thank you for paying with paynow";
        }

        [HttpPost]
        public void PaynowPaymentsResultUrl(FormCollection formCollection)
        {
            cdscDbContext cdscDbContext = new cdscDbContext();
            try
            {
                string form1 = formCollection["reference"];
                string form2 = formCollection["amount"];
                string form3 = formCollection["status"];
                string form4 = formCollection["pollurl"];
                string form5 = formCollection["paynowreference"];
                int intRef = int.Parse(form1);
                BuyOrderPayments buyOrderPayments = cdscDbContext.BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.Id == intRef));
                if (buyOrderPayments != null)
                {
                    buyOrderPayments.PaynowRef = form5;
                    buyOrderPayments.PollUrl = form4;
                    string paymentStatus = buyOrderPayments.PaymentStatus;
                    buyOrderPayments.PaymentStatus = form3;
                    buyOrderPayments.Total = form2;
                    cdscDbContext.SaveChanges();
                   /* if (!paymentStatus.ToString().Equals("Cancelled") ||!paymentStatus.ToString().Equals("PENDING") || !form3.Equals("Paid") && !form3.Equals("Delivered") && !form3.Equals("Awaiting Delivery"))
                        return;*/
                    if (buyOrderPayments.Currency == "ZWL")
                    {
                        CashTrans entity = new CashTrans()
                    {
                        Description = "PAYNOW DEPOSIT",
                        TransType = "DEPOSIT",
                        TransStatus = "1",
                        Amount = new Decimal?(Decimal.Parse(buyOrderPayments.Total)),
                        CDS_Number = buyOrderPayments.CdsNumber,
                        DateCreated = DateTime.Now
                    };
                    cdscDbContext.CashTrans.Add(entity);
                    cdscDbContext.SaveChanges();
                    buyOrderPayments.PostedStatus = form3;
                    cdscDbContext.SaveChanges();

                    }else if (buyOrderPayments.Currency != "ZWL")
                    {
                        CashTrans_forex entity = new CashTrans_forex()
                        {
                            Description = "PAYNOW DEPOSIT",
                            TransType = "DEPOSIT",
                            TransStatus = "1",
                            Amount = new Decimal?(Decimal.Parse(buyOrderPayments.Total)),
                            CDS_Number = buyOrderPayments.CdsNumber,
                            DateCreated = DateTime.Now,
                            Currency= buyOrderPayments.Currency

                        };
                        cdscDbContext.CashTrans_forex.Add(entity);
                        cdscDbContext.SaveChanges();
                        buyOrderPayments.PostedStatus = form3;
                        cdscDbContext.SaveChanges();
                    }
                
                }
                else
                {
                    BuyOrderPayments entity = new BuyOrderPayments()
                    {
                        PaymentStatus = form3,
                        PaynowRef = "Not Null" + (object)intRef
                    };
                    cdscDbContext.BuyOrderPayments.Add(entity);
                    cdscDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                BuyOrderPayments entity = new BuyOrderPayments()
                {
                    PaymentStatus = ex.Message
                };
                cdscDbContext.BuyOrderPayments.Add(entity);
                cdscDbContext.SaveChanges();
            }
        }

        //paynow usd
        [HttpGet]
        public async Task<ActionResult> PaynowPaymentsUSD(
   string cdsNumber,
   string price,
   string quantity,
   string email, string currency)
        {
            cdscDbContext cdscDbContext = new cdscDbContext();
            if (cdsNumber == null && price == null && (quantity == null && email == null))
                return (ActionResult)this.View();
            Decimal num1 = Math.Round(Decimal.Parse(price) * Decimal.Parse(quantity), 2);
            BuyOrderPayments entity = new BuyOrderPayments()
            {
                CdsNumber = cdsNumber,
                Company = "None",
                Price = price,
                Security = "Equity",
                Total = num1.ToString((IFormatProvider)CultureInfo.InvariantCulture),
                Quantity = quantity,
                PaymentStatus = "PENDING",
                PostedStatus = "PENDING",
                Date = new DateTime?(DateTime.Now),
                Broker = "None",
                EmailAddress = email,
                Currency = currency
            };
            cdscDbContext.BuyOrderPayments.Add(entity);
            cdscDbContext.SaveChanges();
            BuyOrderPayments buyOrderPayments = new cdscDbContext().BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.CdsNumber == cdsNumber && x.PaymentStatus == "PENDING" && x.PostedStatus == "PENDING"));
            if (buyOrderPayments == null)
                return (ActionResult)this.View();
            Guid.NewGuid();
            int num2 = 7948;
            string guid = "6bd35932-9706-4bad-b1f8-219ddd3829ab";
            /* return urlhttps://ctrade.co.zw/online/paynow/thankyou.php 
             * resulturlhttp://197.155.235.78:8446/CTRADEAPI/subscriber/PaynowPaymentsResultUrl
             * */
            string twoWayHash = SubscriberController.GenerateTwoWayHash(new Dictionary<string, string>()
      {
        {
          "id",
          num2.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          num1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/ctrade/paynow/thankyou.php"

        },
        {
          "resulturl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrlUSD"
        },
        {
          "status",
          "Message"
        }
      }, guid);
            FormUrlEncodedContent urlEncodedContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>()
      {
        {
          "id",
          num2.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          num1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/ctrade/paynow/thankyou.php"
        },
        {
          "resulturl",
           "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrlUSD"
        },
        {
          "status",
          "Message"
        },
        {
          "hash",
          twoWayHash
        }
      });
            string str = HttpUtility.UrlDecode(await (await SubscriberController.client.PostAsync("https://www.paynow.co.zw/interface/initiatetransaction", (HttpContent)urlEncodedContent)).Content.ReadAsStringAsync());
            List<string> stringList = new List<string>();
            if (str == null)
                return (ActionResult)this.View();
            stringList.AddRange((IEnumerable<string>)str.Split('&'));
            return (ActionResult)this.Redirect(stringList[1].Split('=')[1].Trim());
        }

        [HttpPost]
        public async Task<ActionResult> PaynowPaymentsUSD(FormCollection formCollection)
        {
            string cdsNumber = formCollection["cdsNumber"];
            string form1 = formCollection["total"];
            string form2 = formCollection["security"];
            string form3 = formCollection["quantity"];
            string form4 = formCollection["company"];
            string form5 = formCollection["price"];
            BuyOrderPayments buyOrderPayments = new cdscDbContext().BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.CdsNumber == cdsNumber && x.PaymentStatus == "PENDING" && x.PostedStatus == "PENDING"));
            if (buyOrderPayments == null)
                return (ActionResult)this.View();
            Guid.NewGuid();
            int num = 7948;
            string guid = "6bd35932-9706-4bad-b1f8-219ddd3829ab";
            string twoWayHash = SubscriberController.GenerateTwoWayHash(new Dictionary<string, string>()
      {
        {
          "id",
          num.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          form1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsReturnUrlUSD"
        },
        {
          "resulturl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrlUSD"
        },
        {
          "status",
          "Message"
        }
      }, guid);
            FormUrlEncodedContent urlEncodedContent = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new Dictionary<string, string>()
      {
        {
          "id",
          num.ToString()
        },
        {
          "reference",
          buyOrderPayments.Id.ToString()
        },
        {
          "amount",
          form1.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        },
        {
          "returnurl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsReturnUrlUSD"
        },
        {
          "resulturl",
          "https://demo.ctrade.co.zw/mobileapi/PaynowPaymentsResultUrlUSD"
        },
        {
          "status",
          "Message"
        },
        {
          "hash",
          twoWayHash
        }
      });
            string str = HttpUtility.UrlDecode(await (await SubscriberController.client.PostAsync("https://www.paynow.co.zw/interface/initiatetransaction", (HttpContent)urlEncodedContent)).Content.ReadAsStringAsync());
            List<string> stringList = new List<string>();
            if (str == null)
                return (ActionResult)this.View();
            stringList.AddRange((IEnumerable<string>)str.Split('&'));
            return (ActionResult)this.Redirect(stringList[1].Split('=')[1].Trim());
        }



        public string PaynowPaymentsReturnUrlUSD()
        {
            return "Thank you for paying with paynow";
        }

        [HttpPost]
        public void PaynowPaymentsResultUrlUSD(FormCollection formCollection)
        {
            cdscDbContext cdscDbContext = new cdscDbContext();
            try
            {
                string form1 = formCollection["reference"];
                string form2 = formCollection["amount"];
                string form3 = formCollection["status"];
                string form4 = formCollection["pollurl"];
                string form5 = formCollection["paynowreference"];
                int intRef = int.Parse(form1);
                BuyOrderPayments buyOrderPayments = cdscDbContext.BuyOrderPayments.OrderByDescending<BuyOrderPayments, int>((Expression<Func<BuyOrderPayments, int>>)(x => x.Id)).FirstOrDefault<BuyOrderPayments>((Expression<Func<BuyOrderPayments, bool>>)(x => x.Id == intRef));
                if (buyOrderPayments != null)
                {
                    buyOrderPayments.PaynowRef = form5;
                    buyOrderPayments.PollUrl = form4;
                    string paymentStatus = buyOrderPayments.PaymentStatus;
                    buyOrderPayments.PaymentStatus = form3;
                    buyOrderPayments.Total = form2;
                    cdscDbContext.SaveChanges();
                    if (!paymentStatus.ToString().Equals("PENDING") || !form3.Equals("Paid") && !form3.Equals("Delivered") && !form3.Equals("Awaiting Delivery"))
                        return;


                    CashTrans_forex entity = new CashTrans_forex()
                    {
                        Description = "PAYNOW DEPOSIT",
                        TransType = "DEPOSIT",
                        TransStatus = "1",
                        Amount = new Decimal?(Decimal.Parse(buyOrderPayments.Total)),
                        CDS_Number = buyOrderPayments.CdsNumber,
                        DateCreated = DateTime.Now,
                        Currency = buyOrderPayments.Currency

                    };
                    cdscDbContext.CashTrans_forex.Add(entity);
                    cdscDbContext.SaveChanges();
                    buyOrderPayments.PostedStatus = form3;
                    cdscDbContext.SaveChanges();


                }
                else
                {
                    BuyOrderPayments entity = new BuyOrderPayments()
                    {
                        PaymentStatus = form3,
                        PaynowRef = "Not Null" + (object)intRef
                    };
                    cdscDbContext.BuyOrderPayments.Add(entity);
                    cdscDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                BuyOrderPayments entity = new BuyOrderPayments()
                {
                    PaymentStatus = ex.Message
                };
                cdscDbContext.BuyOrderPayments.Add(entity);
                cdscDbContext.SaveChanges();
            }
        }
        //preshareholdercreation

        public JsonResult PreshareHolderExsists(string cdsnumber)
        {
            var fundlist = 0;
            fundlist =  _cdDataContext.Database.SqlQuery<Pre_created>("select * from Pre_Created where replace(cast(cast(Shareholder as decimal) as nvarchar),'-','')=cast('" + cdsnumber + "' as nvarchar)").ToList().Count();


            var cdsclist = _cdDataContext.Accounts_Clients_Web.ToList().Where(a=>a.CDS_Number==cdsnumber).Count();
            if (cdsclist > 0)
            {
                fundlist = 2;
            }
            return Json(fundlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PreshareHolder(string cdsnumber)
        {

            var predetails =_cdDataContext.Database.SqlQuery<Pre_created>("select * from Pre_Created where replace(cast(cast(Shareholder as decimal) as nvarchar),'-','')=cast('"+cdsnumber+"' as nvarchar)").ToList();
                       
            return new CustomJsonResult { Data = new { predetails } };
        }
        public JsonResult ForexTypes()
        {

            var predetails = _cdscDbContext.Database.SqlQuery<ForexTypes>("select * from ForexTypes").ToList();

            return Json(predetails, JsonRequestBehavior.AllowGet);
        }

        //insert into cashtrans forex
        public JsonResult LoadCash(string cdsnumber,string amount)
        {
            string result = "0";
            try
            {
                CashTrans_forex entity = new CashTrans_forex()
                {
                    Description = "DEPOSIT",
                    TransType = "DEPOSIT",
                    TransStatus = "1",
                    Amount = new Decimal?(Decimal.Parse(amount)),
                    CDS_Number = cdsnumber,
                    DateCreated = DateTime.Now,
                    Currency = "USD"

                };
                _cdscDbContext.CashTrans_forex.Add(entity);
                _cdscDbContext.SaveChanges();
                result = "1";
            }
            catch (Exception f)
            {

                result = "0";
            }

            //check for nominee
           var fundlist = _cdDataContext.Database.SqlQuery<Pre_created>("select * from Pre_Created where replace(cast(cast(Shareholder as decimal) as nvarchar),'-','')=cast('" + cdsnumber + "' as nvarchar)").ToList().FirstOrDefault();

            if (fundlist.For_Nominee==false)
            {
                var execAcc = _cdDataContext.Database.ExecuteSqlCommand("Update Accounts_Clients_Web set trading_platform='FINSEC',AccountState='PENDING' where CDS_Number='" + cdsnumber+"'");
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AndroidVersion()
        {

            var androidversion = _cdscDbContext.app_version.ToList().Take(1);
            return Json(androidversion, JsonRequestBehavior.AllowGet);
        }
        //get forex orders
        public JsonResult GetForex(string cds_number)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
            var marketWatcher = new List<Forex_O_Lives>();

            string sql = "select *, case when TransStatus='1' then 'Approved' else 'Pending' end as 'Final' from CashTrans_forex where CDS_Number='" + cds_number + "' and [Type_] in ('BUY','SELL') order by ID desc";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, connection)
                {
                    CommandType = CommandType.Text
                };
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Forex_O_Lives recordSummary = new Forex_O_Lives
                    {
                        id = int.Parse(rdr["ID"].ToString()),
                        counter = rdr["Currency"].ToString(),
                        type = rdr["Type_"].ToString(),
                        volume = rdr["Amount"].ToString(),
                        price = rdr["Rate"].ToString(),
                        date = DateTime.Parse(rdr["DateCreated"].ToString()).ToString("dd MMM yyyy"),
                        status = rdr["Final"].ToString(),
                        desc = rdr["Description"].ToString(),
                        fullname = rdr["CDS_Number"].ToString(),
                        ordernumber = rdr["ID"].ToString(),
                        source = rdr["Source"].ToString(),
                        Bureau= rdr["Bureau"].ToString()
                    };
                    marketWatcher.Add(recordSummary);
                }
            }

            if (marketWatcher.Any())
            {
                return Json(marketWatcher, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult SanctionedExsists(string search)
        {
            var fundlist = 0;
            fundlist = _cdsDataContext.Database.SqlQuery<SanctionedList>("select * from SanctionedList where REPLACE(LOWER(names+''+surname),' ','')=REPLACE(LOWER('" + search+"'),' ','')").ToList().Count();


           
            if (fundlist > 0)
            {
                fundlist = 1;
            }
            return Json(fundlist, JsonRequestBehavior.AllowGet);
        }
        //sanction validation
        public int SanctionedExsistsval(string search)
        {
            var fundlist = 0;
            fundlist = _cdsDataContext.Database.SqlQuery<SanctionedList>("select * from SanctionedList where REPLACE(LOWER(names+''+surname),' ','')=REPLACE(LOWER('" + search + "'),' ','')").ToList().Count();



            if (fundlist > 0)
            {
                fundlist = 1;
            }
            return fundlist;
        }

        public JsonResult IDExsists(string idno)
        {
            var fundlist = 0;
   
            var clientsweblist = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.IDNoPP.Replace(" ","") == idno.Replace(" ", "")).Count();
            if (clientsweblist > 0)
            {
                fundlist = 1;
            }
            var clientslist = _cdDataContext.Accounts_Clients.ToList().Where(a => a.IDNoPP.Replace(" ", "") == idno.Replace(" ", "")).Count();
            if (clientslist > 0)
            {
                fundlist = 1;
            }
            return Json(fundlist, JsonRequestBehavior.AllowGet);
        }

        // SELECT investment_club.*FROM [CDSC].[dbo].[club_members] inner join investment_club on investment_club.id = club_members.club_id where member_phone like '%775567639'
        public JsonResult GetMyMemberClubs(string phone)
        {
            var fundlist = 0;


            var clientsweblist = _cdscDbContext.Database.SqlQuery<investments_club_two>("SELECT investment_club.id, investment_club.chairman_id,investment_club.club_member_num,investment_club.club_name,investment_club.club_phone,convert(nvarchar, investment_club.created_date, 106) as created_date,phone,investment_club.Active,investment_club.club_cds_number FROM[CDSC].[dbo].[club_members] inner join investment_club on investment_club.id = club_members.club_id where member_phone like '%" + phone + "' and confirmed = '1' and rejected = '0'").ToList();

            return Json(clientsweblist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMyMemberClubsPending(string phone)
        {
            var fundlist = 0;

            var clientsweblist = _cdscDbContext.Database.SqlQuery<investment_club>("SELECT investment_club.* FROM [CDSC].[dbo].[club_members] inner join investment_club on investment_club.id = club_members.club_id where member_phone like '%" + phone + "' and club_members.confirmed ='0' ").ToList();

            return Json(clientsweblist, JsonRequestBehavior.AllowGet);
        }
        
        //_cdsDataContext
        public JsonResult CheckAttachments(string cdsnumber)
        {
 
            int? count = 0;

            try
            {
               var mylist = _cdDataContext.Database.SqlQuery<Attachments>("select count(ID) as 'Count' from Accounts_Documents where doc_generated='"+cdsnumber+"'").FirstOrDefault();
                count = mylist.Count;
            }
            catch (Exception)
            {

                count = 0;
            }

            if (String.IsNullOrEmpty(count.ToString())==true)
            {
                count = 0;
            }


            return Json(count, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IDCDS(string idno)
        {
            var fundlist = 0;

            var clientsweblist = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.IDNoPP.Replace(" ", "") == idno.Replace(" ", "")).FirstOrDefault();
          
            return Json(clientsweblist.CDS_Number, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckMissingAttachments(string cdsnumber)
        {

            int? count = 0;
            int? count2 = 0;
            int? count3 = 0;
            string missing = "The following documents are needed ";
            try
            {
                var mylist = _cdDataContext.Database.SqlQuery<Attachments>("select isNull(count(ID),0) as 'Count' from Accounts_Documents where doc_generated='" + cdsnumber + "'  and Name='National ID' ").FirstOrDefault();
                count = mylist.Count;

            }
            catch (Exception)
            {

                count = 0;
            }
            try
            {
                var mylist = _cdDataContext.Database.SqlQuery<Attachments>("select isNull(count(ID),0) as 'Count' from Accounts_Documents where doc_generated='" + cdsnumber + "' and Name='Proof Of Residence'  ").FirstOrDefault();
                count2 = mylist.Count;
            }
            catch (Exception)
            {

                count2 = 0;
            }
            try
            {
                var mylist = _cdDataContext.Database.SqlQuery<Attachments>("select isNull(count(ID),0) as 'Count' from Accounts_Documents where doc_generated='" + cdsnumber + "' and Name='Photo'  ").FirstOrDefault();
                count3 = mylist.Count;
            }
            catch (Exception)
            {

                count3 = 0;
            }
            if (count==0)
            {
                missing = missing + " National ID,";
            }
            if (count2 == 0)
            {
                missing = missing + " Proof Of Residence,";
            }
            if (count3 == 0)
            {
                missing = missing + " Photo,";
            }
            return Json(missing, JsonRequestBehavior.AllowGet);
        }

        // 
        public JsonResult OrderUpdate(string OrderNo,string cdsnumber,string OrderType,string Company,string Quantity,string BasePrice,string TimeInForce,string trading_platform,string FOK)
        {
            var message = "1";
            try
            {

                var orderno = Convert.ToInt64(OrderNo);
                var orderLive = _AtsDbContext.Pre_Order_Live.Find(orderno);

                orderLive.OrderType = OrderType;
                orderLive.Company = Company;
                orderLive.CDS_AC_No = cdsnumber;
                orderLive.Quantity = Convert.ToInt32(Quantity);
                orderLive.BasePrice = Convert.ToDouble(BasePrice);
                orderLive.TimeInForce = TimeInForce;
                orderLive.FOK = bool.Parse(FOK);
                orderLive.trading_platform = GetTradingPlaform(Company);

                _AtsDbContext.Pre_Order_Live.AddOrUpdate(orderLive);
                _AtsDbContext.SaveChanges();
            }
            catch (Exception f)
            {
                message = f.Message;
                message = "0";
            }
                return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompaniesandPricesEXCHANGEUpdate(string exchange,string company)
        {
            var companies = new List<CompanyPrices>();
            //load finsec 
            if (exchange.ToLower() == "zse")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["CdDataContext"].ConnectionString;
                var sql = @"SELECT top 1 cast(ut.id as nvarchar) as 'Id' ,qt.fnam + '(' + ut.Ticker + ') - $' + cast(ut.Current_price as nvarchar) as 'WebCompanyName', ut.Ticker + ',' + cast(ut.Current_price as nvarchar) as 'WebCompanyValue'
                        FROM[CDS_ROUTER].[dbo].[ZSE_market_data] ut , testcds_ROUTER.dbo.para_company qt
                        WHERE ut.Ticker = '"+ company +"'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CompanyPrices recordSummary = new CompanyPrices();
                        recordSummary.Id = rdr["Id"].ToString();
                        recordSummary.WebCompanyName = rdr["WebCompanyName"].ToString();
                        recordSummary.WebCompanyValue = rdr["WebCompanyValue"].ToString();
                        companies.Add(recordSummary);
                    }
                }

            }
            else if (exchange.ToLower() == "finsec")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["AtsDbContext"].ConnectionString;
                var sql = @" SELECT top 1 cast(1 as nvarchar) as 'Id' ,b.fnam + '(' + b.company + ') - $' + cast(Lastmatched as nvarchar) as 'WebCompanyName', b.company + ',' + cast(Lastmatched as nvarchar) as 'WebCompanyValue' FROM [testcds_ROUTER].[dbo].[MarketWatch] a, testcds_ROUTER.dbo.para_company b WHERE a.company = '" + company + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CompanyPrices recordSummary = new CompanyPrices();
                        recordSummary.Id = rdr["Id"].ToString();
                        recordSummary.WebCompanyName = rdr["WebCompanyName"].ToString();
                        recordSummary.WebCompanyValue = rdr["WebCompanyValue"].ToString();
                        companies.Add(recordSummary);
                    }
                }
            }

            return Json(companies, JsonRequestBehavior.AllowGet);
        }
        //
        private string SendSms(string messages,string mobile)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (object se, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslerror) => true;

            const string accountSid = "ACb039356b48f7e1357e744ff67d7db32f";
            const string authToken = "0857661b8093d1eb0e513eac12b92724";
            var mess = "";
            TwilioClient.Init(accountSid, authToken);
            try
            {
                var message = MessageResource.Create(
                    body: messages,
                    from: new Twilio.Types.PhoneNumber("CTrade"),
                    to: new Twilio.Types.PhoneNumber(mobile)
                );

                Console.WriteLine(message.Sid);
            }
            catch (ApiException e)
            {
                mess = e.Message;
                mess=mess+$"Twilio Error {e.Code} - {e.MoreInfo}";
            }

       


            return mess;
        }
        public JsonResult SendSmss(string messages, string mobile)
        {
            // Find your Account Sid and Token at twilio.com/console
            // DANGER! This is insecure. See http://twil.io/secure
           // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            const string accountSid = "ACb039356b48f7e1357e744ff67d7db32f";
            const string authToken = "0857661b8093d1eb0e513eac12b92724";
            var mess = "";
            TwilioClient.Init(accountSid, authToken);
            try
            {
                var message = MessageResource.Create(
                    body: messages,
                    from: new Twilio.Types.PhoneNumber("CTrade"),
                    to: new Twilio.Types.PhoneNumber(mobile)
                );

                Console.WriteLine(message.Sid);
            }
            catch (ApiException e)
            {
                mess = e.Message;
                mess = mess + $"Twilio Error {e.Code} - {e.MoreInfo}";
            }




            return Json(mess, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AcceptClub(Boolean state, string club_id, string phone)
        {
            var sql = "update club_members set rejected='" + state + "', confirmed='1' where member_phone = '" + phone + "' and club_id = '" + club_id + "' and [member_phone]='" + phone + "'";
            var updt = _cdscDbContext.Database.ExecuteSqlCommand(sql);
            return Json(updt, JsonRequestBehavior.AllowGet);
        }

        public string WidthdrawToClub(string cdsnumber, string groupcdsnumber, string ammount)
        {
            var tempDbContext = new cdscDbContext();
            try
            {
                //check locked status


                var moneyAvail =
                tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsnumber && x.TransStatus.Trim() == "1");

                if (moneyAvail != null)
                {

                    var theCashBal =
                    tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsnumber && x.TransStatus.Trim() == "1")
                    .Select(x => x.Amount)
                    .Sum();
                    if (theCashBal <= 10 || theCashBal < (Decimal.Parse(ammount)))
                    {
                        return "You have insufficient balance in your Cash account";
                    }
                }
                else
                {
                    return "You have insufficient balance in your Cash account";
                }

                //Selecting distinct
                var orderCashTrans = new CashTrans
                {
                    Description = "Withdrawal",
                    TransType = "Withdraw",
                    TransStatus = "1",
                    Amount = -(Decimal.Parse(ammount)),
                    CDS_Number = cdsnumber,
                    DateCreated = DateTime.Now
                };
                tempDbContext.CashTrans.Add(orderCashTrans);
                tempDbContext.SaveChanges();

                var orderCashTransClub = new CashTrans
                {
                    Description = "Deposit",
                    TransType = "Deposit",
                    TransStatus = "1",
                    Amount = (Decimal.Parse(ammount)),
                    CDS_Number = groupcdsnumber,
                    DateCreated = DateTime.Now
                };
                tempDbContext.CashTrans.Add(orderCashTransClub);
                tempDbContext.SaveChanges();

                var orderCashGroupRecordTrans = new CashTransGroup
                {
                    Description = "Deposit",
                    TransType = "Deposit",
                    TransStatus = "1",
                    Amount = (Decimal.Parse(ammount)),
                    CDS_Number = cdsnumber,
                    CDS_NumberGroup = groupcdsnumber,
                    DateCreated = DateTime.Now
                };
                tempDbContext.CashTransGroup.Add(orderCashGroupRecordTrans);
                tempDbContext.SaveChanges();



                return "Deposit Successfull";
            }
            catch (Exception ex)
            {
                return "Failed to make withdrawal" + ex;
            }
            //return Json(companies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CtradeLimits()
        {
            var limits = _cdDataContext.CTRADELIMITS.ToList();
            return Json(limits, JsonRequestBehavior.AllowGet);
        }
        //cdc mast
        public JsonResult cdcmast(string cdsnumber)
        {
            var scs = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.CDS_Number.ToLower().Replace(" ", "") == cdsnumber.ToLower().Replace(" ", "")).FirstOrDefault();

            var mastlist = _cdDataContext.Database.SqlQuery<CDCMast>("select Company,shares, FORMAT (Updated_On, 'dd/MM/yyyy hh:mm:ss') as UpdatedOn  from CDC_Balances where CDS_Number='" + scs.CDC_Number +"'");
            return Json(mastlist, JsonRequestBehavior.AllowGet);
        }

        //cdcportfolio
        public JsonResult Equiry(string cdsnumber)
        {
            var mess = "Enquiry has been saved.";
            try
            {
                Enquiry enquiry = new Enquiry();
                enquiry.Request = cdsnumber;
                enquiry.RequestDate = DateTime.Now;
                enquiry.Sent =false;
                _cdscDbContext.Enquiries.Add(enquiry);
                _cdscDbContext.SaveChanges();
            }
            catch (Exception f)
            {

                mess = f.ToString();
            }
            return Json(mess, JsonRequestBehavior.AllowGet);
        }

        public JsonResult testbal(string cdsnumber,string company)
        {
            decimal? theCashBal = 0;
            var chk_cdc = _cdDataContext.Accounts_Clients_Web.ToList().Where(a => a.CDS_Number == cdsnumber).FirstOrDefault();
            //.SqlQuery<Balancess>("SELECT amt  FROM New_Balz  where cds_number = '" + cdsnumber + "'").FirstOrDefault();
            var mybal = _cdDataContext.Database.SqlQuery<Balancess>("SELECT sum(Shares) as amt  FROM [CDS_ROUTER].[dbo].[CDC_Balances] where Cds_number='" + chk_cdc.CDC_Number + "' and Company='" + company + "'").FirstOrDefault();
            theCashBal = mybal.amt;
            return Json(theCashBal, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Certificates(string cdsnumber)
        {
          
            //SELECT top 100 Cert as [Certficate No], Company, Shares from [Mast] WHERE COMPANY = 'OMZIL' and shareholder> 0 and shares> 0 and shareholder = ''
            var chk_cert = cERT.Database.SqlQuery<Certificates>("SELECT top 100 cast(Cert as nvarchar) as 'CertificateNo', Company, Shares from [Mast] WHERE COMPANY = 'OMZIL' and shareholder> 0 and shares> 0 and replace(cast(cast(shareholder as decimal) as nvarchar),'-','')=cast('" + cdsnumber + "' as nvarchar)");
            return Json(chk_cert, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FinsecSharess(string cdsnumber)
        {

            //SELECT top 100 Cert as [Certficate No], Company, Shares from [Mast] WHERE COMPANY = 'OMZIL' and shareholder> 0 and shares> 0 and shareholder = ''
           // SELECT[Company] as Company ,[CDS_Number] as CdsNumber, isNull(sum(Shares),0) as 'Shares'  FROM[CDS].[dbo].[trans] where CDS_Number LIKE '%2733192105%' group by company,cds_number
var chk_cert = cDSFINSEC.Database.SqlQuery<FinsecShares>("SELECT [Company] as Company ,[CDS_Number] as CdsNumber, isNull(sum(Shares),0) as 'Shares'  FROM [CDS].[dbo].[trans] where CDS_Number LIKE '%" + cdsnumber+ "%' group by company,cds_number");
            return Json(chk_cert, JsonRequestBehavior.AllowGet);
        }

        public decimal? FinsecSharessBal(string cdsnumber,string company)
        {

            //SELECT top 100 Cert as [Certficate No], Company, Shares from [Mast] WHERE COMPANY = 'OMZIL' and shareholder> 0 and shares> 0 and shareholder = ''
            // SELECT[Company] as Company ,[CDS_Number] as CdsNumber, isNull(sum(Shares),0) as 'Shares'  FROM[CDS].[dbo].[trans] where CDS_Number LIKE '%2733192105%' group by company,cds_number
            var chk_cert = cDSFINSEC.Database.SqlQuery<FinsecShares>("SELECT [Company] as Company ,[CDS_Number] as CdsNumber, isNull(sum(Shares),0) as 'Shares'  FROM [CDS].[dbo].[trans] where CDS_Number LIKE '%" + cdsnumber + "%' and company='"+company+"' group by company,cds_number").FirstOrDefault();
            return chk_cert.Shares;
        }

        //   var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='"+ cdsNumber +"' ").ToList().FirstOrDefault();
        public JsonResult TestCDS(string cdsNumber)
        {
            var cdsDbContext = new CdDataContext();

            var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='"+ cdsNumber +"' ").ToList().FirstOrDefault();
            return Json(chk_cdc, JsonRequestBehavior.AllowGet);
        }


        //paynow
        [HttpGet]
        public async Task<ActionResult> DirectPayOnline(string amount,string cdsnumber,string email)
        {
         
            var companytoken = "";
            var dpo = _cdscDbContext.DPOes.ToList().FirstOrDefault();
            var xmlmessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                    "<API3G>\n" +
                    "<CompanyToken>"+dpo.CompanyToken+"</CompanyToken>\n" +
                    "<Request>createToken</Request>\n" +
                    "<Transaction>\n" +
                    "<PaymentAmount>"+amount+"</PaymentAmount>\n" +
                    "<PaymentCurrency>USD</PaymentCurrency>\n" +
                    "<CompanyRef>CORPSERVE</CompanyRef>\n" +
                    "<RedirectURL>"+dpo.RedirectUrl+"</RedirectURL>\n" +
                    "<BackURL>" + dpo.RedirectUrl + "</BackURL>\n" +
                    "<CompanyRefUnique>0</CompanyRefUnique>\n" +
                    "<PTL>96</PTL>\n" +
                    "</Transaction>\n" +
                    "<Services>\n" +
                    "  <Service>\n" +
                    "    <ServiceType>" + dpo.ServiceTypeProduct + "</ServiceType>\n" +
                    "    <ServiceDescription>DEPOSIT</ServiceDescription>\n" +
                    "    <ServiceDate>"+ DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "</ServiceDate>\n" +
                    "  </Service>\n" +
                    "</Services>\n" +
                    "</API3G>";
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string url = dpo.CreateToken;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            byte[] requestInFormOfBytes = System.Text.Encoding.ASCII.GetBytes(xmlmessage);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = requestInFormOfBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestInFormOfBytes, 0, requestInFormOfBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
           var receivedResponse = respStream.ReadToEnd();
            // WriteErrorLog(receivedresponse1+"\n"+receivedResponse);
            respStream.Close();
            response.Close();


            //response url
            
            //save do payment
            DPOPayment dPOPayment = new DPOPayment();
            XmlReader xReader = XmlReader.Create(new StringReader(receivedResponse));
            string tempName = "";
       
            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        tempName = xReader.Name;
                        break;
                    case XmlNodeType.Text:
                        {
                            if (tempName == "Result")
                            {
                                dPOPayment.Result = xReader.Value;
                            }
                            if (tempName == "ResultExplanation")
                            {
                                dPOPayment.ResultExplanation = xReader.Value;
                            }
                            if (tempName == "TransToken")
                            {
                                dPOPayment.TransToken = xReader.Value;
                            }
                            if (tempName == "TransRef")
                            {
                                dPOPayment.TransRef = xReader.Value;
                            }
                  
                        }
                        break;

                }
            }
            dPOPayment.CDSNumber = cdsnumber;
            dPOPayment.Email = email;
            dPOPayment.Amount = Convert.ToDecimal(amount);
            dPOPayment.TimeStamp = DateTime.Now;
           _cdscDbContext.DPOPayments.Add(dPOPayment);
            _cdscDbContext.SaveChanges();
            string token = dPOPayment.TransToken;

                       string finalurl = dpo.PaymentUrl + token;
            if (string.IsNullOrEmpty(token) == true)
            {
                finalurl = dpo.ErrorUrl;
            }
            return (ActionResult)this.Redirect(finalurl);
        }
        public void verifyToken(string companyToken,string transactionToken,string TransID)
        {
            var dpo = _cdscDbContext.DPOes.ToList().FirstOrDefault();
            var xmlmessage="<?xml version=\"1.0\" encoding=\"utf-8\"?>\n" +
                    "<API3G>\n" +
                    "  <CompanyToken>"+companyToken+"</CompanyToken>\n" +
                    "  <Request>verifyToken</Request>\n" +
                    "  <TransactionToken>"+ transactionToken + "</TransactionToken>\n" +
                    "</API3G>";
            ServicePointManager.ServerCertificateValidationCallback += ValidateRemoteCertificate;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string url = dpo.VerifyToken;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            byte[] requestInFormOfBytes = System.Text.Encoding.ASCII.GetBytes(xmlmessage);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=utf-8";
            request.ContentLength = requestInFormOfBytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(requestInFormOfBytes, 0, requestInFormOfBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader respStream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
            var receivedResponse = respStream.ReadToEnd();
            // WriteErrorLog(receivedresponse1+"\n"+receivedResponse);
            respStream.Close();
            response.Close();


            //decode payment
            DPOPaymentResult dPOPaymentResult = new DPOPaymentResult();
            XmlReader xReader = XmlReader.Create(new StringReader(receivedResponse));
            string tempName = "";

            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:
                        tempName = xReader.Name;
                        break;
                    case XmlNodeType.Text:
                        {
                            if (tempName == "Result")
                            {
                                dPOPaymentResult.Result = xReader.Value;
                            }
                            if (tempName == "ResultExplanation")
                            {
                                dPOPaymentResult.ResultExplanation = xReader.Value;
                            }
                      
                            if (tempName == "CustomerName")
                            {
                                dPOPaymentResult.CustomerName = xReader.Value;
                            }
                            if (tempName == "CustomerCredit")
                            {
                                dPOPaymentResult.CustomerCredit = xReader.Value;
                            }
                            if (tempName == "CustomerCreditType")
                            {
                                dPOPaymentResult.CustomerCreditType = xReader.Value;
                            }
                            if (tempName == "TransactionApproval")
                            {
                                dPOPaymentResult.TransactionApproval = xReader.Value;
                            }
                            if (tempName == "TransactionCurrency")
                            {
                                dPOPaymentResult.TransactionCurrency = xReader.Value;
                            }
                            if (tempName == "TransactionAmount"){
                                dPOPaymentResult.TransactionAmount = xReader.Value;
                            }
                            if (tempName == "FraudAlert")
                            {
                                dPOPaymentResult.FraudAlert = xReader.Value;
                            }
                            if (tempName == "FraudExplnation")
                            {
                                dPOPaymentResult.FraudExplnation = xReader.Value;
                            }

                            //
                            if (tempName == "TransactionNetAmount")
                            {
                                dPOPaymentResult.TransactionNetAmount = xReader.Value;
                            }
                            if (tempName == "TransactionSettlementDate")
                            {
                                dPOPaymentResult.TransactionSettlementDate = xReader.Value;
                            }
                            if (tempName == "TransactionRollingReserveAmount")
                            {
                                dPOPaymentResult.TransactionRollingReserveAmount = xReader.Value;
                            }
                            if (tempName == "TransactionRollingReserveDate")
                            {
                                dPOPaymentResult.TransactionRollingReserveDate = xReader.Value;
                            }
                            if (tempName == "CustomerPhone")
                            {
                                dPOPaymentResult.CustomerPhone = xReader.Value;
                            }

                            //
                            if (tempName == "CustomerCountry")
                            {
                                dPOPaymentResult.CustomerCountry = xReader.Value;
                            }
                            if (tempName == "CustomerAddress")
                            {
                                dPOPaymentResult.CustomerAddress = xReader.Value;
                            }
                            if (tempName == "CustomerCity")
                            {
                                dPOPaymentResult.CustomerCity = xReader.Value;
                            }
                            if (tempName == "CustomerZip") 
                            {
                                dPOPaymentResult.CustomerZip = xReader.Value;
                            }
                             if (tempName == "MobilePaymentRequest")
                            {
                                dPOPaymentResult.MobilePaymentRequest = xReader.Value;
                            }
                            if (tempName == "AccRef")
                            {
                                dPOPaymentResult.AccRef = xReader.Value;
                            }
                            if (tempName == "TransactionFinalCurrency")
                            {
                                dPOPaymentResult.TransactionFinalCurrency = xReader.Value;
                            }
                            if (tempName == "TransactionFinalAmount") 
                            {
                                dPOPaymentResult.TransactionFinalAmount = xReader.Value;
                            }
                        

                        }
                        break;

                }
            }
            dPOPaymentResult.TransactionToken = transactionToken;
            dPOPaymentResult.TimeStamp = DateTime.Now;
            _cdscDbContext.DPOPaymentResults.Add(dPOPaymentResult);
            _cdscDbContext.SaveChanges();

            if (dPOPaymentResult.Result.Replace(" ","")=="000")
            {
                //deposit to cashtransforex
                var dbop = _cdscDbContext.Database.SqlQuery<DPOPayment>("select  top 1 * from [CDSC].[dbo].[DPOPayments]  where TransToken='" + transactionToken + "' and TransID='" + TransID + "' order by Id desc ").FirstOrDefault();
                //
                CashTrans_forex entity = new CashTrans_forex()
                {
                    Description = "DIRECT PAY DEPOSIT",
                    TransType = "DEPOSIT",
                    TransStatus = "1",
                    Amount = dbop.Amount,
                    CDS_Number =dbop.CDSNumber,
                    DateCreated = DateTime.Now,
                    Currency = dPOPaymentResult.TransactionFinalCurrency

                };
                _cdscDbContext.CashTrans_forex.Add(entity);
                _cdscDbContext.SaveChanges();
            }


        }
        [HttpGet]
        public async Task<ActionResult> DirectPayOnlineResultUrl(string TransID,string CCDapproval,string PnrID,string TransactionToken, string CompanyRef)
        {
            /*FormCollection formCollection
            = formCollection["TransID"].ToString();
             = formCollection["CCDapproval"].ToString();
            = formCollection["PnrID"].ToString();
             = formCollection["TransactionToken"].ToString();
            = formCollection["CompanyRef"].ToString();

                */
            var dpo = _cdscDbContext.DPOes.ToList().FirstOrDefault();
            //transaction verification

            var dbop = _cdscDbContext.Database.ExecuteSqlCommand("Update [CDSC].[dbo].[DPOPayments] set PnrID='"+ PnrID +"' ,TransID='" + TransID + "' , CCDapproval='" + CCDapproval + "' , CompanyRef='" + CompanyRef + "' , TransactionToken='" + TransactionToken + "'  where TransToken='" + TransactionToken + "' and isNull(TransID,'0')='0' ");
         


       verifyToken(dpo.CompanyToken, TransactionToken,TransID);


         return (ActionResult)this.Redirect(dpo.SuccessUrl);
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            //Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
            //    cert.Subject,
            //    error.ToString());

            return false;
        }

        public string OrderPostingMakeNewTest(string company, string security, string orderTrans,
          string orderType, string quantity, string price, string cdsNumber,
          string broker, string source, string tif, string date_ = null, string corp_name = null, string corp_id = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";


            var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
            //check for CRT
            var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='" + cdsNumber + "' ").ToList().FirstOrDefault();
            var acc_type = user_acc.AccountType;

            //check if account is locked
            try
            {
                if (user_acc.AccountState.ToLower().Replace(" ", "") == "locked")
                {
                    return "Your account is locked.Please Contact C-Trade Team.";
                }
            }
            catch (Exception)
            {

              
            }

            //check if user is sanctioned
            if (SanctionedExsistsval(user_acc.Forenames + " " + user_acc.Surname) == 1)
            {
                return "Order Posting failed.Please Contact C-Trade Team.";
            }

            if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
            {
                theOrderTrans = "BUY";
            }
            else
            {
                theOrderTrans = "SELL";
            }


            long orderNumber = 0;
            var myCompany = "";
            var myBrokerCode = "";


            var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
            if (theBrokerRef != null)
            {
                orderNumber = theBrokerRef.OrderNo + 1;
            }
            else
            {
                orderNumber = 1;
            }

            var theCompnay =
                atsDbContext.para_company.OrderByDescending(x => x.ID)
                    .Where(x => x.Company == company)
                    .FirstOrDefault(x => x.Company == company);

            if (theCompnay == null)
            {
                return "Select a valid company";
            }

            //if (int.Parse(quantity) < 50)
            //{
            //    return "Please Enter Quantity Above 50 ";
            //}

            myCompany = theCompnay.Company;
            var theCds = cdsNumber + "";

            //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

            if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
            {
                return "Enter CDS Number";
            }


            var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
            if (theBroker1 == null)
            {
                return "Enter valid broker";
            }


            //decimal shares = 0;

            //if (acc_type == "i")
            //{
            if (orderTrans.ToString().ToUpper().Equals("SELL"))
            {

                var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number='" + cdsNumber + "' and Company = '" + myCompany + "' ";
                var shareAvail = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        shareAvail = int.Parse(rdr["Net"].ToString());
                        //break;
                    }
                }
                decimal? finsec = 0;
                try
                {
                    finsec = FinsecSharessBal(cdsNumber, myCompany);
                }
                catch (Exception)
                {

                    finsec = 0;
                }
                //validate cdc
                if (string.IsNullOrEmpty(chk_cdc.CDC_Number) == false)
                {
                    decimal? theCashBal = 0;
                    //.SqlQuery<Balancess>("SELECT amt  FROM New_Balz  where cds_number = '" + cdsnumber + "'").FirstOrDefault();
                    var mybal = _cdsDataContext.Database.SqlQuery<Balancess>("SELECT sum(Shares) as amt  FROM [CDS_ROUTER].[dbo].[CDC_Balances] where Cds_number='" + chk_cdc.CDC_Number + "' and Company='" + myCompany + "'").FirstOrDefault();
                    theCashBal = mybal.amt;
                    if (string.IsNullOrEmpty(theCashBal.ToString()) == true)
                    {
                        theCashBal = 0;
                    }
                    if (theCashBal < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }
                }
                else if (string.IsNullOrEmpty(finsec.ToString()) == false)
                {
                    if (finsec < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }
                    else
                    {
                        shareAvail = Convert.ToInt32(finsec);
                    }
                }
                else
                {
                    if (shareAvail < int.Parse(quantity))
                    {
                        return "You have insufficient units in your account.";
                    }
                }
            }
            //}

            //IF BUY ORDER
            var totalAmountToSpent = decimal.Parse("0.0");
            var theQuantity = 0;
            if (quantity != null)
            {
                theQuantity = int.Parse(quantity);
            }
            if (GetTradingPlaform(myCompany).Equals("ZSE"))
            {
                totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
            }
            else
            {
                totalAmountToSpent = theQuantity * decimal.Parse(price) * decimal.Parse("1.01693");
            }
            if (!acc_type.Equals("c"))
            {
                if (orderTrans.ToString().ToUpper().Equals("BUY"))
                {
                    var moneyAvail =
                        tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                    if (moneyAvail != null)
                    {
                        var theCashBal =
                            tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                .Select(x => x.Amount)
                                .Sum();
                        if (theCashBal <= 0 || theCashBal < totalAmountToSpent)
                        {
                            return "You have insufficient funds in your cash account";
                        }
                    }
                    else
                    {
                        return "You have insufficient funds in your cash account";
                    }
                }
            }
            //SAVING TO DB
            var orderStatus = "OPEN";
            if (acc_type == "c")
            {
                orderStatus = "NOT AUTHORISED";
            }
            var createdDate = DateTime.Now;
            var dealBeginDate = DateTime.Now;
            var expiryDate = DateTime.Now; ;
            if (date_ == null)
            {
                expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                expiryDate = DateTime.Now; ;
            }
            var brokerCode = "";
            var orderAttrib = "";
            var marketBoard = "Normal Board";
            var timeInForce = tif;
            var orderQualifier = "None";
            //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
            var contraBrokerId = "";
            var brokerRef = broker + orderNumber;
            var maxPrice = 0;
            var minPrice = 0;
            var flagOldOrder = false;
            var orderNum = "MOB-" + orderNumber;
            var currency = "$";


            var name = GetCdsNumber(cdsNumber).ToUpper();

            if (company.ToLower().Equals("usd"))
            {
                security = "FOREX";
            }

         
                if (string.IsNullOrEmpty(chk_cdc.CDC_Number) == false)
                {
                    source = "CDC";
                    cdsNumber = chk_cdc.CDC_Number;
                }


                var orderLive = new Pre_Order_Live
                {
                    OrderType = orderTrans.ToUpper(),
                    Company = myCompany,
                    SecurityType = security,
                    CDS_AC_No = cdsNumber,
                    Broker_Code = broker,
                    Client_Type = acc_type,
                    Tax = 0,
                    Shareholder = cdsNumber,
                    ClientName = name,
                    TotalShareHolding = 0,
                    OrderStatus = orderStatus,
                    Create_date = createdDate,
                    Deal_Begin_Date = dealBeginDate,
                    Expiry_Date = expiryDate,
                    Quantity = theQuantity,
                    BasePrice = basePrice,
                    AvailableShares = 0,
                    OrderPref = orderPref,
                    OrderAttribute = orderAttrib,
                    Marketboard = marketBoard,
                    TimeInForce = timeInForce,
                    OrderQualifier = orderQualifier,
                    BrokerRef = brokerRef,
                    ContraBrokerId = contraBrokerId,
                    MaxPrice = maxPrice,
                    MiniPrice = minPrice,
                    Flag_oldorder = flagOldOrder,
                    OrderNumber = orderNum,
                    Currency = currency,
                    trading_platform = GetTradingPlaform(myCompany),
                    Source = source,
                    FOK = false,
                    Affirmation = true,
                    Custodian = chk_cdc.BIC
                };

                //save to cdsc tempPreorderLive too
                CashTrans orderCashTrans = null;

                orderCashTrans = new CashTrans
                {
                    Description = "BUY - Order",
                    TransType = "BUY",
                    TransStatus = "1",
                    Amount = -totalAmountToSpent,
                    CDS_Number = cdsNumber,
                    DateCreated = DateTime.Now
                };

               
                    atsDbContext.Pre_Order_Live.Add(orderLive);
                    atsDbContext.SaveChanges();
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {

                        tempDbContext.CashTrans.Add(orderCashTrans);
                        tempDbContext.SaveChanges();
                    }


                    return "1";
                



        
            }
        public string OrderPostingMakeNewMe(string company, string security, string orderTrans,
           string orderType, string quantity, string price, string cdsNumber,
           string broker, string source, string amountValue ,string tif, string date_ = null, string corp_name = null, string corp_id = null)

        {

            var today = DateTime.Today.ToString("yyyy-MM-dd");
            var ret = "";
            var atsDbContext = new AtsDbContext();
            var cdsDbContext = new CdDataContext();
            var tempDbContext = new cdscDbContext();
            var orderPref = "L";
            Double basePrice = Double.Parse(price, CultureInfo.InvariantCulture); //;
            var theOrderTrans = "";

            try
            {
                var user_acc = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);
                //check for CRT
                var chk_cdc = cdsDbContext.Database.SqlQuery<Accounts_Clients_Web>("SELECT * FROM Accounts_Clients_Web where CDS_Number='" + cdsNumber + "' ").ToList().FirstOrDefault();
                var acc_type = user_acc.AccountType;

                try
                {
                    //check if account is locked
                    if (user_acc.AccountState.ToLower().Replace(" ", "") == "locked")
                    {
                        return "Your account is locked.Please Contact C-Trade Team.";
                    }
                }
                catch (Exception)
                {


                }

                //check if user is sanctioned
                if (SanctionedExsistsval(user_acc.Forenames + " " + user_acc.Surname) == 1)
                {
                    return "Order Posting failed.Please Contact C-Trade Team.";
                }

                if (orderTrans != null && orderTrans.Trim().Equals("Buy"))
                {
                    theOrderTrans = "BUY";
                }
                else
                {
                    theOrderTrans = "SELL";
                }


                long orderNumber = 0;
                var myCompany = "";
                var myBrokerCode = "";


                var theBrokerRef = atsDbContext.Pre_Order_Live.OrderByDescending(x => x.OrderNo).FirstOrDefault();
                if (theBrokerRef != null)
                {
                    orderNumber = theBrokerRef.OrderNo + 1;
                }
                else
                {
                    orderNumber = 1;
                }

                var theCompnay =
                    atsDbContext.para_company.OrderByDescending(x => x.ID)
                        .Where(x => x.Company == company)
                        .FirstOrDefault(x => x.Company == company);

                if (theCompnay == null)
                {
                    return "Select a valid company";
                }

                //if (int.Parse(quantity) < 50)
                //{
                //    return "Please Enter Quantity Above 50 ";
                //}

                myCompany = theCompnay.Company;
                var theCds = cdsNumber + "";

                //                var theBroker = cdsDbContext.Accounts_Clients.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                if (GetCdsNumber(cdsNumber) == "0" || GetCdsNumber(cdsNumber) == "1")
                {
                    return "Enter CDS Number";
                }


                var theBroker1 = cdsDbContext.Client_Companies.FirstOrDefault(x => x.Company_Code == broker);
                if (theBroker1 == null)
                {
                    return "Enter valid broker";
                }


                //decimal shares = 0;

                //if (acc_type == "i")
                //{
                if (orderTrans.ToString().ToUpper().Equals("SELL"))
                {

                    var connectionString = ConfigurationManager.ConnectionStrings["cdscDbContext"].ConnectionString;
                    var sql = "select * from cdsc.dbo.PortfolioAll d where d.CDS_Number=@cdsNumber and Company =@myCompany ";
                    var shareAvail = 0;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@cdsNumber", cdsNumber);
                        cmd.Parameters.AddWithValue("@myCompany", myCompany);
                        connection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            if (security.Trim().ToString() == "UNIT TRUST")
                            {
                                shareAvail = int.Parse(rdr["totAllShares"].ToString());
                            }
                            else
                            {
                                shareAvail = int.Parse(rdr["Net"].ToString());
                            }
                        }
                    }
                    decimal? finsec = 0;
                    try
                    {
                        finsec = FinsecSharessBal(cdsNumber, myCompany);
                    }
                    catch (Exception)
                    {

                        finsec = 0;
                    }
                    if (string.IsNullOrEmpty(shareAvail.ToString()) == true)
                    {
                        shareAvail = 0;
                    }

                    var trading = GetTradingPlaform(myCompany).ToLower();
                    //if (shareAvail < int.Parse(quantity))
                    //{
                    //    return "You have insufficient units in your account.";
                    //}
                    if (string.IsNullOrEmpty(finsec.ToString()) == false && trading == "finsec")
                    {
                        if (finsec < int.Parse(quantity))
                        {
                            return "You have insufficient units in your account. shareAvail" + shareAvail + "int.Parse(quantity) " + int.Parse(quantity);
                        }
                        else
                        {
                            shareAvail = Convert.ToInt32(finsec);
                        }
                    }
                    else
                    {
                        if (shareAvail < int.Parse(quantity))
                        {
                            return int.Parse(quantity) + "You have insufficient units in your account.shareAvail" + shareAvail;
                        }
                    }
                }
                //}

                //IF BUY ORDER
                var totalAmountToSpent = decimal.Parse("0.0");
                var theQuantity = 0;
                if (quantity != null)
                {
                    theQuantity = int.Parse(quantity);
                }
                if (GetTradingPlaform(myCompany).Equals("ZSE"))
                {
                    //totalAmountToSpent = theQuantity * decimal.Parse(price) ;
                }
                else
                {
                    //totalAmountToSpent = theQuantity * decimal.Parse(price);
                }
                if (!acc_type.Equals("c"))
                {
                    if (orderTrans.ToString().ToUpper().Equals("BUY"))
                    {
                        var moneyAvail =
                            tempDbContext.CashTrans.FirstOrDefault(x => x.CDS_Number == cdsNumber);

                        if (moneyAvail != null)
                        {
                            var theCashBal =
                               tempDbContext.CashTrans.Where(x => x.CDS_Number == cdsNumber)
                                    .Select(x => x.Amount)
                                    .Sum();
                            if (theCashBal <= 0 || theCashBal < Decimal.Parse(amountValue))
                            {
                                return "You have insufficient funds in your cash account theCashBal" + theCashBal + " totalAmountToSpent:" + totalAmountToSpent;
                            }
                        }
                        else
                        {
                            return "You have insufficient funds in your cash account moneyAvail" + moneyAvail;
                        }
                    }
                }
                //SAVING TO DB
                var orderStatus = "OPEN";
                if (acc_type == "c")
                {
                    orderStatus = "NOT AUTHORISED";
                }
                var createdDate = DateTime.Now;
                var dealBeginDate = DateTime.Now;
                var expiryDate = DateTime.Now; ;
                if (date_ == null)
                {
                    expiryDate = DateTime.ParseExact(date_, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    expiryDate = DateTime.Now; ;
                }
                var brokerCode = "";
                var orderAttrib = "";
                var marketBoard = "Normal Board";
                var timeInForce = tif;
                var orderQualifier = "None";
                //var brokerRef = theBroker1.Company_Code + "" + orderNumber;
                var contraBrokerId = "";
                var brokerRef = broker + orderNumber;
                var maxPrice = 0;
                var minPrice = 0;
                var flagOldOrder = false;
                var orderNum = "MOB-" + orderNumber;
                var currency = "$";


                var name = GetCdsNumber(cdsNumber).ToUpper();

                if (company.ToLower().Equals("usd"))
                {
                    security = "FOREX";
                }

                try
                {
                    if (string.IsNullOrEmpty(chk_cdc.CDC_Number) == false)
                    {
                        source = "CDC";
                        cdsNumber = chk_cdc.CDC_Number;
                    }


                    var orderLive = new Pre_Order_Live
                    {
                        OrderType = orderTrans.ToUpper(),
                        Company = myCompany,
                        SecurityType = security,
                        CDS_AC_No = cdsNumber,
                        Broker_Code = broker,
                        Client_Type = acc_type,
                        Tax = 0,
                        Shareholder = cdsNumber,
                        ClientName = name,
                        TotalShareHolding = 0,
                        OrderStatus = orderStatus,
                        Create_date = createdDate,
                        Deal_Begin_Date = dealBeginDate,
                        Expiry_Date = expiryDate,
                        Quantity = theQuantity,
                        BasePrice = basePrice,
                        AvailableShares = 0,
                        OrderPref = orderPref,
                        OrderAttribute = orderAttrib,
                        Marketboard = marketBoard,
                        TimeInForce = timeInForce,
                        OrderQualifier = orderQualifier,
                        BrokerRef = brokerRef,
                        ContraBrokerId = contraBrokerId,
                        MaxPrice = maxPrice,
                        MiniPrice = minPrice,
                        Flag_oldorder = flagOldOrder,
                        OrderNumber = orderNum,
                        Currency = currency,
                        trading_platform = GetTradingPlaform(myCompany),
                        Source = source,
                        FOK = false,
                        AmountValue = Decimal.Parse(amountValue),
                        Affirmation = true,
                        Custodian = chk_cdc.BIC
                    };

                    //save to cdsc tempPreorderLive too
                    CashTrans orderCashTrans = null;

                    orderCashTrans = new CashTrans
                    {
                        Description = "BUY - Order",
                        TransType = "BUY",
                        TransStatus = "1",
                        Amount = -Decimal.Parse(amountValue),
                        CDS_Number = cdsNumber,
                        DateCreated = DateTime.Now
                    };

                    try
                    {

                        atsDbContext.Pre_Order_Live.Add(orderLive);
                        atsDbContext.SaveChanges();
                        if (orderTrans.ToString().ToUpper().Equals("BUY"))
                        {

                            tempDbContext.CashTrans.Add(orderCashTrans);
                            tempDbContext.SaveChanges();
                        }


                        return "1";
                    }
                    catch (Exception e)
                    {
                        return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                    }
                }
                catch (Exception e)
                {
                    return e.Message + " \n " + e.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
                }

            }
            catch (Exception ex)
            {
                return ex.Message + " \n " + ex.StackTrace; //"Error occured please contact support at ctrade@escrowgroup.org";
            }
        }


    }
}
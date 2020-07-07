using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CDSC
{
    public partial class Responder1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Page.Response.ContentType = "text/xml";
                System.IO.StreamReader reader = new System.IO.StreamReader(Page.Request.InputStream);
                String xmlData = reader.ReadToEnd();
                System.IO.StreamWriter SW = default(System.IO.StreamWriter);
                SW = File.CreateText(Server.MapPath("api\\xmlRec" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"));
                SW.WriteLine(xmlData);
                SW.Close();

                //get transactionstatus
            }
            catch (System.Net.WebException exp)
            {

                System.IO.StreamWriter SW = default(System.IO.StreamWriter);
                SW = File.CreateText(Server.MapPath("api\\xmlRec" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt"));
                SW.WriteLine(exp.ToString());
                SW.Close();
            }


        }
    }
}
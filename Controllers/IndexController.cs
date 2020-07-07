using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public JsonResult Login(string identification = null, string password = null)
        {
            return Json("0", JsonRequestBehavior.AllowGet);
        }
    }
}
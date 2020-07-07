using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class MarketNewsController : Controller
    {
        // GET: MarketNews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();            
        }
    }
}
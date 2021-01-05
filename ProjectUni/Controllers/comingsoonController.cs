using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Controllers
{
    public class comingsoonController : Controller
    {
        // GET: comingsoon
        public ActionResult Index()
        {
            return PartialView("index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Google.Apis.Customsearch.v1;
using Google.Apis.SearchConsole.v1;
using Google.Apis.SearchConsole.v1.Data;

namespace website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }

    }
}

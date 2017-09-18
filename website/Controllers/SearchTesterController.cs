using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models;

namespace website.Controllers
{
    public class SearchTesterController : Controller
    {

        private string apiKey = "AIzaSyCLpUa94jUS9-czHU9qkMDk3lQK_kVFMHM";
        private string cx = "004744263108198661492:6-zxls05zgg";

        public string firtsite = "";

		public ActionResult Results()
		{
            return View(new ResultModel());
		}

        [HttpGet]
        public ActionResult Test(string website, string keywords)
		{
			string query = keywords;

			var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer { ApiKey = apiKey });
			var listRequest = svc.Cse.List(query);

			listRequest.Cx = cx;
			listRequest.Num = 10;
			var search = listRequest.Execute();

            //firstsite = search.Items[0].FormattedUrl;

            return RedirectToAction("Results");
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using website.Models;

namespace website.Controllers
{
    public class TestController : Controller
    {

        private string apiKey = "AIzaSyCLpUa94jUS9-czHU9qkMDk3lQK_kVFMHM";
        private string cx = "004744263108198661492:6-zxls05zgg";

		public ActionResult Test()
		{
            return View(new Test());
		}

        [HttpPost]
        public ActionResult Search(string website, string keywords)
		{
            Test test = new Test();

            test.Keywords = keywords;
            test.WebSite = website;
            test.Position = -1;

			var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer { ApiKey = apiKey });
			var listRequest = svc.Cse.List(keywords);

			listRequest.Cx = cx;
            listRequest.Googlehost = "google.ch";
            listRequest.Hl = "fr";
			listRequest.Num = 10;
			var search = listRequest.Execute();
			
            test.FirstSite = search.Items[0].DisplayLink;
            test.TotalResults = search.SearchInformation.FormattedTotalResults;
            bool isFound = false;
            //int paging = 1;
            test.Sites = new string[10];
            test.Urls = new string[10];
            test.Titles = new string[10];
            while (!isFound)
            {
                for (int i = 0; i < 10; i++)
                {
                    test.Sites[i] = search.Items[i].DisplayLink;
                    test.Urls[i] = "http://" + search.Items[i].FormattedUrl;
                    test.Titles[i] = search.Items[i].Title;
                    if (search.Items[i].FormattedUrl.Contains(test.WebSite))
                    {

                        test.Position = i + 1;
                        isFound = true;
                    }
                }
                //if (paging == 10)
                    break;
                //paging++;
                //listRequest.Start = (paging-1) * 10;
                //search = listRequest.Execute();
            }

            return View("Search",test);
		}
    }
}

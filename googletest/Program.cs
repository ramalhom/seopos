using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Customsearch.v1;
using Google.Apis.SearchConsole.v1;
using Google.Apis.SearchConsole.v1.Data;


namespace googletest
{
    class MainClass
    {
		
        public static void Main(string[] args)
        {
			string apiKey = "AIzaSyCLpUa94jUS9-czHU9qkMDk3lQK_kVFMHM";
			string cx = "004744263108198661492:6-zxls05zgg";
			string query = "informatique fribourg";

			var svc = new Google.Apis.Customsearch.v1.CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer { ApiKey = apiKey });
            var listRequest1 = svc.Cse.List(query);
            var listRequest2 = svc.Cse.List(query);

			listRequest1.Cx = cx;
            listRequest1.Num = 10;
            listRequest1.Start = 1;
            var search1 = listRequest1.Execute();
			listRequest2.Cx = cx;
			listRequest2.Num = 10;
            listRequest2.Start = 11;
            var search2 = listRequest2.Execute();
            Console.WriteLine("Title: {0}", search1.Items[0].Title);
			Console.WriteLine("Title: {0}", search2.Items[0].Title);
            /*for (int i = 1; i <= 10; i++)
			{
                var result = search1.Items[i-1];
                //Console.WriteLine("Position: {0}", i);
                Console.WriteLine("Title: {0}", result.Title);
				Console.WriteLine("Link: {0}", result.Link);

			}
            Console.WriteLine("Total Results: {0}",search1.SearchInformation.TotalResults);

			for (int i = 11; i <= 20; i++)
			{
				var result = search1.Items[i - 11];
				Console.WriteLine("Position: {0}", i);
                Console.WriteLine("Title: {0}", result.Title);
				Console.WriteLine("Link: {0}", result.Link);
			}
            Console.WriteLine("Total Results: {0}", search2.SearchInformation.TotalResults);
            */

			
        }
    }
}

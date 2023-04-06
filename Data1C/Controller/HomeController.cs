using Microsoft.AspNetCore.Mvc;
using Data1C.Model;
using Newtonsoft.Json;

namespace Data1C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCharts()
        {
            return RedirectToAction("Charts", "Chart");
        }

        public ContentResult JSON()
        {
            BookDataAccessLayer BookAccess = new BookDataAccessLayer();
            List<Book> BooksToDataPoints = BookAccess.GetAllBooks().ToList();
            List<DataPoint> dataPoints = new List<DataPoint>();

            int Count = 0;
            int ListCount = BooksToDataPoints.Count - 1;

            for (int i = 0; i < ListCount; i++)
            {
                if (BooksToDataPoints[i].DateOfCreation.ToString("D") == BooksToDataPoints[i + 1].DateOfCreation.ToString("D"))
                {
                    Count++;
                    dataPoints.Add(new DataPoint(Count, BooksToDataPoints[i].DateOfLastChanges));
                }
                else
                {
                    Count = 1;
                    dataPoints.Add(new DataPoint(Count, BooksToDataPoints[i].DateOfLastChanges));
                }
            }

            JsonSerializerSettings _jsonSettings = new JsonSerializerSettings()
            { NullValueHandling = NullValueHandling.Ignore };

            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSettings), "home/json");
        }


        public ActionResult LibraryData()
        {
            return RedirectToAction("Index", "Books");
        }
        
        public ActionResult Get1C()
        {
            ConnectTo1C conn = new ConnectTo1C();
            JsonParser parser = new JsonParser();
            DBUtils db = new DBUtils();

            string url = $"http://10.0.0.2/LIBRARY/odata/standard.odata/Catalog_БиблЗаписи?$format=json";

            db.AddData(db.DBname, parser.ParseDataFrom1C(parser.client, url));

			return RedirectToAction("Index", "Books");
		}
    }
}

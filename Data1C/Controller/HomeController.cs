using Microsoft.AspNetCore.Mvc;
using Data1C.Model;
using Org.BouncyCastle.Asn1.Mozilla;
using Newtonsoft.Json;
using System.Runtime;

namespace Data1C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //TEST TEST TEST
			BookDataAccessLayer BookAccess = new BookDataAccessLayer();
			List<Book> BooksToDataPoints = BookAccess.GetAllBooks().ToList();
			List<DataPoint> dataPoints = new List<DataPoint>();

            Random rand = new Random();

			for (int i = 0; i < 500; i++)
			{
                //dataPoints.Add(new DataPoint((double)i, BooksToDataPoints[i].DateOfCreation));

                dataPoints.Add(new DataPoint(i, rand.Next(0, 10000)));

			}

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
			//TEST TEST TEST




			return View();
        }

        public ActionResult LibraryData()
        {
            return RedirectToAction("Index", "Books");
        }

        public ActionResult GetCharts()
        {



            return RedirectToAction("index", "home");
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

        [HttpGet]
        public void MainMenu_Click(object sender, EventArgs e)
        {

        }


    }
}

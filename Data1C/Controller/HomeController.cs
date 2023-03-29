using Microsoft.AspNetCore.Mvc;
using Data1C.Model;


namespace Data1C.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

            return View("Index");  
        }

        [HttpGet]
        public void MainMenu_Click(object sender, EventArgs e)
        {



        }


    }
}

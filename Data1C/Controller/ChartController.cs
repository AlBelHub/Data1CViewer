using Data1C.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Data1C.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View("Charts");
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

            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSettings), "chart/json");
        }

    }
}

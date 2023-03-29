using Data1C.Model;
using Microsoft.AspNetCore.Mvc;

namespace Data1C.Controllers
{
    public class BooksController : Controller
    {

        BookDataAccessLayer BookDataAccessLayer;

        public BooksController()
        {
            BookDataAccessLayer = new BookDataAccessLayer();
        }

        // GET: BooksController
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Book> books = BookDataAccessLayer.GetAllBooks(10);
            List<Book> result = new List<Book>();
            result.AddRange(books);

            return View("books",result);
        }

        //[HttpPost]
        //public ActionResult Index(List<Book> books,int DBlimit)
        //{

        //    if (DBlimit == 0)
        //    {

        //        return View("books", books);
        //    }
        //    else if (DBlimit == 10)
        //    {
                
        //    }
        //    else
        //    {
        //    }

        //    return View("books", books);
        //}

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                BookDataAccessLayer.AddBook(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

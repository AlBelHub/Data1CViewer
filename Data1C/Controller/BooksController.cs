using Data1C.Model;
using Microsoft.AspNetCore.Mvc;

namespace Data1C.Controllers
{
    public class BooksController : Controller
    {

        static BookDataAccessLayer? BookDataAccessLayer;
        static IEnumerable<Book>? books;
        List<Book> BooksList;

        public BooksController()
        {
            BookDataAccessLayer = new BookDataAccessLayer();
            BooksList = new List<Book>();
            books = BookDataAccessLayer.GetAllBooks();
        }

        // GET: BooksController
        [HttpGet]
        public ActionResult Index(int limit, string search)
        {
            if (BooksList.Count == 0)
            {
                BooksList.AddRange(books!);
            }

            var SearchedBooks = from m in BooksList 
                                select m;

            if (!String.IsNullOrEmpty(search))
            {
                SearchedBooks = SearchedBooks.Where(m => m.BookDescription!.Contains(search));
            }

            return View("books", BookDataAccessLayer!.GetRange(SearchedBooks, limit));
        }

        //[HttpPost]
        //public ActionResult Index(int DBlimit)
        //{
        //    return View("POST");
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
                BookDataAccessLayer!.CreateBook(book);

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

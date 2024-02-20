using HaniasBookstore.Models;
using HaniasBookstore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBook _book;
        private readonly IGenre _genre;

        public BookController (IBook book, IGenre genre)
        {
            _book = book;
            _genre = genre;
        }

        public IActionResult List()
        {
            //ViewBag.Title = "Available Books";
            //return View(_book.AllBooks);

            BookListViewModel bookListViewModel = new BookListViewModel(_book.AllBooks, "Fantasy");
            return View(bookListViewModel);
        }

        public IActionResult Details(int id)
        {
            var book = _book.GetBookById(id);

            if (book == null)
                return NotFound();
            return View(book);
        }
    }
}

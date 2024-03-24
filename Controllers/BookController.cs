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

        //public IActionResult List()
        //{
        //    //ViewBag.Title = "Available Books";
        //    //return View(_book.AllBooks);

        //    BookListViewModel bookListViewModel = new BookListViewModel(_book.AllBooks, "All Books");
        //    return View(bookListViewModel);
        //}

        public ViewResult List(string genre)
        {
            IEnumerable<Book> books;
            string? currentGenre;

            if (string.IsNullOrEmpty(genre))
            {
                books = _book.AllBooks.OrderBy(b => b.Id);
                currentGenre = genre;
            }
            else
            {
                books = _book.AllBooks.Where(b => b.Genre.Name == genre).OrderBy(b => b.Id);
                currentGenre = _genre.AllGenres.FirstOrDefault(g => g.Name == genre)?.Name;
            }

            return View(new BookListViewModel(books,currentGenre));
        }

        public IActionResult Details(int id)
        {
            var book = _book.GetBookById(id);

            if (book == null)
                return NotFound();
            return View(book);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}

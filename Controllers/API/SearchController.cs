using HaniasBookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IBook book;

        public SearchController(IBook book) 
        {
            this.book = book;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allBooks = book.AllBooks;
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!book.AllBooks.Any(b => b.Id == id))
                return NotFound();

            return Ok(book.AllBooks.Where(b => b.Id == id));
        }

        [HttpPost]
        public IActionResult SearchBooks([FromBody]string searchQuery)
        {
            IEnumerable<Book> books = new List<Book>();

            if (!string.IsNullOrEmpty(searchQuery))
                books = book.SearchBooks(searchQuery);

            return new JsonResult(books);
        }
    }
}

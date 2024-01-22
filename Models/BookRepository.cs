
using Microsoft.EntityFrameworkCore;

namespace HaniasBookstore.Models
{
    public class BookRepository : IBook
    {
        private readonly HaniasBookstoreDbContext _haniasBookstoreDbContext;

        public BookRepository(HaniasBookstoreDbContext haniasBookstoreDbContext)
        {
            _haniasBookstoreDbContext = haniasBookstoreDbContext;
        }

        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _haniasBookstoreDbContext.Books.Include(g => g.Genre);
            }
        }

        public IEnumerable<Book> Bestsellers
        {
            get
            {
                return _haniasBookstoreDbContext.Books.Include(g => g.Genre).Where(b => b.IsBestseller);
            }
        }

        public Book? GetBookById(int id)
        {
            return _haniasBookstoreDbContext.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}

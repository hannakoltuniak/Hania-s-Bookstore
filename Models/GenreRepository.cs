using HaniasBookstore.Models;

namespace Hania_s_Bookstore.Models
{
    public class GenreRepository : IGenre
    {
        private readonly HaniasBookstoreDbContext _haniasBookstoreDbContext;

        public GenreRepository(HaniasBookstoreDbContext haniasBookstoreDbContext)
        {
            _haniasBookstoreDbContext = haniasBookstoreDbContext;
        }

        public IEnumerable<Genre> AllGenres => _haniasBookstoreDbContext.Genres.OrderBy(b => b.Name);
    }
}

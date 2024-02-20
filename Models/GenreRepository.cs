using HaniasBookstore.Models;

namespace HaniasBookstore.Models
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

using HaniasBookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Components
{
    public class GenreMenu : ViewComponent
    {
        private readonly IGenre genre;

        public GenreMenu(IGenre genre)
        {
            this.genre = genre;
        }

        public IViewComponentResult Invoke()
        {
            var genres = genre.AllGenres.OrderBy(x => x.Name);
            return View(genres);
        }
    }
}

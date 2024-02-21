using HaniasBookstore.Models;
using HaniasBookstore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBook _book;

        public HomeController (IBook book)
        {
            _book = book;
        }

        public IActionResult Index()
        {
            var bestsellers = _book.Bestsellers;
            var homeViewModel = new HomeViewModel(bestsellers);
            return View(homeViewModel);
        }
    }
}

using HaniasBookstore.Models;

namespace HaniasBookstore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Book> Bestsellers { get; }

        public HomeViewModel (IEnumerable<Book> bestsellers)
        {
            Bestsellers = bestsellers;
        }
    }
}

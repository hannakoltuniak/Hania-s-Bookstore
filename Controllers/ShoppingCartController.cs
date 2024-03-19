using HaniasBookstore.Models;
using HaniasBookstore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBook book;
        private readonly IShoppingCart cart;

        public ShoppingCartController(IBook book, IShoppingCart cart)
        {
            this.book = book;
            this.cart = cart;
        }

        public ViewResult Index()
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(cart, cart.GetTotalPrice());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int bookId)
        {
            var selectedBook = book.AllBooks.FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null) 
                cart.AddToCart(selectedBook);

            return RedirectToAction("Index");
        }


        public RedirectToActionResult RemoveFromShoppingCart(int bookId)
        {
            var selectedBook = book.AllBooks.FirstOrDefault(b => b.Id == bookId);

            if (selectedBook != null)
                cart.RemoveFromCart(selectedBook);

            return RedirectToAction("Index");
        }
    }
}

using HaniasBookstore.Models;
using HaniasBookstore.ViewModels;
using Microsoft.AspNetCore.Mvc; 

namespace HaniasBookstore.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(shoppingCart, shoppingCart.GetTotalPrice());

            return View(shoppingCartViewModel);
        }
    }
}

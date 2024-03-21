using HaniasBookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HaniasBookstore.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrder order;
        private readonly IShoppingCart cart;

        public Order Order { get; set; }

        public CheckoutPageModel(IOrder order, IShoppingCart cart)
        {
            this.order = order;
            this.cart = cart;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
                return Page();

            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            if (cart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Your car is empty, add some books first");

            if (ModelState.IsValid)
            {
                order.CreateOrder(Order);
                cart.ClearCart();

                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();
        }
    }
}

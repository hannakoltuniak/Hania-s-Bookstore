using HaniasBookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrder order;
        private readonly IShoppingCart cart;

        public OrderController(IOrder order, IShoppingCart cart)
        {
            this.order = order;
            this.cart = cart;
        }

        public IActionResult Checkout() //GET
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = items;

            if (cart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Your cart is empty, add some books first");

            if (ModelState.IsValid)
            {
                this.order.CreateOrder(order);
                cart.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for your order! You'll soon read amazing stories!";
            return View();
        }
    }
}

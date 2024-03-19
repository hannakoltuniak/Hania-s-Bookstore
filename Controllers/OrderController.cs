using HaniasBookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder order;
        private readonly IShoppingCart cart;

        public OrderController(IOrder order, IShoppingCart cart)
        {
            this.order = order;
            this.cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HaniasBookstore.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

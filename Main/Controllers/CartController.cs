using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult ShowCartItems()
        {
            return View();
        }
    }
}

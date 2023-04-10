using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class CartController : Controller
    {
        [HttpGet]
        [Authorize] ////ToDo : view for not login
        public IActionResult ShowCartItems(int productId)
        {

            return View();
        }
    }
}

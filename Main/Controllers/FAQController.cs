using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult FAQView()
        {
            return View();
        }


    }
}

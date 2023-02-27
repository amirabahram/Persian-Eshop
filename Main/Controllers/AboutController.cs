using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class AboutController : Controller
    {
        //connect services 
        private IAboutUsServices _about;
        public AboutController(IAboutUsServices aboutUs)
        {
            _about = aboutUs;
        }

        public IActionResult CreateAboutUs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAboutUs(CreateAboutUsViewModel aboutus, IFormFile img)
        {

            return View(aboutus);

        }
        public IActionResult EditAboutUs()
        {
            return View();
        }


    }
}

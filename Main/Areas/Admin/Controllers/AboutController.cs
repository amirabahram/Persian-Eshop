using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {

        //connect services 
        private IAboutUsServices _about;
        public AboutController(IAboutUsServices aboutUs)
        {
            _about = aboutUs;
        }
        [HttpGet("create")]
        public IActionResult CreateAboutUs()
        
        {
            return View();
        }
        [HttpPost("create")]

        public IActionResult CreateAboutUs(CreateAboutUsViewModel aboutus, IFormFile img)
        {
            if(ModelState.IsValid)
            {

                _about.AddAboutUs(aboutus, img);
            }


            return View(aboutus);

        }
        public IActionResult EditAboutUs(int id )
        {
        
            
            
            return View();
        }


    }
}

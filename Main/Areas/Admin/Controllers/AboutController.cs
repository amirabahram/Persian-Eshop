using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Mvc;
using System.IO;

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
       
        [HttpGet("Index")]

        public IActionResult index()
        {
          var listabout=  _about.GetAllAboutUs();
            return View(listabout);
        }

        [HttpGet("create")]
        public IActionResult CreateAboutUs()

        {
            return View();
        }
        [HttpPost("create")]

        public IActionResult CreateAboutUs(CreateAboutUsViewModel aboutus, IFormFile ImagAbouts)
        {
            if (ModelState.IsValid)
            {
               

                    _about.AddAboutUs(aboutus, ImagAbouts);

            }

            return View(aboutus);

        }

        [HttpGet("EditAboutUs/{id}")]
        public IActionResult EditAboutUs(int id)
        {
            
            return View(_about.GetAboutUsforEdit(id));
        }
        [HttpPost("EditAboutUs/{id}")]
        public IActionResult EditAboutUs(EditAboutUsViewModel editabout,IFormFile imageAbout)
        {

            if (ModelState.IsValid)
            {

                _about.EditAboutUs(editabout, imageAbout);
            }
          
            return View(editabout);
                
        }
       
        public IActionResult DeletAboutUs(int id)
        {
            _about.DeleteAboutUS( id); 
            return View();
        }


    }
}

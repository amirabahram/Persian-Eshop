using Microsoft.AspNetCore.Mvc;
using Main.Domain.ViewModel.User;
using Main.Application.Services.Interfaces;
using Main.Domain.Models.User;
namespace Main.web.Controllers
{
    public class AccountController : Controller
    {
        private IUserRegisterService _regService;

        public AccountController(IUserRegisterService regService)
        {
            _regService = regService;
        }

        [Route("register")]
        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(UserRegisterViewModel Vmodel)
        {
            //if (_regService.IsDuplicated)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    var insertResult = _regService.Insert(Vmodel);
            //    if (insertResult)
            //    {
            //        return View();
            //    }
            //    else
            //    {
            //        return NotFound();
            //    }
            //}
            return View(Vmodel);
            
            //Return RedirectToAction("Login");
        }
    }
}

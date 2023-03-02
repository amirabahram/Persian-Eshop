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
            if (ModelState.IsValid)
            {
                var insertresult = _regService.Register(Vmodel);
                switch (insertresult)
                {
                    case RegisterUserResult.Success:
                        return View("RegisterSuccess");
                    case RegisterUserResult.EmailDuplicated:
                        ModelState.AddModelError("Email", "ایمیل شما تکراری می باشد.");

                        return View(Vmodel);
                    case RegisterUserResult.PasswrordAndRepasswordDoesNotMatch:
                        ModelState.AddModelError("Password", "پسوورد و تکرار پسوورد مطابقت ندارد");
                        return View(Vmodel);
                    case RegisterUserResult.Empty:
                        return View(Vmodel);
                }

                return View();
                

            }
            return View(Vmodel);

        }

        [Route("SubmittDone/{activationCode}")]
        public IActionResult SubmittDone(string activationCode)
        {
            _regService.ActiveUser(activationCode);
            return View("RegisterUser");
        }
    }
}

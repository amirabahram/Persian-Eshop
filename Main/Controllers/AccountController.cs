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
            return View();
        }


        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            return View("LoginUserViewModel");
        }


        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel  login)
        {
            if(!ModelState.IsValid)
                return View(login);

           
            if(!_regService.IsExistUser(login.Email,login.Password))
            {
                ModelState.AddModelError("email", " user not found");
                return View(login);
            }
          
            return Redirect("/");





           // if(ModelState.IsValid)
           // {
           //     return View(login); 
           // }
           // var user=_regService.GetuserViewModel(login.Email.ToLower(), login.Password);
           //if (user == null)    
           // {
           //     ModelState.AddModelError("Email", "ایمیل شما به درستی ثبت نشده است ");
           //     return View(login);
           // }
           // return View();
        }
        #endregion







    }
}

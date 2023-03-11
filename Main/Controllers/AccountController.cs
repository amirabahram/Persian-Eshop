using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.Emit;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace Main.web.Controllers

{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService regService)
        {
            _userService = regService;
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
                var insertresult = _userService.Register(Vmodel);
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
            _userService.ActiveUser(activationCode);
            return View();
        }


        #region Login

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            if(!ModelState.IsValid) return View("login");

            var user = _userService.IsExistUser(login.Email, login.Password);
           
            if (user == null)
            {
                ModelState.AddModelError("Email", "اطلاعات صحیح نیست");
                return View(login);
            }


            //var id = User.FindFirst("NameIdentifier").Value;
            

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var identoty = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identoty);
            var propertties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, propertties);
            
            return Redirect("/");
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("");
        }
        #endregion


        #region ForgatPassword


        [HttpGet("ResetPassword/{activationCode}")]
            public IActionResult ResetPassword(string activationCode)
        {

            var x =_regService.ActivactionCod(activationCode);
            if(x==null)
                return NotFound("یوزری پیدا نشد ");


            return View(new ForgotPasswordViewModel { ActivationCode = activationCode });
        }

        [HttpPost("ResetPassword/{activationCode}")]
        public IActionResult ResetPassword(ForgotPasswordViewModel newpass)
        {
            if (newpass == null)
                return NotFound("موردی پیدا نشد");
           
            if (!ModelState.IsValid)
                return View(newpass);
            


            
                 var forgatpassword = _userService.forgatPassword(forgatpass.Email );
                if (forgatpassword = false)
                {
                   
                    return View();
                }
              
            }
            return View();
        }
        #endregion


        #endregion


    }
}

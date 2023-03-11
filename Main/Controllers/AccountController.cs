using Microsoft.AspNetCore.Mvc;
using Main.Domain.ViewModel.User;
using Main.Application.Services.Interfaces;
using Main.Domain.Models.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Login(LoginViewModel  login)
        {
            if(!ModelState.IsValid) return View("login");

            var user = _userService.IsExistUser(login.Email, login.Password);
           
            if (user == null)
            {
                ModelState.AddModelError("email", " user not found");
                return View( login);
            }
          
            //cooki

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, login.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var identoty =new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal=new ClaimsPrincipal(identoty);
            var propertties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, propertties);
            
            return Redirect("/");
        }
        #endregion


        #region ForgatPassword

        public IActionResult ForagtPassword()
        {
            return View();
        }
       public IActionResult ForagtPassword( ForgatPassword  forgatpass )
        {
            if(ModelState.IsValid)
            {

            
                 var forgatpassword = _userService.forgatPassword(forgatpass.Email );
                if (forgatpassword = false)
                {
                   
                    return View();
                }
              
            }
            return View();
        }
        #endregion




    }
}

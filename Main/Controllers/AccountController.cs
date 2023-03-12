using Main.Application.Security;
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
            if (!ModelState.IsValid) return View("login");

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

        [HttpGet("ResetEmail")]
        public IActionResult GetEmailViewModel()
        {
            return View();

        }

        [HttpPost("ResetEmail")]

        public async Task<IActionResult> GetEmailForgotPassword(GetEmailViewModel getEmail)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.checkEmail(getEmail.Email);
                if (user == true)
                {
                    var res = await _userService.ForgotPasswordGetBayEmail(getEmail.Email);
                    if (res == true)
                    {
                        ViewBag.text = "لینک باز یابی با موفقیت ارسال شد ";
                    }

                }
                else
                    ViewBag.text = "خطا در ارسال ";
                return PartialView("SendEmailResult");

            }

            return Redirect("/");



        }



        [HttpGet]
        public IActionResult ResetPassword(string activationCode)
        {

            ForgotPasswordViewModel x = _userService.GetUserByActivationCode(activationCode);

            if (x != null)
                return View( new ForgotPasswordViewModel() { UserId=x.UserId});


            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ForgotPasswordViewModel foget)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetUserById(foget.UserId);
                user.Id = foget.UserId;
                user.Password = foget.Newpassword.EncodePasswordMd5();
               
                await _userService.UpdatePassword(user);
                return RedirectToAction("Login");
            }

            return View();
        }
        #endregion





    }
}

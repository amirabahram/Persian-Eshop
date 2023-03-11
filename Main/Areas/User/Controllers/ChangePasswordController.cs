using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Main.web.Controllers;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Authorization;
using Main.Domain.ViewModel.User;
using Main.Application.Services.Interfaces;
using Main.Application.Security;
using Eshope.Web.HttpManager;

namespace Main.web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]   /////if user doesnt Authorized then user will send to login page!
    public class ChangePasswordController : Controller
    {
        private IUserService _userService;
        public ChangePasswordController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult UserPasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserPasswordChange(UserChangePassword viewModel)
        {
            if (!ModelState.IsValid) return View();
            int id = User.GetUserId(); //// Identity Extension

            if (Hash.EncodePasswordMd5(viewModel.OldPassword) != await _userService.GetPasswordById(id))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور قبلی صحیح نیست!");
                return View();
            }
            else
            {
                await  _userService.UpdatePassword(viewModel.NewPassword,id);
                return JsonResponseStatus.Success();
                //return RedirectToAction("Index", "Home", new { area = "User" });

            }

           
        }
    }
}

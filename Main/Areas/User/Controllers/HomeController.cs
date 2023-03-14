using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.User;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class HomeController : Controller
    {
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            this._userService = userService;
        }
        public async Task<IActionResult> Index(UserAvatarViewModel view)
        {
            int id = User.GetUserId();
            view.AvatarName =  await _userService.GetAvatarNameById(id);
            return View(view);
        }
    }
}

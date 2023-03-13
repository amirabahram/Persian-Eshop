using Main.Application.Services.Interfaces;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [Area("User")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            int id = User.GetUserId();
            await _userService.UploadImageByUser(image, id);
            return RedirectToAction("Index", "Home", new {area="User"});
        }
    }
}

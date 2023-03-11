using Main.Domain.Interfaces;
using Main.Domain.Models.User;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Mvc;


namespace Main.web.Components
{
    [ViewComponent]
    public class SidebarViewComponent:ViewComponent
    {
        private IUserRepository _userRepository;
        public SidebarViewComponent(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = User.GetUserId();
            UserEntity user = await _userRepository.GetUserForEditById(id);
            return View("Sidebar",user);//mitavanestim view model ham barayash besazim!
        }
    }
}

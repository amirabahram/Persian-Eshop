using Microsoft.AspNetCore.Mvc;

namespace Main.web.Components
{
    [ViewComponent]
    public class SideBarViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Sidebar");
        }
    }
}

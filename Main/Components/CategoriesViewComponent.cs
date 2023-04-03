using Main.Application.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Main.web.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var view = await _categoryService.GetAllCategories();
            return View("Categories",view);
        }
    }
}

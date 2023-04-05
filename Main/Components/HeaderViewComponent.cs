using Main.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Components
{
    [ViewComponent]
    public class HeaderViewComponent: ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private IProductServices _productServices;

        public HeaderViewComponent(ICategoryService categoryService, IProductServices productServices)
        {
            this._categoryService = categoryService;
            this._productServices = productServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allProducts = await _productServices.GetAllProductsForMenu();
            ViewBag.AllCategories = await _categoryService.GetAllCategories();
            return View("Header",allProducts);
        }

    }
}

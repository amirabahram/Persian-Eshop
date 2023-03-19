using Eshope.Web.HttpManager;
using Main.Application.Services.Interfaces;
using Main.Domain.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryService _categoryService;
        public ProductController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult IndexCategory()
        {
            var category = _categoryService.GetAllCategories();
            return View(category);
        }
        [HttpPost]
        public IActionResult IndexCategory()
        {
            return View();
        }
    }
}

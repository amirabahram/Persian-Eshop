
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Product;
using Main.Domain.ViewModel.User;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductServices productServices)
        {
            _logger = logger;

            _categoryService = categoryService;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var category = await _categoryService.GetAllCategories();
            var model = new CategoryViewModel
            {

            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}

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

        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            this._categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await  _categoryService.GetAllCategories();
            return View(allCategories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
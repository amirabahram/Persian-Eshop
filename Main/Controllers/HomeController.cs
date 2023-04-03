
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

        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var allCategoriesAndProducts = await _productServices.GetAllCategoriesAndProducts();
            return View(allCategoriesAndProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
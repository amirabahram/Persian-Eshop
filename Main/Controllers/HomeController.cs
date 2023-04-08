
using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
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

        public async Task<IActionResult> Index(FilterProductViewModel filter)
        {
            var showAllProduct = await _productServices.Filter(filter);
            
            return View(showAllProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
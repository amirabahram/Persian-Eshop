using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class ShowProductController : Controller
    {
        
        private readonly IProductServices _productService;

        public ShowProductController(IProductServices productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        
        public async Task<IActionResult> ShowProducts( FilterProductViewModel filter)
        {
            
            var filterOut  = await _productService.Filter(filter); 
            return View(filterOut);
        }
        [HttpGet]
        public async Task<IActionResult> ShowProductsAjax( FilterProductViewModel filter)
        {
            
            var filterOut = await _productService.Filter(filter);
            return PartialView(filterOut);
        }
    }
}

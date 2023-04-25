using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class ShowProductController : Controller
    {
        
        private  IProductServices _productService;
        private  IPropertiesService _propertiesService;

        public ShowProductController(IProductServices productService, IPropertiesService _propertiesService)
        {
            this._productService = productService;
            this._propertiesService = _propertiesService;
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

        [HttpGet]
        public async Task<IActionResult> ShowProduct(int id)
        {
            var model = await _productService.GetProductForShowById(id);
            return View(model);
        }
    }
}

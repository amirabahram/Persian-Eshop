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
        [Route("Group/{id}/{title}")]
        public async Task<IActionResult> ShowProducts(int id,string title)
        {
            FilterProductViewModel filterProductViewModel = new FilterProductViewModel();

            return View();
        }
    }
}

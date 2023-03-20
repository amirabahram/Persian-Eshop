using Eshope.Web.HttpManager;
using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
using Main.Domain.ViewModel.Product;
using Main.Domain.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Main.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductServices _productServices;
        public ProductController(ICategoryService categoryService, IProductServices productServices)
        {
            _categoryService = categoryService;
            _productServices = productServices;
        }

        [HttpGet]
        public IActionResult IndexCategory()
        {
            var category = _categoryService.GetAllCategories();
            return View(category);
        }
        

        


        public async Task<IActionResult> Index()
        {
           
            return View(await _productServices.GetAllProduct());
        }

        [HttpGet]
        public async  Task<IActionResult> CreateProduct()
        {
            var productvViewModel = new ProductViewModel
            {
                Categories = await _categoryService.GetAllCategories()
            };
            return View(productvViewModel); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                bool InserResult = await _productServices.InsertProduct(productViewModel);
                if (InserResult)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("CreateProduct");
                }
            }
            return View(productViewModel);


        }
           
           
       


        public async Task<IActionResult> UpdateProduct(int id)
        {
            return View(await _productServices.UpdateProduct(id));
        }


        [HttpPost]
        public IActionResult DeletProdudct(int id)
        {
            _productServices.RemoveProduct(id);
            return View();
        }

    }
}

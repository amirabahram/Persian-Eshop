using Eshope.Web.HttpManager;
using Main.Application.Services.Implementations;
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Filtering;
using Main.Domain.ViewModel.Product;
using Main.Domain.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academy.Application.Security;
using Main.Domain.Models.Product_Image_Gallery;

namespace Main.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductServices _productServices;
        private readonly IProductImageGalleryService _productImageGalleryService;
       
        public ProductController(ICategoryService categoryService, IProductServices productServices, IProductImageGalleryService productImageGalleryService)
        {
            _categoryService = categoryService;
            _productServices = productServices;
            _productImageGalleryService = productImageGalleryService;
              
        }

        [HttpGet]
        public async Task<IActionResult> IndexCategory()
        {
            var category = await _categoryService.GetAllCategories();
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> IndexCategory(CategoryViewModel model)
        {
            var result = await _categoryService.InsertCategory(model);
            if (result)
            {
                return JsonResponseStatus.Success();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return JsonResponseStatus.Success();
        }


        public async Task<IActionResult> Index()
        {
            var showAllProduct = await _productServices.GetAllProduct();
            return View(showAllProduct);
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
        public async Task<IActionResult> CreateProduct([FromForm] ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {

                CreateProductResult InserResult = await _productServices.InsertProduct(productViewModel);
                if (InserResult== CreateProductResult.Success)
                {
                    TempData["SuccessMessage"] ="ثبت محصول با موفقیت انجام شد";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Failed"] = "مشکلی در ثبت محصول وجود دارد!";
                    return View("CreateProduct");
                }
            }
            productViewModel.Categories = await _categoryService.GetAllCategories();
            return View(productViewModel);


        }
           
           
        

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
           
           return View(await _productServices.ShowProductForEditById(id));


        }

        [HttpPost]

        public async Task<IActionResult> UpdateProduct( ProductViewModel view)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _productServices.UpdateProduct(view);
                if (result == UpdateProductResult.Success)
                {
                    TempData["SuccessMessage"] = "ویرایش محصول با موفقیت انجام شد";
                    return RedirectToAction("Index");
                }
                if(result == UpdateProductResult.ProductNotFound)
                {
                    TempData["Failed"] = "مشکلی در ویرایش محصول وجود دارد!";
                    return  RedirectToAction("Index");
                }
            }
            return View(view);

        }
        [HttpPost]
        public async Task<IActionResult> DeletProdudct(int id)
        {
            CreateProductResult DeleteResult = await _productServices.RemoveProduct(id);
            if (DeleteResult == CreateProductResult.Success)
            {
                return new JsonResult(new { status = "Success" });

            }
            else
            {
                TempData["Failed"] = "مشکلی در حذف محصول وجود دارد!";
                return RedirectToAction("Index", "Product");
            }
        }

        public async Task<IActionResult> ProductGallery(int id)
        {

            ViewBag.Pictures = await _productImageGalleryService.GetGalleryImages(id);
            var inputImages = new ProductGalleryAddViewModel()
            {
                ProductId = id
            };
            return View(inputImages);
        }
        [HttpPost]
        public async Task<IActionResult> ProductGallery(ProductGalleryAddViewModel images)
        {
            if (ModelState.IsValid)
            {
                await _productImageGalleryService.InsertGalleryImage(images.InputImages, images.ProductId);
                var indexModel = await _productServices.GetAllProduct();
                return View("Index", indexModel);
            }
            return RedirectToAction("ProductGallery");

        }
        [HttpPost]
        public async Task<IActionResult> GalleryImageDelete(int imageId, int productId)
        {
            await _productImageGalleryService.DeleteGalleryImage(imageId, productId);
            return JsonResponseStatus.Success();

        }
    }
}

﻿using Academy.Application.Extensions;
using Academy.Application.Security;
using Main.Application.Services.Interfaces;
using Main.Data.Repositories;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.Models.ProductProperties;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.Filtering;
using Main.Domain.ViewModel.Product;

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main.Application.Services.Implementations
{
    public class ProductServices : IProductServices
    {
        private IProductRepository _productRepository;
        private ICategoryService _categoryServices;
        private IProductImageGalleryService _productImageGalleryService;
        private IPropertiesRepository _propertiesRepository;


        public ProductServices(IProductRepository productRepository, IProductImageGalleryService productImageGalleryService, ICategoryService categoryServices, IPropertiesRepository propertiesRepository)
        {
            _productRepository = productRepository;
            _categoryServices = categoryServices;
            _productImageGalleryService = productImageGalleryService;
            _propertiesRepository = propertiesRepository;

        }

        public async Task<FilterProductViewModel> Filter(FilterProductViewModel model)
        {
            return await _productRepository.Filter(model);
        }




        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }



        public async Task<List<ProductsMenuViewModel>> GetAllProductsForMenu()
        {
            var allProducts = await _productRepository.GetAllProduct();
            var productsList = new List<ProductsMenuViewModel>();
            foreach (var product in allProducts)
            {
                var model = new ProductsMenuViewModel()
                {
                    CategoryId = product.CategoryId,
                    ProductId = product.Id,
                    ProductTitle = product.Title


                };
                productsList.Add(model);
            }

            return productsList;

        }

        public async Task<ProductShowViewModel> GetProductForShowById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var viewModel = new ProductShowViewModel()
            {
                Description = product.Description,
                Name = product.Title,
                MainImage = product.MainImage,
                Price = product.Price,
                Count = product.Count.GetValueOrDefault(),
                ProductId = product.Id,

            };
            var properties = await _propertiesRepository.GetPropertiesByProduct(product.Id);
            foreach (var i in properties)
            {
                viewModel.Properties.Add(i.Title, i.PropertyValue);
            }

            if (product.productImageGalleries != null)
            {
                foreach (var item in product.productImageGalleries)
                {
                    viewModel.Images.Add(item.ImageName);


                }
            }

            return viewModel;
        }

        public async Task<CreateProductResult> InsertProduct(ProductViewModel productViewModel)
        {

            if (productViewModel == null) return CreateProductResult.Failure;

            #region Declare Variables

            string imageNewName = "";
            int ProductImageGalleryId = 0;

            #endregion

            #region Insert Product With MainImage 

            if (productViewModel.MainImage.HasLength(0) == false && productViewModel.MainImage.IsImage() == true)
            {
                // Get the filename and extension
                var fileName = Path.GetFileName(productViewModel.MainImage.FileName);
                var fileExt = Path.GetExtension(fileName);
                // Generate a unique filename
                imageNewName = Guid.NewGuid().ToString() + fileExt;

                // Combine the path with the filename
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProducts/");

                // Save the file to the server
                productViewModel.MainImage.AddImageToServer(imageNewName, filePath, 50, 100);

                var newProduct = new Product()
                {
                    Title = productViewModel.Title,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price.GetValueOrDefault(),
                    Count = productViewModel.Count,
                    MainImage = imageNewName,
                    CategoryId = productViewModel.CategoryId,
                    CreateDate = DateTime.Now,
                    IsActive = true

                };
                await _productRepository.InsertProduct(newProduct);
                // Now how to save product in product table
                await _productRepository.Save();
                var propertiesList = new List<ProductProperties>();
                foreach (var i in productViewModel.SelectedProperties)
                {
                    var newProperties = new ProductProperties()
                    {
                        PropertyId = i,
                        ProductId = newProduct.Id
                    };
                    propertiesList.Add(newProperties);
                }
                await _productRepository.AddPropertyToProduct(propertiesList);
                await _productRepository.Save();
                // Get Id Of Product that Inserted Now
                ProductImageGalleryId = newProduct.Id;



            }
            #endregion
            else
            {
                #region Insert Product  Without MainImage

                var ProductWihoutMainImage = new Product()
                {
                    Title = productViewModel.Title,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price.GetValueOrDefault(),
                    Count = productViewModel.Count,
                    MainImage = null,
                    CategoryId = productViewModel.CategoryId,
                    CreateDate = DateTime.Now,
                    IsActive = true

                };

                await _productRepository.InsertProduct(ProductWihoutMainImage);
                // Now how to save product in product table
                await _productRepository.Save();





                #endregion

            }



            await _productRepository.Save();

            return CreateProductResult.Success;

        }

        public async Task<CreateProductResult> RemoveProduct(int productId)
        {


            //if (await _productImageGalleryService.HasValue(productId))
            //{
            //    //Remove Records of Images From DataBase
            //    _productImageGalleryService.DeleteGalleryImage(productId);
            //}

            var product = await _productRepository.GetProductById(productId);
            product.IsDelete = true;
            _productRepository.UpdateProductByProduct(product);


            await _productRepository.Save();


            return CreateProductResult.Success;
        }


        public async Task<ProductViewModel> ShowProductForEditById(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null) return null;

            var Categories = await _categoryServices.GetAllCategories();
            var GalleryImages = await _productImageGalleryService.GetGalleryImages(id);
            return new ProductViewModel
            {
                //Id = product.Id,

                Title = product.Title,
                Description = product.Description,
                CategoryId = product.CategoryId.GetValueOrDefault(),
                Count = product.Count,
                IsActive = product.IsActive,
                Price = product.Price,
                MainPic = product.MainImage,
                Categories = Categories


            };

        }

        public async Task<UpdateProductResult> UpdateProduct(ProductViewModel model)
        {
            string imageNewName = "";
            var product = await _productRepository.GetProductById(model.Id);
            if (product == null) return UpdateProductResult.ProductNotFound;
            if (model.MainImage != null)
            {
                if (model.MainImage.HasLength(0) == false && model.MainImage.IsImage() == true)
                {

                    // Get the filename and extension
                    var fileName = Path.GetFileName(model.MainImage.FileName);
                    var fileExt = Path.GetExtension(fileName);
                    // Generate a unique filename
                    imageNewName = Guid.NewGuid().ToString() + fileExt;

                    // Combine the path with the filename
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProducts/");

                    // Save the file to the server
                    model.MainImage.AddImageToServer(imageNewName, filePath, 50, 100);
                }
                product.MainImage = imageNewName;
            }

            product.Title = model.Title;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.Count = model.Count;
            product.IsActive = model.IsActive;
            product.Price = model.Price.GetValueOrDefault();


            _productRepository.UpdateProductByProduct(product);
            await _productRepository.Save();
            return UpdateProductResult.Success;



        }
    }
}

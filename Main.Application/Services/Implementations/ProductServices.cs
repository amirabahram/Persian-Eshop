using Academy.Application.Extensions;
using Academy.Application.Security;
using Main.Application.Services.Interfaces;
using Main.Data.Context;
using Main.Data.Migrations;
using Main.Data.Repositories;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.Models.User;
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
        private readonly IProductRepository _productRepository;
        private readonly IProductImageGalleryRepository _productImageGalleryRepository;


        public ProductServices(IProductRepository productRepository, IProductImageGalleryRepository productImageGalleryRepository)
        {
            _productRepository = productRepository;
            _productImageGalleryRepository = productImageGalleryRepository;

        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
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
                    Price = productViewModel.Price,
                    Count = productViewModel.Count,
                    MainImage = imageNewName,
                    CategoryId = productViewModel.CategoryId,
                    CreateDate = DateTime.Now,
                    IsActive = true

                };

                 await _productRepository.InsertProduct(newProduct);
                
                ProductImageGalleryId = await _productRepository.GetProductIdByProduct(newProduct);
            }
            #endregion
            else
            {
                #region Insert Product  Without MainImage

                var ProductWihoutMainImage = new Product()
                {
                    Title = productViewModel.Title,
                    Description = productViewModel.Description,
                    Price = productViewModel.Price,
                    Count = productViewModel.Count,
                    MainImage = null,
                    CategoryId = productViewModel.CategoryId,
                    CreateDate = DateTime.Now,
                    IsActive = true

                };

                ProductImageGalleryId = await _productRepository.InsertProduct(ProductWihoutMainImage);

                #endregion

            }


            #region Insert Images Of Product Into ProductImageGalleries 

            if (productViewModel.GalleryImages != null)
            {
                var GalleryImagesFileNewName = "";
                List<ProductImageGallery> imageGalleries = new List<ProductImageGallery>();
                for (int i = 0; i < productViewModel.GalleryImages.Count; i++)
                {
                    if (productViewModel.GalleryImages[i].HasLength(0) == false &&
                        productViewModel.GalleryImages[i].IsImage() == true)
                    {
                        // Get the filename and extension
                        var GalleryImagesFileName = Path.GetFileName(productViewModel.GalleryImages[i].FileName);
                        var GalleryImagesFileExt = Path.GetExtension(GalleryImagesFileName);
                        // Generate a unique filename
                        GalleryImagesFileNewName = Guid.NewGuid().ToString() + GalleryImagesFileExt;

                        // Combine the path with the filename
                        string GalleryImagesFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProducts/");

                        // Save the file to the server
                        productViewModel.GalleryImages[i].AddImageToServer(GalleryImagesFileNewName,
                            GalleryImagesFilePath, 50, 100);

                        imageGalleries.Add(new ProductImageGallery {
                            ProductId = ProductImageGalleryId,
                            ImageName = GalleryImagesFileNewName,
                            CreateDate = DateTime.Now
                        });

                    }
                }
                // Save ImageName Of Product On the Database
                await _productImageGalleryRepository.InsertImage(imageGalleries);

                await _productImageGalleryRepository.Save();

            }

            #endregion


            _productRepository.Save();

            return CreateProductResult.Success;

        }

        public async Task RemoveProduct(int productId)
        {
            // Combine the path with the filename
            string GalleryImagesFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProducts/");

            //

            var product = await _productRepository.RemoveProductById(productId);

            _productRepository.UpdateProductByProduct(product);


            _productRepository.Save();
        }

        public Task<bool> UpdateProduct(int proudctId)
        {
            throw new NotImplementedException();
        }


    }
}

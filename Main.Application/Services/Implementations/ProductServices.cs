using Main.Application.Services.Interfaces;
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

        public ProductServices(IProductRepository productRepository,IProductImageGalleryRepository productImageGalleryRepository)
        {
            _productRepository = productRepository;
            _productImageGalleryRepository = productImageGalleryRepository;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        public async Task<bool> InsertProduct(ProductViewModel productViewModel)
        {            

            if (productViewModel == null) return false;

            var newProduct = new Product()
            {
                Title = productViewModel.Title,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                Count = productViewModel.Count,                
                MainImage = productViewModel.MainImage,
                CategoryId = productViewModel.CategoryId,
                CreateDate = DateTime.Now
                
            };
            await _productRepository.InsertProduct(newProduct);
            if (productViewModel.GalleryImages.Length>0)
            {                
                for (int i = 0; i < productViewModel.GalleryImages.Length; i++)
                {
                    productViewModel.GalleryImages[i]= Guid.NewGuid().ToString();

                    await _productImageGalleryRepository.InsertImage(
                        new ProductImageGallery{
                            ProductId= newProduct.Id,
                            ImageName= productViewModel.GalleryImages[i]
                        }
                        );                   
                }                
            }

            _productRepository.Save();
            return true;
        }

        public  async Task RemoveProduct(int productId)
        {


           var product= await _productRepository.RemoveProductById(productId);


            _productRepository.UpdateProductByProduct(product);
             _productRepository.Save();
        }

        public Task<bool> UpdateProduct(int proudctId)
        {
            throw new NotImplementedException();
        }


    }
}

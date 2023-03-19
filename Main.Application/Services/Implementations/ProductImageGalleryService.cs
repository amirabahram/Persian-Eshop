using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product_Image_Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class ProductImageGalleryService:IProductImageGalleryService
    {
        private IProductImageGalleryRepository _productImageGalleryRepository;
        public ProductImageGalleryService(IProductImageGalleryRepository productImageGalleryRepository)
        {
            this._productImageGalleryRepository = productImageGalleryRepository;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImageGallery> GetImageGallery()
        {
            throw new NotImplementedException();
        }

        public Task<ProductImageGallery> GetImageGallery(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insert(ProductImageGallery imageGallery)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ProductImageGallery imageGallery)
        {
            throw new NotImplementedException();
        }
    }
}

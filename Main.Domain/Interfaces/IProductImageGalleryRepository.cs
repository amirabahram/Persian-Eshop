using Main.Domain.Models.Product_Image_Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IProductImageGalleryRepository
    {
        Task<ProductImageGallery> GetGalleryImageById(int imageId, int productId);
        Task<List<ProductImageGallery>> GetGalleryImagesById(int productId);
        Task InsertImage(List<ProductImageGallery> productImageGallery);
        void UpdateImage(ProductImageGallery image);
        Task Save();

        Task<bool> HasValue(int productId);
    }
}

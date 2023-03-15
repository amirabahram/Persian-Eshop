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
        Task<List<ProductImageGallery>> GetAllImages();
        Task InsertImage(ProductImageGallery productImageGallery);
        void UpdateImage(ProductImageGallery image);
    }
}

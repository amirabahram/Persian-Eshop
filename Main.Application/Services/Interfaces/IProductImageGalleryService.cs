using Main.Domain.Models.Product_Image_Gallery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IProductImageGalleryService
    {
        Task<ProductImageGallery> GetImageGallery(int id);
        Task<bool> Insert(ProductImageGallery imageGallery);
        Task<bool> Update(ProductImageGallery imageGallery);
        Task <bool> Delete(int id);
    }
}

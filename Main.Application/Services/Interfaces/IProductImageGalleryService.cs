using Main.Domain.Models.Product_Image_Gallery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IProductImageGalleryService
    {
        Task<List<ProductImageGallery>> GetGalleryImages(int id);
        Task<bool> InsertGalleryImage(List<IFormFile> imageGalleries, int id);
        Task<bool> UpdateGalleryImage(List<IFormFile> imageGalleries, int id);
        Task<bool> DeleteGalleryImage(int id);
        Task<bool> Save();
    }
}

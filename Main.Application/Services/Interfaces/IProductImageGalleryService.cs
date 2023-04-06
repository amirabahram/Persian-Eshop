using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.ViewModel.Product;
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
        Task<List<ProductGalleryShowViewModel>> GetGalleryImages(int id);
        Task<bool> InsertGalleryImage(List<IFormFile> imageGalleries, int id);
        Task<bool> DeleteGalleryImage(int imageId,int productId);
        Task<bool> Save();
        Task<bool> HasValue(int productId);
    }
}

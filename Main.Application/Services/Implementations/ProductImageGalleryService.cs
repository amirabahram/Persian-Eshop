using Academy.Application.Extensions;
using Academy.Application.Security;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.ViewModel.Product;
using Microsoft.AspNetCore.Http;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class ProductImageGalleryService : IProductImageGalleryService
    {
        private IProductImageGalleryRepository _productImageGalleryRepository;

        public ProductImageGalleryService(IProductImageGalleryRepository productImageGalleryRepository)
        {
            this._productImageGalleryRepository = productImageGalleryRepository;

        }

        public async Task<bool> DeleteGalleryImage(int imageId, int productId)
        {
            if (imageId == 0 || productId==0) return false;

            var image = await _productImageGalleryRepository.GetGalleryImageById( imageId,productId);
            
            
            image.IsDelete = true; 

            
            _productImageGalleryRepository.UpdateImage(image);
            await _productImageGalleryRepository.Save();
            return true;
        }

        public async Task<List<ProductGalleryShowViewModel>> GetGalleryImages(int id)
        {

            var images = await _productImageGalleryRepository.GetGalleryImagesById(id);
            var galleryList = new List<ProductGalleryShowViewModel>();

            foreach(var image in images)
            {
                var gallery = new ProductGalleryShowViewModel()
                {
                    ProductId = id,
                    ImageId = image.Id,
                    Picture = image.ImageName

                };
                galleryList.Add(gallery);
            };
           return galleryList;

        }


        public async Task<bool> InsertGalleryImage(List<IFormFile> imageGallery, int id)
        {
            if (imageGallery != null)
            {
                var GalleryImagesFileNewName = "";
                List<ProductImageGallery> imageGalleries = new List<ProductImageGallery>();
                for (int i = 0; i < imageGallery.Count; i++)
                {
                    if (imageGallery[i].HasLength(0) == false &&
                        imageGallery[i].IsImage() == true)
                    {
                        // Get the filename and extension
                        var GalleryImagesFileName = Path.GetFileName(imageGallery[i].FileName);
                        var GalleryImagesFileExt = Path.GetExtension(GalleryImagesFileName);
                        // Generate a unique filename
                        GalleryImagesFileNewName = Guid.NewGuid().ToString() + GalleryImagesFileExt;

                        // Combine the path with the filename
                        string GalleryImagesFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageProducts/");

                        // Save the file to the server
                        imageGallery[i].AddImageToServer(GalleryImagesFileNewName,
                            GalleryImagesFilePath, 50, 100);


                        imageGalleries.Add(new ProductImageGallery
                        {
                            ProductId = id,
                            ImageName = GalleryImagesFileNewName,
                            CreateDate = DateTime.Now
                        });

                    }
                }
                // Save ImageName Of Product On the Database
                await _productImageGalleryRepository.InsertImage(imageGalleries);
          

                await _productImageGalleryRepository.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Save()
        {
            await _productImageGalleryRepository.Save();
            return true;
        }


       

       public async Task<bool> HasValue(int productId)
        {
            return await _productImageGalleryRepository.HasValue(productId);
        }
    }
}

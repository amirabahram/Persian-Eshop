using Academy.Application.Extensions;
using Academy.Application.Security;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product_Image_Gallery;
using Microsoft.AspNetCore.Http;
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

        public async Task<bool> DeleteGalleryImage(int id)
        {
            if (id == 0) return false;
            var images = await _productImageGalleryRepository.GetGalleryImageById(id);
            foreach (var image in images)
            {
                image.IsDelete = true;
            }
            _productImageGalleryRepository.UpdateImage(images);
            await _productImageGalleryRepository.Save();
            return true;
        }

        public async Task<List<ProductImageGallery>> GetGalleryImages(int id)
        {
            return await _productImageGalleryRepository.GetGalleryImageById(id);
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


        public async Task<bool> UpdateGalleryImage(List<IFormFile> imageGallery, int id)
        {
            var oldImages = await GetGalleryImages(id);
            foreach (var image in oldImages) { image.IsDelete = true; }
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
                _productImageGalleryRepository.UpdateImage(oldImages);
                _productImageGalleryRepository.UpdateImage(imageGalleries);

                await _productImageGalleryRepository.Save();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

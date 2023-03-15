using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product_Image_Gallery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class ProductImageGalleryRepository : IProductImageGalleryRepository
    {
        private readonly EshopContext db;
        public ProductImageGalleryRepository(EshopContext context)
        {
            this.db = context;
        }
        public async Task<List<ProductImageGallery>> GetAllImages()
        {
           return await db.ProductImageGalleries.Where(i => i.IsDelete == false).ToListAsync();
        }

        public async Task InsertImage(ProductImageGallery productImageGallery)
        {
            db.ProductImageGalleries.Add(productImageGallery);
        }

        public void UpdateImage(ProductImageGallery image)
        {
            db.ProductImageGalleries.Update(image);
        }
    }
}

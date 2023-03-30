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


        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public async Task<List<ProductImageGallery>> GetGalleryImageById(int id)
        {
            return await db.ProductImageGalleries.Where(i => i.ProductId == id && i.IsDelete == false).ToListAsync();
        }


        public async Task InsertImage(List<ProductImageGallery> productImageGallery)
        {
            await db.ProductImageGalleries.AddRangeAsync(productImageGallery);
        }

        public void UpdateImage(List<ProductImageGallery> images)
        {
           db.ProductImageGalleries.UpdateRange(images);
        }

        public async Task<bool>  HasValue(int proudctId)
        {
            return await db.ProductImageGalleries.AnyAsync(p => p.ProductId == proudctId);
        }
    }
}

using Main.Data.Context;
using Main.Data.Migrations;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EshopContext _eshopContext;

        public ProductRepository(EshopContext eshopContext)
        {
            _eshopContext = eshopContext;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _eshopContext.Products.Include(c=>c.Category).Where(p=>p.IsDelete==false && p.IsActive==true).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _eshopContext.Products.Include(c => c.Category).FirstOrDefaultAsync(p=>p.Id==Id && p.IsDelete == false && p.IsActive == true);
        }

        public async Task<int> InsertProduct(Product product)
        {
             await _eshopContext.Products.AddAsync(product);
            await _eshopContext.SaveChangesAsync();
            return product.Id;
        }

       

        public async void UpdateProductByProduct(Product product)
        {
          
             _eshopContext.Products.Update(product);
        }

        public async Task<Product> RemoveProductById(int Id)
        {
         
            var myproduct= _eshopContext.Products.FirstOrDefaultAsync(p => p.Id == Id).Result;
            myproduct.IsDelete = true;
            return myproduct;
        }

        public void Save()
        {
            _eshopContext.SaveChangesAsync();
        }

        public async Task<int> GetProductIdByProduct(Product product)
        {
            var product1 = await _eshopContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            return product1.Id;
        }
    }
}

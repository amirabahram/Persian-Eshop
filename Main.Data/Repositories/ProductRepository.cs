using Main.Data.Context;
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
            return await _eshopContext.Products.Where(p=>p.IsDelete==false).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _eshopContext.Products.FirstOrDefaultAsync(p=>p.Id==Id);
        }

        public async Task InsertProduct(Product product)
        {
             await _eshopContext.Products.AddAsync(product);
        }

       

        public void UpdateProductById(Product product)
        {
             _eshopContext.Products.Update(product);
        }
    }
}

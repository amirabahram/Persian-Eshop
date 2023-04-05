using Main.Data.Context;
using Main.Data.Migrations;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Main.Domain.ViewModel.Filtering;
using Main.Domain.ViewModel.Product;
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
            return await _eshopContext.Products.Include(c => c.Category).Where(p => p.IsDelete == false).OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _eshopContext.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.Id == Id && p.IsDelete == false);
        }

        public async Task InsertProduct(Product product)
        {
            await _eshopContext.Products.AddAsync(product);

        }



        public void UpdateProductByProduct(Product product)
        {

            _eshopContext.Products.Update(product);
        }


        public async Task Save()
        {
            await _eshopContext.SaveChangesAsync();
        }

        public IQueryable<Product> Filter() //// view model bayad bashe tu servise fagat mifrestim. tu memari fagat bekhatere filtet az view model estefade konim. kole view model raftan to doman
        {

            return _eshopContext.Products.AsQueryable();

        }

    }
}


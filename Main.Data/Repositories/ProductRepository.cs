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

        public async Task<FilterProductViewModel> Filter(FilterProductViewModel viewModel) //// view model bayad bashe tu servise fagat mifrestim. tu memari fagat bekhatere filtet az view model estefade konim. kole view model raftan to doman
        {
            var query = _eshopContext.Products.Where(p => p.IsDelete == false && p.IsActive == true);
            if (viewModel.CategoryId != null)
            {
                query = query.Where(q => q.CategoryId == viewModel.CategoryId);

            }

            if (viewModel.Title != null)
            {
                //query = query.Where(q => q.Title.Contains(viewModel.Title));  /////// Contains C# ast
                // ya balaei ra estefade mikonim ya paeini
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{viewModel.Title}%"));

            }
            if (viewModel.MaxPrice != null)
            {
                var test = viewModel.MaxPrice.Replace(",", "");
                query = query.Where(q => q.Price >= Convert.ToInt32(viewModel.MinPrice.Replace(",", "")) && q.Price <= Convert.ToInt32(viewModel.MaxPrice.Replace(",", "")));

            }

            await viewModel.Paging(query);

            return viewModel;

        }

    }
}


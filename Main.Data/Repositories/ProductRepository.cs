using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Main.Domain.Models.ProductProperties;
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
            return await _eshopContext.Products.Include(p=>p.Properties).ThenInclude(p=>p.Category).Include(c => c.Category).Where(p => p.IsDelete == false).OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _eshopContext.Products.Include(p => p.Properties).Include(g=>g.productImageGalleries).Include(c => c.Category).ThenInclude(p=>p.categoryProperties).FirstOrDefaultAsync(p => p.Id == Id && p.IsDelete == false);
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
            var query = _eshopContext.Products.Include(p=>p.Properties).Include(p=>p.Category).Where(p => p.IsDelete == false && p.IsActive == true);
            
            if (viewModel!= null && viewModel.CategoryId != null)
            {
                query = query.Where(q => q.CategoryId == viewModel.CategoryId);

            }

            if (viewModel != null && viewModel.Title != null)
            {
                //query = query.Where(q => q.Title.Contains(viewModel.Title));  /////// Contains C# ast
                // ya balaei ra estefade mikonim ya paeini
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{viewModel.Title}%"));

            }
            if (viewModel != null && viewModel.MaxPrice != null)
            {
                var test = viewModel.MaxPrice.Replace(",", "");
                query = query.Where(q => q.Price >= Convert.ToInt32(viewModel.MinPrice.Replace(",", "")) && q.Price <= Convert.ToInt32(viewModel.MaxPrice.Replace(",", "")));

            }
            if(viewModel != null)
            {
                await viewModel.Paging(query);
            }
            

            return viewModel;

        }

        public async Task AddPropertyToProduct(List<ProductProperties> productProperties)
        {
            foreach(var property in productProperties)
            {
                await _eshopContext.ProductProperties.AddAsync(property);
            }
            
        }
    }
}


using Main.Data.Context;
using Main.Data.Migrations;
using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using Main.Domain.ViewModel.Filtering;
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
            return await _eshopContext.Products.Include(c=>c.Category).Where(p=>p.IsDelete==false).ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _eshopContext.Products.Include(c => c.Category).FirstOrDefaultAsync(p=>p.Id==Id && p.IsDelete == false);
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
    
        public async Task<FilterProductViewModel> Filter(FilterProductViewModel filterView)
        {
            //Soal -----> aya nabayad in dar service piade shavad??????????
            var query = _eshopContext.Products.AsQueryable();
            ///////////////////////////////////////---------------------------------bagie dar service piade mishavad!
            //if (!string.IsNullOrEmpty(filterView.Title))
            //{
            //    query = query.Where();
            //}
            //await filterView.Paging(query);
            return filterView;
        }

    }
    }


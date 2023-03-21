using Main.Data.Migrations;
using Main.Domain.Models.Product;
using Main.Domain.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IProductServices
    {
        // get all product from table
        public Task<List<Product>> GetAllProduct();

        // insert a product in product table
        public Task<CreateProductResult> InsertProduct(ProductViewModel productViewModel);

        // update a product in product table by product id
        public Task<bool> UpdateProduct(int proudctId);

        //remove a product from product table by product id
        public Task RemoveProduct(int productId);

        Task<int> GetProductIdByProduct(Product product);

    }
}

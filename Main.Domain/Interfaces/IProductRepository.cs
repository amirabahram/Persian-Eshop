using Main.Domain.Models.Product;
using Main.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IProductRepository
    {
        // insert product
        public Task<int> InsertProduct(Product product);
        // select all products from product table
        public Task<List<Product>> GetAllProduct();
        // select a product from product table by id
        public Task<Product> GetProductById(int Id);
       
        //update a product from product table by id
        public void UpdateProductByProduct(Product product);

        // remove product from product table by change value of IsDelete to true
        public Task<Product> RemoveProductById(int Id);

        public void Save();

        // Get ProductId From a Product
        public Task<int> GetProductIdByProduct(Product product);

    }
}

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
        public Task InsertProduct(Product product);
        // select all products from product table
        public Task<List<Product>> GetAllProduct();
        // select a product from product table by id
        public Task<Product> GetProductById(int Id);
       
        //update a product from product table by id
        public void UpdateProductById(Product product);




    }
}

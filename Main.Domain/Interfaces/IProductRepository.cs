using Main.Domain.Models.Product;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.Filtering;
using Main.Domain.ViewModel.Product;
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
        Task InsertProduct(Product product);
        // select all products from product table
        Task<List<Product>> GetAllProduct();

        // select a product from product table by id
        Task<Product> GetProductById(int Id);

        //update a product from product table by id
        void UpdateProductByProduct(Product product);

        Task<FilterProductViewModel> Filter(FilterProductViewModel filterProductView);

        Task Save();



    }
}

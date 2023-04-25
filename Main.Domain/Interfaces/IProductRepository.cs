using Main.Domain.Models.Product;
using Main.Domain.Models.ProductProperties;
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
        Task InsertProduct(Product product);

        Task<List<Product>> GetAllProduct();
        
        Task AddPropertyToProduct(List<ProductProperties> productProperties);

        Task<Product> GetProductById(int Id);

        void UpdateProductByProduct(Product product);

        Task<FilterProductViewModel> Filter(FilterProductViewModel filterProductView);

        Task Save();



    }
}

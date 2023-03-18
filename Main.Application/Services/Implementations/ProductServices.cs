using Main.Domain.Interfaces;
using Main.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class ProductServices : IProductRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }

        public async Task<Product> GetProductById(int Id)
        {
            var IsValid=await _productRepository.GetProductById(Id);
            if (IsValid!=null)
            {
                return IsValid;
            }
            return null;
        }

        public Task InsertProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductById(Product product)
        {
            throw new NotImplementedException();
        }
    }
}

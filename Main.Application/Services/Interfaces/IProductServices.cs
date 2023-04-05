using Main.Data.Migrations;
using Main.Domain.Models.Product;
using Main.Domain.ViewModel.Filtering;
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
         Task<List<Product>> GetAllProduct();

        // insert a product in product table
         Task<CreateProductResult> InsertProduct(ProductViewModel productViewModel);

        
         Task<UpdateProductResult> UpdateProduct(ProductViewModel model);

        //remove a product from product table by product id
         Task<CreateProductResult> RemoveProduct(int productId);


        Task<ProductViewModel> ShowProductForEditById(int id);


        Task<FilterProductViewModel> Filter(FilterProductViewModel model);
        Task<List<ProductsMenuViewModel>> GetAllProductsForMenu();

    }
}

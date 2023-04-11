using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Cart;
using Main.Domain.Models.CartProduct;
using Main.Domain.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            this._cartRepository = cartRepository;
            this._productRepository = productRepository;
        }




        public async Task<List<CartItemViewModel>> AddItem(CartItemViewModel model)
        {
            if (model == null) return null;
            var unpaidCart = await _cartRepository.UnpaidCartForUser(model.UserId);
            if (unpaidCart == null)
            {
                var itemPrice = Convert.ToInt32(model.OrderCount) * Convert.ToInt32(model.ItemPrice);

                var newCartModel = new Cart()
                {
                    CreateDate = DateTime.Now,
                    UserId = model.UserId,
                    TotalPrice = itemPrice

                };
                await _cartRepository.InsertCart(newCartModel);
                await _cartRepository.Save();
                var newDetailModel = new CartDetails()
                {
                    ProductId = model.ProductId,
                    CartId = newCartModel.Id,
                    OrderCount = Convert.ToInt32(model.OrderCount),
                    CreateDate = DateTime.Now,
                    ProductTotalPriceAfterDiscount = itemPrice

                };
                await _cartRepository.InsertCartDetails(newDetailModel);
                await _cartRepository.Save();



            }
            else
            {

                if (await _cartRepository.IsProductExistsForCart(unpaidCart.Id, model.ProductId) == false)
                {
                    var itemPrice = Convert.ToInt32(model.OrderCount) * Convert.ToInt32(model.ItemPrice);
                    unpaidCart.TotalPrice = unpaidCart.TotalPrice + itemPrice;
                    _cartRepository.UpdateCart(unpaidCart);
                    var unpaidCartDetails = new CartDetails()
                    {
                        CartId = unpaidCart.Id,
                        OrderCount = Convert.ToInt32(model.OrderCount),
                        ProductTotalPriceAfterDiscount = Convert.ToInt32(model.OrderCount) * Convert.ToInt32(model.ItemPrice),
                        ProductId = model.ProductId,
                        CreateDate = DateTime.Now
                    };
                    await _cartRepository.InsertCartDetails(unpaidCartDetails);
                    await _cartRepository.Save();
                };

            }

            var allProductsByCart = await _cartRepository.GetAllProductsByCart(unpaidCart.Id);
            var listOfViewModel = new List<CartItemViewModel>();
            foreach (var item in allProductsByCart)
            {
                var product = await _productRepository.GetProductById(item.ProductId);
                var viewModel = new CartItemViewModel()
                {
                    ImageName = product.MainImage,
                    ProductTitle = product.Title,
                    OrderCount = item.OrderCount.ToString(),
                    TotalProductPrice = item.OrderCount * product.Price.GetValueOrDefault(),
                    ItemPrice = product.Price.ToString()


                };

                listOfViewModel.Add(viewModel);
            }
            return listOfViewModel;

        }


        public Task<bool> DeleteItem(CartItemViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }
    }
}

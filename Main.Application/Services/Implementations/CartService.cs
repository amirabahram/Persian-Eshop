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


        public async Task<List<CartViewModel>> AddItemForFirstTime(CartViewModel model)
        {
            if (model == null) return null;
            Cart cart = new Cart()
            {
                CreateDate = DateTime.Now,
                UserId = model.UserId
            };
            await _cartRepository.InsertCart(cart);
            await _cartRepository.Save();
            CartDetails cartDetails = new CartDetails()
            {
                CreateDate = DateTime.Now,
                CartId = cart.Id,
                ProductId = model.ProductId.GetValueOrDefault()
            };

            await _cartRepository.InsertCartDetails(cartDetails);
            await _cartRepository.Save();
            return await GetCartByUserId(model.UserId);
        }

        public async Task<List<CartViewModel>> AddItem(CartViewModel model)
        {
            if (model == null) return null;
            var listOfViewModel = new List<CartViewModel>();
            var unpaidCart = await _cartRepository.UnpaidCartForUser(model.UserId);
            CartDetails cartDetails = new CartDetails()
            {
                CartId = unpaidCart.Id,
                CreateDate = DateTime.Now,
                ProductId = model.ProductId.GetValueOrDefault(),
            };
            await _cartRepository.InsertCartDetails(cartDetails);
            await _cartRepository.Save();
            return await GetCartByUserId(model.UserId);

        }



        public Task<bool> DeleteItem(CartViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FinalizingCart(int id)
        {
           var cart = await _cartRepository.GetCartByCartId(id);
            if(cart == null) return false;
            cart.IsPaid = true;
            _cartRepository.UpdateCart(cart);
            await _cartRepository.Save();
            return true;
        }

        public async Task<List<CartViewModel>> GetCartByUserId(int id)
        {
            var unpaidCart = await  _cartRepository.UnpaidCartForUser(id);
            if(unpaidCart == null) return null;
            var ListOfModel = new List<CartViewModel>();
            foreach (var item in unpaidCart.CartDetails)
            {
                var cartModel = new CartViewModel()
                {
                    
                    ProductPrice = item.Product.Price,
                    ProductOrderCount = item.OrderCount,
                    ProductTitle = item.Product.Title,
                    ImageName = item.Product.MainImage,
                    ProductId = item.ProductId,
                    CartId = item.CartId,
                    UserId = id

                };
                ListOfModel.Add(cartModel);
            }

            return ListOfModel;
        }

        public async Task<int> GetCartIdByUserId(int id)
        {
           var cart = await _cartRepository.UnpaidCartForUser(id);
            return cart.Id;
        }

        public async Task<int> GetCartTotalPriceByCartId(int id)
        {
            Cart cart = await _cartRepository.GetCartByCartId(id);
            return cart.TotalPrice;
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateCart(CartTotalPriceViewModel model)
        {
            if(model.TotalPrice == 0) return false;
            var cart = await _cartRepository.GetCartByCartId(model.CartId);
            cart.TotalPrice = model.TotalPrice;
            _cartRepository.UpdateCart(cart);
            await _cartRepository.Save();
            return true;
        }

        public async Task<bool> UpdateCartItems(CartViewModel model)
        {
            if (model == null) return false;
            var details = await _cartRepository.GetDetailsByCartIdAndProductId(model.CartId, model.ProductId.GetValueOrDefault());
            details.OrderCount = model.ProductOrderCount;
            details.IsDelete = model.IsDelete;
            var cart = details.Cart;
            cart.TotalPrice = model.TotalPrice;
            _cartRepository.UpdateCart( cart );
            _cartRepository.UpdateCartDetails( details );
            await _cartRepository.Save();
            return true;
        }
    }
}
    
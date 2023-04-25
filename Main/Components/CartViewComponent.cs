using Main.Application.Services.Interfaces;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Components
{
    public class CartViewComponent:ViewComponent
    {
        private ICartService _cartService;
        public CartViewComponent(ICartService cartService)
        {
            this._cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = User.GetUserId();
            var cart = await _cartService.GetCartByUserId(id);
            return View("Cart",cart);
        }
    }
}

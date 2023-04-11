using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Cart;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class CartController : Controller
    {

        private ICartService _cartService;
        public CartController(ICartService cartService)
        {
            this._cartService = cartService;
        }
        [HttpGet]
        [Authorize] ////ToDo : view for not login
        public async Task<IActionResult> ShowCartItems(int id)
        {
            var userId = User.GetUserId();
            var cartItemViewModel = new CartItemViewModel()
            {
                ProductId = id,
                UserId = userId
            };
            var model = await _cartService.AddItem(cartItemViewModel);
  
            return View(model);
        }
    }
}

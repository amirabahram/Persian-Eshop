using Eshope.Web.HttpManager;
using Main.Application.Services.Interfaces;
using Main.Domain.ViewModel.Cart;
using Main.web.IdentityManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Main.web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private ICartService _cartService;
        private IPaymentService _paymentService;
        public CartController(ICartService cartService, IPaymentService paymentService)
        {
            this._cartService = cartService;
            this._paymentService = paymentService;
        }
       

        public async Task<IActionResult> ShowCartItems(int? id)
        {
            var userId = User.GetUserId();
            List<CartViewModel> model = await _cartService.GetCartByUserId(userId);
            if ((id == null || id == 0) && model == null) return View("ShowEmptyCart");
            if (id==null || id == 0)
            {
                if (model == null) return Redirect("/");
                return View(model);
            }
            CartViewModel model2 = new CartViewModel()
            {
                ProductId = id,
                UserId = userId
            };
            if (model == null)
            {

                var viewModel = await _cartService.AddItemForFirstTime(model2);
                
                 return View(viewModel);
            }
            foreach(var item in model)
            {
                if (item.ProductId == id)
                {
                    var viewModel2 = await _cartService.GetCartByUserId(item.UserId);
                    return View(viewModel2);
                }
            }
            var viewModel3 =  await _cartService.AddItem(model2);
            return View(viewModel3);
            
        }


        [HttpPost]
        public async Task<IActionResult> CartItemsSubmit(CartViewModel model)
        {
            model.UserId = User.GetUserId();
            model.CartId = await _cartService.GetCartIdByUserId(model.UserId);
            var res = await _cartService.UpdateCartItems(model);
            if (res) {
                return JsonResponseStatus.Success();
            }
            else
            {
                return JsonResponseStatus.Error();
            }
            
        }
        
        public async Task<IActionResult> Payment(int totalPrice)
        {
            var userId = User.GetUserId();
            var cartId = await _cartService.GetCartIdByUserId(userId);
            CartTotalPriceViewModel model = new CartTotalPriceViewModel();
            model.TotalPrice = totalPrice;
            model.CartId = cartId;
            await _cartService.UpdateCart(model);
            var result = await _paymentService.RequestZarin(totalPrice,cartId);
            if(result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Authority);
            }
            else
            {
                return BadRequest();
            }

        }

        public  IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
               HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
               HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                return RedirectToAction("Validate", new {id,authority});

            }
            else
            {
                return View("ValidateFail");
            }

            
        }

        public async Task<IActionResult> Validate(int id,string authority)
        {
            int totalPrice = await  _cartService.GetCartTotalPriceByCartId(id);
            var result =  await _paymentService.VerificationZarin(authority,totalPrice);
            if(result.Status == 100)
            {
                var res = await _cartService.FinalizingCart(id);
                if (res)
                {
                    ViewBag.Code = result.RefId;
                    return View();
                }
                else
                {
                    return NotFound();
                }
               
            }
            else
            {
                return View("ValidateFail");
            }

        }
    }
}

using Main.Domain.Models.Cart;
using Main.Domain.ViewModel.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface ICartService
    {
        Task<List<CartViewModel>> AddItem(CartViewModel model);
        Task<List<CartViewModel>> AddItemForFirstTime(CartViewModel model);
        Task<List<CartViewModel>> GetCartByUserId(int id);
        Task<int> GetCartIdByUserId(int id);
        Task<int> GetCartTotalPriceByCartId(int id);
        Task<bool> FinalizingCart(int id); //this is cart id
        Task<bool> DeleteItem(CartViewModel model);
        Task<bool> UpdateCart(CartTotalPriceViewModel model);
        Task<bool> UpdateCartItems(CartViewModel model);
        Task<bool> Save();
    }
}

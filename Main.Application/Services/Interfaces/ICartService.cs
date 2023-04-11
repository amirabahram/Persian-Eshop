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
        Task<List<CartItemViewModel>> AddItem(CartItemViewModel model);
        Task<bool> DeleteItem(CartItemViewModel model);
        Task<bool> Save();
    }
}

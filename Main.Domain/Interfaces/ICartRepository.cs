using Main.Domain.Models.Cart;
using Main.Domain.Models.CartProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface ICartRepository
    {
        
        Task InsertCart(Cart cart);
        Task InsertCartDetails(CartDetails  cartDetails);
        void UpdateCart(Cart cart);
        void UpdateCartDetails(CartDetails cartDetails);
        Task Save();

    }
}

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

        Task <List<CartDetails>> GetAllProductsByCart(int id);
        Task<Cart> GetCartByCartId(int id);
        Task InsertCart(Cart cart);
        Task InsertCartDetails(CartDetails  cartDetails);
        Task<Cart> UnpaidCartForUser(int userId);
        //Task<bool> IsProductExistsForCart(int cartId,int productId);

        Task<CartDetails> GetDetailsByCartIdAndProductId(int id, int productId);
        void UpdateCart(Cart cart);
        void UpdateCartDetails(CartDetails cartDetails);
        Task Save();

    }
}

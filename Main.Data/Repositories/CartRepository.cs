using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.Cart;
using Main.Domain.Models.CartProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class CartRepository:ICartRepository
    {
        private readonly EshopContext _db;
        public CartRepository(EshopContext db)
        {
            this._db = db;
        }

        public async Task InsertCart(Cart cart)
        {
            await _db.Carts.AddAsync(cart);
        }

        public  Task InsertCartDetails(CartDetails cartDetails)
        {
            throw new NotImplementedException();
        }

        public  Task Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void UpdateCartDetails(CartDetails cartDetails)
        {
            throw new NotImplementedException();
        }
    }
}

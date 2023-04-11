using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.Cart;
using Main.Domain.Models.CartProduct;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<CartDetails>> GetAllProductsByCart(int id)
        {
           return await _db.CartDetailsEntity.Include(c=>c.Cart).Where(c=> c.CartId == id && c.IsDelete==false).ToListAsync();
        }

        public async Task InsertCart(Cart cart)
        {
            await _db.Carts.AddAsync(cart);
        }

        public  async Task InsertCartDetails(CartDetails cartDetails)
        {
            await _db.CartDetailsEntity.AddAsync(cartDetails);
        }

        public async Task<bool> IsProductExistsForCart(int cartId,int productId)
        {
            return await _db.CartDetailsEntity.AnyAsync(c => c.IsDelete == false && c.CartId == cartId && c.ProductId == productId);
        }

        public  async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Cart> UnpaidCartForUser(int id)
        {
            return await _db.Carts.FirstOrDefaultAsync(c => c.UserId == id && c.IsPaid == false);
        }

        public void UpdateCart(Cart cart)
        {
            _db.Update(cart);
        }

        public void UpdateCartDetails(CartDetails cartDetails)
        {
            _db.Update(cartDetails);
        }
    }
}

using Main.Domain.Models.Common;
using Main.Domain.Models.User;
using Main.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.Cart
{
    public class Cart:BaseEntity
    {
        
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public bool IsPaid { get; set; }
        public UserEntity User { get; set; }
        public ICollection<CartProduct.CartDetails> CartDetails { get; set; }

    }
}

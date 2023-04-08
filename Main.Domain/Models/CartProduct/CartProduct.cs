using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.CartProduct
{
    public class CartProduct:BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        public Cart.Cart Cart { get; set; }
        public Product.Product Product { get; set; }    
    }
}

using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.CartProduct
{
    public class CartDetails:BaseEntity
    {
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int ProductTotalPriceAfterDiscount { get; set; }
        public int OrderCount { get; set; }
        public Cart.Cart Cart { get; set; }
        public Product.Product Product { get; set; }    
    }
}

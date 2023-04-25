using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Cart
{
    public class CartViewModel
    {
        public int? ProductId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int TotalPrice { get; set; }
        public string ProductTitle { get; set; }
        public int ProductOrderCount { get; set; }
        public bool IsDelete { get; set; }
        public int ProductPrice { get; set; }
        public string? ImageName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Cart
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string  ItemPrice { get; set; }
        public string? PropertyTitle  { get; set; }
        public string? PropertyValue  { get; set; }
        public string? OrderCount  { get; set; }
        public string? DiscountPrice  { get; set; }
        public string? ImageName  { get; set; }
        public string? ProductTitle  { get; set; }
        public int TotalProductPrice  { get; set; }
        public bool IsDelete { get; set; }
        public bool IsPaid { get; set; }
    }
}

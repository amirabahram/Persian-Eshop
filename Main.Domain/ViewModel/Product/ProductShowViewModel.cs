using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Product
{
    public class ProductShowViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, string>? Properties { get; set; } = new Dictionary<string, string>();
        public string? MainImage { get; set; }
        public List<string>? Images { get; set; } = new List<string>();
        public int Count { get; set; }
        public int Price { get; set; }
    }
}

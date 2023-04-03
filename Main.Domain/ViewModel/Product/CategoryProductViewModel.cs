using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Product
{
    public class CategoryProductViewModel
    {
        public CategoryViewModel Category { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

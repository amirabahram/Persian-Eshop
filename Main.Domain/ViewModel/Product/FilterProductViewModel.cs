using Main.Domain.Models.BasePaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Main.Domain.ViewModel.Filtering
{
    public class FilterProductViewModel : BasePaging<Main.Domain.Models.Product.Product>
    {
        public string? Title { get; set; }
        public string? CategoryTitle { get; set; }
        public string? MinPrice { get; set; } 
        public string? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        
        public int? CategoryPropertiesId { get; set; }

    }
}

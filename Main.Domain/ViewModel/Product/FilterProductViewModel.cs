using Main.Domain.Models.Base_Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Filtering
{
    public class FilterProductViewModel:BasePaging<Main.Domain.Models.Product.Product>
    {
        public string? Title;
        public int? MinPrice=0;
        public int? MaxPrice;
        public int? CategoryId;
        public int? CategoryPropertiesId;

    }
}

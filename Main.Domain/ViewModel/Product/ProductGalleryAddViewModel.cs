using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Product
{
    public class ProductGalleryAddViewModel
    {
        public int ProductId { get; set; } 
        public List<IFormFile>? InputImages {get;set;}

    }
}

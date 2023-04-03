using Main.Domain.Models.Product_Image_Gallery;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Product
{
    public class ProductGalleryViewModel
    {
        public IFormFile GalleryImage { get; set; }
        public List<string>? Pictures { get; set; }
    }
}

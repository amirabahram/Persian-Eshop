using Main.Domain.Models.Category;
using Main.Domain.Models.Product_Image_Gallery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Main.Domain.ViewModel.Product
{
    public  class ProductViewModel
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50,ErrorMessage = "حداکثر کاراکتر برای {0} 50 کاراکتر بیشتر نیست")]
        public string? Title { get; set; }
        [MaxLength(350, ErrorMessage = "حداکثر کاراکتر برای {0} 350 کاراکتر بیشتر نیست")]
        [DisplayName("توضیحات")]
        public string? Description { get; set; }


        [DisplayName("قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int? Price { get; set; }= 0;

        [DisplayName("عکس")]
        public IFormFile? MainImage { get; set; }

        public bool IsActive { get; set; }


        [DisplayName("تعداد")]
        public int? Count { get; set; } = 0;
            
        public int? CategoryId { get; set; }

        
        public List<IFormFile>? GalleryImages { get; set; }

        public List<Category>? Categories { get; set; }
    }
    public enum CreateProductResult
    {
        Success,
        Failure
    }
}

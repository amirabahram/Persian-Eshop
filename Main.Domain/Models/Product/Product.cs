
using Main.Domain.Models.Category;
using Main.Domain.Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.Product
{
    public class Product: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("عنوان")]
        public string? Title { get; set; }
        [MaxLength(350)]
        [DisplayName("توضیحات")]
        public string? Description { get; set; }


        [DisplayName("قیمت")]
        [Required]
        public int? Price { get; set; }

        [MaxLength(50)]
        [DisplayName("عکس")]
        public string? MainImage { get; set; }


        public bool IsActive { get; set; }


        [DisplayName("تعداد")]
        public int? Count { get; set; }

        public List<Product_Image_Gallery.ProductImageGallery>? productImageGalleries { get; set; }
       
        [ForeignKey("CategoryId")]//recommended
        public int? CategoryId { get; set; }
        public Category.Category? Category { get; set; }// chonke Yek product fagat yek Category mitavanad dashte bashad! pas list nist.
        
        public ICollection<CartProduct.CartProduct> CartProducts { get; set; }

        public List<ProductProperties.ProductProperties> Properties { get; set; }



    }
}


using Main.Domain.Models.Category;
using Main.Domain.Models.Common;

using System;
using System.Collections.Generic;
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
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }
        public int Price { get; set; }
        [MaxLength(50)]
        public string MainImage { get; set; }
        public int Count { get; set; }

        public List<Product_Image_Gallery.ProductImageGallery>? productImageGalleries { get; set; }
       
        [ForeignKey("CategoryId")]//recommended
        public int? CategoryId { get; set; }
        public Category.Category? Category { get; set; }// chonke Yek product fagat yek Category mitavanad dashte bashad! pas list nist.
        
    



    }
}

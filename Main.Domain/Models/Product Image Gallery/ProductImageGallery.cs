using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.Product_Image_Gallery
{
    public class ProductImageGallery : BaseEntity
    {
        public String? ImageName { get; set; }
        [ForeignKey("ProductId")] //recommended
        public int? ProductId { get; set; }
        public Product.Product? Product { get; set; }
    }
}

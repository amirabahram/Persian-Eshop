using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.ProductProperties
{
    public class ProductProperties:BaseEntity
    {
        [ForeignKey("Category")] //Foreign Key Agar balaye ID bashad bayad name Navigation Property ra behesh bedim va agar balaye Navigation bashad bayad ID rabehesh bedim
        public int PropertyId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product.Product Product { get; set; }    
        public CategoryProperties.CategoryProperties Category  { get; set; }
    }
}

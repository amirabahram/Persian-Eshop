using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.CategoryProperties
{
    public  class CategoryProperties:BaseEntity
    {

        public string Title { get; set; }

        public string PropertyValue { get; set; }

        [ForeignKey("CategoryId")]//recommended
        public int CategoryId { get; set; }
        public Category.Category? Category { get; set; }

        public List<ProductProperties.ProductProperties> ProductProperties { get; set; } // List az jadvale vaset:chon rabete chand be chand ba product darad

    }
}

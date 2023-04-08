using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Main.Domain.Models.Category
{
    public class Category: BaseEntity
    {
        [MaxLength(50)]
        [DisplayName("عنوان")]
        [Required(ErrorMessage ="وارد کردن عنوان اجباری می باشد!")]
        public string Title { get; set; }
        [ForeignKey("CategoryParent")]
        public int? ParentId { get; set; }
        public Category? CategoryParent { get; set; }

        public List<Product.Product>? Products { get; set; } // List: because 1 Category can have many Products
        public List<CategoryProperties.CategoryProperties> categoryProperties { get; set; }
    }

    public enum UpdateCategoryResult
    {
        Success,
        Failed,
        DuplicatedCategory,
        CategoryNotFound
    }
}

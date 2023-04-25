using Main.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Product
{
    public class PropertyViewModel
    {
        [Required(ErrorMessage = "فیلد اجباری")]
        [MaxLength(50)]
        [DisplayName("عنوان")]

        public string Title { get; set; }
        [Required(ErrorMessage = "فیلد اجباری")]
        [MaxLength(50)]
        [DisplayName("مقدار عنوان")]
        public string Value { get; set; }
        [Required(ErrorMessage = "فیلد اجباری")]
        public int CategoryId { get; set; }

        public string? Category { get; set; }

        public int PropertyId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel
{
    public class UpdateFaqViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "لطفا معتبر باشد")]
        public string Question { get; set; }
        [Required(ErrorMessage ="لطفا معتبر باشد")]
        public string Answer { get; set; }
         
    }
    public enum UpdateFaqResult
    {
        Success,
        FaqNotFound,
        DuplicatedQuestion
    }
}

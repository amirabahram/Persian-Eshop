using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.User
{
    public class GetEmailViewModel

    {

        [Required(ErrorMessage = "این فیلد اجباریست ")]
        public string Email { get; set; }
    }
}

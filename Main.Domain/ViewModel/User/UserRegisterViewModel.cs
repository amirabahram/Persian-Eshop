using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.User;

namespace Main.Domain.ViewModel.User
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="ایمیل اجباری می باشد")]
        public string  Email{ get; set; }
        [Required(ErrorMessage ="فیلد نام اجباری می باشد")]
        public string Password { get; set; }
        [Required(ErrorMessage ="فیلد تکرار پسوورد اجباری می باشد")]
        [Compare("Password", ErrorMessage ="پسوورد با تکرارپسسورد مطابقت نداشت!")]
        public string RePassword { get; set; }

    }
    public enum RegisterUserResult ///we buil a type!!
    {
        Success,
        EmailDuplicated,
        Empty,
        PasswrordAndRepasswordDoesNotMatch
    }
}

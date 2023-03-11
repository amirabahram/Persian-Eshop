using System.ComponentModel.DataAnnotations;

namespace Main.Domain.ViewModel.User
{
    public class ForgotPasswordViewModel
    {
        public string ActivationCode { get; set; }
      
        [Required(ErrorMessage = "فیلد پسورد اجباری می باشد ")]
        public string Newpassword { get; set; }


        [Required(ErrorMessage = "فیلد تکرار پسوورد اجباری می باشد")]
        [Compare("Newpassword", ErrorMessage = "پسوورد با تکرارپسسورد مطابقت نداشت!")]

        public string NewRepassword { get; set; }


        [Required(ErrorMessage = "فیلد ایمیل تکراری می باشد ")]
        public string Email { get; set; }

        public enum ResualtForgatPassword
        {
            Success,
            Empty,
            PasswrordAndRepasswordDoesNotMatch


        }

    }


}

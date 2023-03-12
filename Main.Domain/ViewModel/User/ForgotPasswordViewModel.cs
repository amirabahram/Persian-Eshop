using System.ComponentModel.DataAnnotations;

namespace Main.Domain.ViewModel.User
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "فیلد پسورد اجباری می باشد ")]
        public string Newpassword { get; set; }


        [Required(ErrorMessage = "فیلد تکرار پسوورد اجباری می باشد")]
        [Compare("Newpassword", ErrorMessage = "پسوورد با تکرارپسسورد مطابقت نداشت!")]

        public string NewRepassword { get; set; }

        //public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }

        //public string? AvatarName { get; set; }
        //public string? Name { get; set; }
        //public string? Family { get; set; }
        //public bool? IsAdmin { get; set; }
        //public bool? IsActive { get; set; }
        //public string? ActivitationCode { get; set; }
        //public bool? IsDelete { get; set; }
    }


}

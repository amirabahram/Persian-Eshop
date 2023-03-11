using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Main.Domain.ViewModel.User
{
    public class UserChangePassword
    {
        
        [Required(ErrorMessage ="این فیلد اجباری است!")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است!")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است!")]
        [Compare("NewPassword",ErrorMessage ="تکرار رمز عبور با خودرمزمطابقت ندارد!")]
        public string ReNewPassword { get; set; }
    }
    public enum PasswordChangeResult
    {
        Success,
        Failed,
        OldPasswordIsNotCorrect
    }
}

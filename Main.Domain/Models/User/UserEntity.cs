using Main.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Models.User
{
    public class UserEntity : BaseEntity
    {
        [Display(Name = "نام")]
        [MaxLength(250, ErrorMessage = "{0} نام نمایشی نباید بیشتر از {1} باشد")]///0--> Name ,,,1-->Lenght
        public string? Name { get; set; }

        
        [Display(Name = "نام خانوادگی")]
        [MaxLength(250, ErrorMessage = "{0} نام نمایشی نباید بیشتر از {1} باشد")]
        public string? Family { get; set; }

        [MaxLength(250)]
        public string? AvatarName { get; set; }

        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید")]
        [MaxLength(250)]
        //////[EmailAddress()]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "ایمیل شما معتبر نمیباشد")]
        public string Email { get; set; }
        [Display(Name = "شماره تلفن")]
        [MaxLength(250)]
        [RegularExpression("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$",
        ErrorMessage = "شماره تلفن شما معتبر نمیباشد")]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(250)]
        public bool? IsAdmin { get; set; }

        public string? ActivitationCode { get; set; }

        public bool? IsActive { get; set; }

        public Cart.Cart Cart { get; set; }

    }
}

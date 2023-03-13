using Main.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Models.User
{
    public class UserEntity : BaseEntity
    {
        [Display(Name = "نام")]
        [MaxLength(250, ErrorMessage = "{0} نام نمایشی نباید بیشتر از {1} باشد")]
        public string? Name { get; set; }

        [MaxLength(250)]
        public string? Family { get; set; }

        [MaxLength(250)]
        public string? AvatarName { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(250)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(250)]
        public bool? IsAdmin { get; set; }

        public string? ActivitationCode { get; set; }

        public bool? IsActive { get; set; }

    }
}

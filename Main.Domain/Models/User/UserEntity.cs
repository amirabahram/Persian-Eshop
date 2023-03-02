using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.Common;

namespace Main.Domain.Models.User
{
    public class UserEntity:BaseEntity
    {
        //[Required]
        [MaxLength(250)]

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
        public string? PhoneNumber { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [MaxLength(250)]
        public bool?   IsAdmin { get; set; }
        
        [MaxLength(250)]
        public string? ActivitationCode { get; set; }
        public bool?   IsActive { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.ViewModel.Admin
{
    public class CreateAdminViewModel
    { 
        public string Name { get; set; }

        public string Family { get; set; }


        public string AvatarName { get; set; }

        public string Email { get; set; }


        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public string ActivitationCode { get; set; }
        public bool IsActive { get; set; }

    }
    public enum Gender
    {
        Male,
        Female
    }
}

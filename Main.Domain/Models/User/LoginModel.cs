using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.User
{
    public  class LoginModel:BaseEntity
    {
        
        public string Email { get; set; }

        
        public string Password { get; set; }


        public bool RemmberMe { get; set; }

    }
}

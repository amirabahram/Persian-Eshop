﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.User;

namespace Main.Domain.ViewModel.User
{
    public class UserRegisterViewModel
    {
        public string  Email{ get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public enum result
        {
            Success,
            IsDuplicated,
            Failed
        }
    }
}

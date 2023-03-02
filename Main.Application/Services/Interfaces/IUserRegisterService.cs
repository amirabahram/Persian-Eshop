using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.ViewModel.User;

namespace Main.Application.Services.Interfaces
{
    public interface IUserRegisterService
    {
        
        public bool Insert(UserRegisterViewModel regModel);
        public bool PasswordCheck();
    }
}

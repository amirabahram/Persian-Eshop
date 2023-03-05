using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.User;


namespace Main.Application.Services.Interfaces
{
    public interface IUserRegisterService
    {
        bool ActiveUser(string activationCode);
        public RegisterUserResult Register(UserRegisterViewModel regModel);
        public bool PasswordCheck();


        #region LoginViewModel
        //UserEntity GetuserViewModel(string email, string password);
        bool IsExistUser(string email, string password);
        #endregion

    }
}

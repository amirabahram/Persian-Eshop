using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.ViewModel.User;
using Main.Domain.Models.User;

namespace Main.Application.Services.Implementations
{
    public class UserRegisterService : IUserRegisterService
    {
        private IRegisterRepository _regRepo;

        public UserRegisterService(IRegisterRepository UserRepo)
        {
            _regRepo = UserRepo;
        }

        public bool Insert(UserRegisterViewModel regModel)
        {

            if(regModel == null)
            {

                return false;
            }

            if(_regRepo.IsDuplicated(regModel.Email)) return false;

            var registerModel = new UserEntity()
            {
                Email = regModel.Email,
                Password = regModel.Password,
            
            };
            _regRepo.Insert(registerModel);
            _regRepo.SaveChanges();
            return true;

        }



        public bool PasswordCheck()
        {
            throw new NotImplementedException();
        }
    }
}

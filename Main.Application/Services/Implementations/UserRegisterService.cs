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
        private IEmailSender        _emailSender;

        public UserRegisterService(IRegisterRepository UserRepo,IEmailSender emailSender)
        {
            _regRepo = UserRepo;
            _emailSender = emailSender;
        }
        public RegisterUserResult Register(UserRegisterViewModel regModel)
        {

            if(regModel == null)
            {

                return RegisterUserResult.Empty;
            }


            if(_regRepo.IsDuplicated(regModel.Email)) return RegisterUserResult.EmailDuplicated;
            if (regModel.Password != regModel.RePassword) return RegisterUserResult.PasswrordAndRepasswordDoesNotMatch;
            var registerModel = new UserEntity()
            {
                Email = regModel.Email,
                Password = regModel.Password,
            
            };
            string code = Guid.NewGuid().ToString(); //Generates 16 digits Random number
            registerModel.ActivitationCode = code;
            _regRepo.Insert(registerModel);
            _regRepo.SaveChanges();
            _emailSender.EmailSending(registerModel.Email, "Eshop Email Vertification"
                ,$"<a href='https://localhost:7049/SubmittDone/{code}'> لطفا روی این لینک کلیک کنید</a>");
            
            return RegisterUserResult.Success;

        }

        public bool ActiveUser(string activationCode)
        {
            var user = _regRepo.GetUserByActivationCode(activationCode);
            if(user == null)
            {
                 return false;
            }
            user.IsActive = true;
            user.ActivitationCode = Guid.NewGuid().ToString();
            _regRepo.UpdateUser(user);
            _regRepo.SaveChanges();
            return true;
        }

        public bool PasswordCheck()
        {
            throw new NotImplementedException();
        }
    }
}

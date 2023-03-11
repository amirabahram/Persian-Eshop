using Main.Application.Security;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using Main.Domain.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IEmailSender _emailSender;

        public UserService(IUserRepository adminRepo, IEmailSender emailSender)
        {
            this._userRepository = adminRepo;
            this._emailSender = emailSender;
        }

        public async Task Delete(int id)    /////////note ---> ino task kardam!
        {
            UserEntity user = await _userRepository.GetUserForEditById(id);
            user.IsDelete = true;
            _userRepository.Update(user);
            await _userRepository.Save();

        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<bool> Insert(CreateAdminViewModel createAdminView)
        {
            if (createAdminView == null) return false;

            var newUser = new UserEntity()
            {
                Name = createAdminView.Name,
                Email = createAdminView.Email,
                ActivitationCode = createAdminView.ActivitationCode,
                AvatarName = createAdminView.AvatarName,
                Family = createAdminView.Family,
                CreateDate = DateTime.Now,
                IsActive = createAdminView.IsActive,
                IsAdmin = createAdminView.IsAdmin,
                Password = Hash.EncodePasswordMd5(createAdminView.Password),
                PhoneNumber = createAdminView.PhoneNumber
            };

            await _userRepository.Insert(newUser);
            await _userRepository.Save();
            return true;
        }

        public async Task<UpdateAdminViewModel> ShowUserForEdit(int id)
        {
            var updUser = await _userRepository.GetUserForEditById(id);
            if (updUser == null) return null;
            return new UpdateAdminViewModel
            {
                Name = updUser.Name,
                Email = updUser.Email,
                AvatarName = updUser.AvatarName,
                Family = updUser.Family,
                IsAdmin = updUser.IsAdmin,
                Password = updUser.Password,
                PhoneNumber = updUser.PhoneNumber
            };

        }

        public async Task<UpdateUserResult> Update(UpdateAdminViewModel upd)
        {
            UserEntity user = await _userRepository.GetUserForEditById(upd.Id);
            if (user == null) return UpdateUserResult.UserNotFound;

            user.Name = upd.Name;
            user.AvatarName = upd.AvatarName;
            user.Family = upd.Family;
            user.IsActive = upd.IsActive;
            user.IsAdmin = upd.IsAdmin;
            user.Password = Hash.EncodePasswordMd5(upd.Password);
            user.PhoneNumber = upd.PhoneNumber;
            bool res = _userRepository.Update(user);
            await _userRepository.Save();
            if (res)
            {
                
                return UpdateUserResult.Success;
            }
            else
            {
                return UpdateUserResult.Failed;
            }
            
        }


        public bool ActiveUser(string activationCode)
        {
            var user = _userRepository.GetUserByActivationCode(activationCode);
            if (user == null)
            {
                return false;
            }
            user.IsActive = true;
            user.ActivitationCode = Guid.NewGuid().ToString();
            _userRepository.UpdateUser(user);
            _userRepository.Save();
            return true;
        }

        public bool PasswordCheck()
        {
            throw new NotImplementedException();
        }


        #region Login

        //public UserEntity GetuserViewModel(string email, string password)
        //{
        //     return _userRepository.GetUserForLogin(email, password.ToLower());


        //}

        public UserEntity IsExistUser(string email, string password)
        {
            return _userRepository.IsExistUser(email.Trim().ToLower(), Hash.EncodePasswordMd5(password));
        }


        #endregion

        #region ForgatPassword

        public bool checkEmail(string email)
        {
            var checkemail = _userRepository.IsUserExistByEmail(email);
            if (checkemail == false)
            {
                return false;
            }
            return true;
        }

        public bool checkActive(string active)
        {
            var user = _userRepository.GetUserByActivationCode;
            if (user != null)
            {

                return true;
            }

            return false;
        }

        //public bool forgatpassword(ForgatPassword user)
        //{
        //    if (user.Newpassword==null)
        //    {
        //        var n = new UserEntity();

        //        n.Password = user.Newpassword;

        //        return n;

        //    }
        //    return false;


        //}


        public bool forgatPassword(string email)
        {
            var user = _userRepository.GetUserBayEmail(email);


            if (user != null)
            {
                var activeCode = user.ActivitationCode;



                var sendEmail = _emailSender.EmailSending(email, "forgatpassword", $"<a href='https://localhost:7049/SubmittDone/{activeCode}'> لطفا روی این لینک کلیک کنید</a>");
                return true;

            }
            return false;


        }

        public RegisterUserResult Register(UserRegisterViewModel regModel)
        {
            if (regModel == null)
            {

                return RegisterUserResult.Empty;
            }


            if (_userRepository.IsDuplicated(regModel.Email)) return RegisterUserResult.EmailDuplicated;
            if (regModel.Password != regModel.RePassword) return RegisterUserResult.PasswrordAndRepasswordDoesNotMatch;
            var registerModel = new UserEntity()
            {
                Email = regModel.Email,
                Password = Hash.EncodePasswordMd5(regModel.Password),

            };
            string code = Guid.NewGuid().ToString(); //Generates 16 digits Random number
            registerModel.ActivitationCode = code;
            _userRepository.Register(registerModel);
            _userRepository.Save();
            _emailSender.EmailSending(registerModel.Email, "Eshop Email Vertification"
                , $"<a href='https://localhost:7049/SubmittDone/{code}'> لطفا روی این لینک کلیک کنید</a>");

            return RegisterUserResult.Success;
        }

        public async Task<string> GetPasswordById(int id)
        {
            UserEntity user= await _userRepository.GetUserForEditById(id);
            return user.Password;
        }

        public async Task<bool> UpdatePassword(string newPassword,int id)
        {
            UserEntity user = await _userRepository.GetUserForEditById(id);
            if (user == null) return false;
            user.Password = Hash.EncodePasswordMd5(newPassword);
            await _userRepository.Save();
            return true;
        }


        #endregion





    }
}

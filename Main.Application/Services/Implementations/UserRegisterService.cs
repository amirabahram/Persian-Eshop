﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.ViewModel.User;
using Main.Domain.Models.User;
using Main.Application.Security;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.WebRequestMethods;

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


        #region Login

        //public UserEntity GetuserViewModel(string email, string password)
        //{
        //     return _regRepo.GetUserForLogin(email, password.ToLower());
          
            
        //}

        public bool IsExistUser(string email, string password)
        {
            return _regRepo.IsExistUser(email.Trim().ToLower(),Hash.EncodePasswordMd5(password));
        }


        #endregion

        #region ForgatPassword

        public bool checkEmail(string email)
        {
            var checkemail=_regRepo.IsUserExistByEmail(email);
            if(checkemail == false)
            {
                return false;
            }
            return true;
        }

        public bool checkActive(string active)
        {
            var user = _regRepo.GetUserByActivationCode;
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
            var user = _regRepo.GetUserBayEmail(email);


            if (user != null)
            {
                var activeCode = user.ActivitationCode;



                var sendEmail = _emailSender.EmailSending(email, "forgatpassword", $"<a href='https://localhost:7049/SubmittDone/{activeCode}'> لطفا روی این لینک کلیک کنید</a>");
                return true;
               
            }
            return false;
            

        }


        #endregion
    }
}

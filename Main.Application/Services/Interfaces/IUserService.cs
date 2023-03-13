using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using Main.Domain.ViewModel.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region AdminCRUD
        Task<List<UserEntity>> GetAllUsers();
        Task<UpdateAdminViewModel> ShowUserForEdit(int id);
        Task<bool> Insert(CreateAdminViewModel createAdminView);
        Task Delete(int id);
        Task<UpdateUserResult> Update(UpdateAdminViewModel upd);
        #endregion


        #region UserRegister
        bool ActiveUser(string activationCode);
        public RegisterUserResult Register(UserRegisterViewModel regModel);
        public bool PasswordCheck(); 
        #endregion


        #region LoginViewModel
        //UserEntity GetuserViewModel(string email, string password);
        UserEntity IsExistUser(string email, string password);
        #endregion

        #region ChangePassword
        Task<string> GetPasswordById(int id);
        Task<bool> UpdatePassword(string newPassword,int id);
        #endregion

        #region forgatpassword

        public bool checkEmail(string email);
        public bool forgatPassword(string email);

        //  public bool checkActive(string active);





        #endregion

        #region UploadImage
        Task<bool> UploadImageByUser(IFormFile image,int id); 
        Task<string> GetAvatarNameById(int id);
        #endregion


    }
}

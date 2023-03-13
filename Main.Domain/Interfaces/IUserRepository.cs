using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserForEditById(int id);
        Task Insert(UserEntity user);
        bool Update(UserEntity user);
        Task Save();

        void Register(UserEntity user);

        bool IsDuplicated(string email);

        UserEntity GetUserByActivationCode(string activationCode);

        void UpdateUser(UserEntity user);

        #region login

        bool IsUserExistByEmail(string email);

        UserEntity IsExistUser(string email, string password);

        #endregion


        #region forgatpassword

        UserEntity GetUserBayEmail(string email);
        bool ActivectionCode(string activationCode);
 

        #endregion



    }
}

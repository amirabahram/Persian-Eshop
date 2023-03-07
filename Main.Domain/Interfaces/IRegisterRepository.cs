using Main.Domain.Models.User;

namespace Main.Domain.Interfaces
{
    public interface IRegisterRepository
    {
        void Insert(UserEntity user);

        bool IsDuplicated(string email);

        UserEntity GetUserByActivationCode(string activationCode);

        void UpdateUser(UserEntity user);

        #region login

        bool IsUserExistByEmail(string email);

        bool IsExistUser(string email, string password);

        #endregion


        #region forgatpassword

        UserEntity GetUserBayEmail (string email);

        #endregion

        void SaveChanges();
    }
}

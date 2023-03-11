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

      //  UserEntity GetEmail(string email, string password);
        #endregion


        #region forgatpassword

        UserEntity GetUserBayEmail (string email);

        bool ActivactionCod(string activationCode);
     
        //bool GetNewPassword()

        #endregion

        void SaveChanges();
    }
}

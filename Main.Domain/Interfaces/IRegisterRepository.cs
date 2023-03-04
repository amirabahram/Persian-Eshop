using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.User;

namespace Main.Domain.Interfaces
{
    public interface IRegisterRepository
    {
        void Insert(UserEntity user);
        bool IsDuplicated(string email);
        UserEntity GetUserByActivationCode(string activationCode);
        void UpdateUser(UserEntity user);
        void SaveChanges();
    }
}

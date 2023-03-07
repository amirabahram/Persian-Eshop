using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IAdminEditRepository
    {
        Task<List<UserEntity>> GetAllUsers();
        Task<UserEntity> GetUserForEditById(int id);
        Task Insert(UserEntity user);
        bool Update(UserEntity user);
        Task Save();
    }
}

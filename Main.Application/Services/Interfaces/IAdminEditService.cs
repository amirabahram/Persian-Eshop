using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IAdminEditService
    {
        Task<List<UserEntity>> GetAllUsers();
        Task<UpdateAdminViewModel> ShowUserForEdit(int id);
        Task<bool> Insert(CreateAdminViewModel createAdminView);
        Task Delete(int id);
        Task<UpdateUserResult> Update(UpdateAdminViewModel upd);

    }
}

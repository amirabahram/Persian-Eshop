using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class AdminEditService : IAdminEditService
    {
        private IAdminEditRepository _adminRepo;

        public AdminEditService(IAdminEditRepository adminRepo)
        {
            this._adminRepo = adminRepo;
        }

        public async Task Delete(int id)    /////////note ---> ino task kardam!
        {
            UserEntity user = await _adminRepo.GetUserForEditById(id);
            user.IsDelete = true;
            _adminRepo.Update(user);
            await _adminRepo.Save();

        }

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await _adminRepo.GetAllUsers();
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
                Password = createAdminView.Password,
                PhoneNumber = createAdminView.PhoneNumber
            };

            await _adminRepo.Insert(newUser);
            await _adminRepo.Save();
            return true;
        }

        public async Task<UpdateAdminViewModel> ShowUserForEdit(int id)
        {
            var updUser = await _adminRepo.GetUserForEditById(id);
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
            UserEntity user = await _adminRepo.GetUserForEditById(upd.Id);
            if (user == null) return UpdateUserResult.UserNotFound;

            user.Name = upd.Name;
            user.AvatarName = upd.AvatarName;
            user.Family = upd.Family;
            user.IsActive = upd.IsActive;
            user.IsAdmin = upd.IsAdmin;
            user.Password = upd.Password;
            user.PhoneNumber = upd.PhoneNumber;
            bool res = _adminRepo.Update(user);
            await _adminRepo.Save();
            if (res)
            {
                
                return UpdateUserResult.Success;
            }
            else
            {
                return UpdateUserResult.Failed;
            }
            
        }

    }
}

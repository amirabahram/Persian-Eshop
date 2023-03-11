using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.User;
using Main.Domain.ViewModel.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EshopContext db;

        public UserRepository(EshopContext dbContext)
        {
            this.db = dbContext;
        }
        

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await db.Users.Where(q=> q.IsDelete==false).ToListAsync();
        }

        public async Task<UserEntity> GetUserForEditById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(UserEntity user)
        {
            await db.Users.AddAsync(user);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        public bool Update(UserEntity user)
        {
            db.Users.Update(user);
            return true;
        }

        public UserEntity GetUserByActivationCode(string activationCode)
        {
            return db.Users.FirstOrDefault(q => q.ActivitationCode == activationCode);
        }

        #region Login 



        public UserEntity IsExistUser(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }


        #endregion

        public void Register(UserEntity user)
        {
            db.Users.Add(user);
        }

        public bool IsDuplicated(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }



        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void UpdateUser(UserEntity user)
        {
            db.Users.Update(user);
        }

        #region ForgatPassword
        public bool checkeUser(string email)
        {
            return db.Users.Any(u => u.Email == email);

        }

        public bool IsUserExistByEmail(string email)
        {
            return db.Users.Any(u => u.Email == email);
        }

        public UserEntity GetUserBayEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        #region activation

       
        public bool ActivactionCod(string activationCode)
        {
            return db.Users.Any(u=>u.ActivitationCode==activationCode);

        }
        #endregion





        #endregion


    }
}

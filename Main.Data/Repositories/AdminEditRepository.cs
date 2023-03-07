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
    public class AdminEditRepository : IAdminEditRepository
    {
        private readonly EshopContext db;

        public AdminEditRepository(EshopContext dbContext)
        {
            this.db = dbContext;
        }
        

        public async Task<List<UserEntity>> GetAllUsers()
        {
            return await db.Users.Where(q=>!q.IsDelete).ToListAsync();
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

    }
}

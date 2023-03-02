﻿using Main.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Interfaces;
using Main.Domain.Models.User;

namespace Main.Data.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly EshopContext db;
        public RegisterRepository(EshopContext context)
        {
            db = context;
        }

        public void Insert(UserEntity user)
        {
            db.Users.Add(user);
        }

        public bool IsDuplicated(string email)
        {
            return  db.Users.Any(u => u.Email == email);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

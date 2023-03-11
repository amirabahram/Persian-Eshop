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

        public UserEntity GetUserByActivationCode(string activationCode)
        {
            return db.Users.FirstOrDefault(q => q.ActivitationCode == activationCode);
        }

        #region Login 



        public bool IsExistUser(string email, string password)
        {
            return db.Users.Any(u => u.Email == email && u.Password == password);

        }


        #endregion

        public void Insert(UserEntity user)
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

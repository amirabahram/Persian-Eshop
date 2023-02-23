using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.AboutUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{ 
    
    public class AboutUsRepository : IAboutUsInterface
    {

        //!CreateDataBase 
        #region CreateDataBase
        private readonly EshopContext _dbContext;

        public AboutUsRepository(EshopContext dbcontext)
        {
            
                this._dbContext = dbcontext;
           
        }

        #endregion



        #region Impleminet_Interface

        public void AddAboutUs(AboutUsModel aboutUs)
        {
         
            _dbContext.AboutUs.Add(aboutUs);
           
        }

        //public void DetetAboutUs(AboutUsModel aboutUs)
        //{
        //    throw new NotImplementedException();
        //}

        public void EditAboutUs(AboutUsModel aboutUs)
        {
            _dbContext.Update(aboutUs); 
        }

        public AboutUsModel GetAboutUs(int Id)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
        #endregion



    }
}

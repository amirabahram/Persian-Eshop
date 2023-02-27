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
    
    public class AboutUsRepository : IAboutUsRepository
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

        public AboutUsModel GetAboutUs(int id)
        {
            return _dbContext.AboutUs.FirstOrDefault(a => a.Id == id);
        }

        public List<AboutUsModel> GetAll()
        {
            //list aboutus 
            return _dbContext.AboutUs.Where(a=>!a.IsDelete).ToList();
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }
        #endregion



    }
}

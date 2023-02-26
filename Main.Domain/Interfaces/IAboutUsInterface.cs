using Main.Domain.Models.AboutUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IAboutUsInterface
    {
        // list as AboutUsModel
       
        List<AboutUsModel> GetAll();

        //aboutus id as model 
        AboutUsModel GetAboutUs(int Id);
        void AddAboutUs(AboutUsModel aboutUs);  

        void EditAboutUs(AboutUsModel aboutUs); 
        
       // void DetetAboutUs(AboutUsModel aboutUs);    

        

        
        void save();
        


    }
}

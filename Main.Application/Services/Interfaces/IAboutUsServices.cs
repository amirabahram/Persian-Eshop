using Main.Domain.Models.AboutUs;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Main.Application.Services.Interfaces
{
    public interface IAboutUsServices
    { 
        /// <summary>
        ///crud About Us
       
        /// </summary>
        /// <returns></returns>
        List<AboutUsModel> GetAllAboutUs();
       
      
        /// copy  All Interface Domin 
       
        EditAboutUsViewModel GetAboutUsforEdit(int Id);

        bool AddAboutUs(CreateAboutUsViewModel aboutUs, IFormFile img);


        EditAboutUsResualt EditAboutUs(EditAboutUsViewModel aboutUs, IFormFile img);

        /// <summary>
        /// Soft Delet About us  
        /// </summary>
        bool DeleteAboutUS(int id);


    }
}

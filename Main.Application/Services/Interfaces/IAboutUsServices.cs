using Main.Domain.Models.AboutUs;
using Main.Domain.ViewModel.AboutUs;
using System.Reflection;

namespace Main.Application.Services.Interfaces
{
    public interface IAboutUsServices
    {
       List<AboutUsModel> GetAllAboutUs();

        //copy  all interface domin 
        EditAboutUsViewModel GetAboutUsforEdit(int Id);
        bool AddAboutUs(CreateAboutUsViewModel aboutUs);

        void EditAboutUs(EditAboutUsViewModel aboutUs);
        bool DeleAboutUS(int id);
        List<AboutUsModel> GetAllAbous();
      
    }
}

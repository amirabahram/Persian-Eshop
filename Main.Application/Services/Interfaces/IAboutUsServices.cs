using Main.Domain.Models.AboutUs;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace Main.Application.Services.Interfaces
{
    public interface IAboutUsServices
    {
        List<AboutUsModel> GetAllAboutUs();

        //copy  all interface domin 
        EditAboutUsViewModel GetAboutUsforEdit(int Id);
        bool AddAboutUs(CreateAboutUsViewModel aboutUs, IFormFile img);

        //  void EditAboutUs(EditAboutUsViewModel aboutUs,IFormFile img);
        EditAboutUsResualt EditAboutUs(EditAboutUsViewModel aboutUs, IFormFile img);

        bool DeleAboutUS(int id);


    }
}

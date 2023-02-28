using Main.Domain.Models.AboutUs;

namespace Main.Domain.Interfaces
{
    public interface IAboutUsRepository
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

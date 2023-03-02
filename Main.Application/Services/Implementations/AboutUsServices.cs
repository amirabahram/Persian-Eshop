using Main.Application.Services.Interfaces;
using Main.Data.Repositories;
using Main.Domain.Interfaces;
using Main.Domain.Models.AboutUs;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Http;

namespace Main.Application.Services.Implementations
{
    public class AboutUsServices : IAboutUsServices
    {
        //Connected interfacerepository 
        private readonly IAboutUsRepository _aboutUsRepository;

        public AboutUsServices(IAboutUsRepository aboutUsServices)
        {
            _aboutUsRepository = aboutUsServices;
        }


        public bool AddAboutUs(CreateAboutUsViewModel newaboutUs, IFormFile ImageAbout)
        {
            if (newaboutUs == null)
                return false;
            

            var aboutUs = new AboutUsModel
            {
                //AboutUsModel=>view
                CreateDate = DateTime.Now,
                DiscriptionAboutUs = newaboutUs.Description,
                TitleAboutUs = newaboutUs.Title,
                //create Img |if 
                

            };

           

            string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/ImagAbout", ImageAbout.FileName);

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                ImageAbout.CopyTo(fileStream);
            }
            aboutUs.ImagAboutUs = ImageAbout.FileName;


            _aboutUsRepository.AddAboutUs(aboutUs);
            _aboutUsRepository.save();
            return true;
        }



        public bool DeleteAboutUS(int id)
        {
            var aboutus = _aboutUsRepository.GetAboutUs(id);

            if (aboutus == null)
                return false;

            aboutus.IsDelete = true;

            _aboutUsRepository.EditAboutUs(aboutus);
            _aboutUsRepository.save();
            return true;

        }

        //public void EditAboutUs(EditAboutUsViewModel aboutUs,IFormFile imageAbout)
        public EditAboutUsResualt EditAboutUs(EditAboutUsViewModel newaboutUs, IFormFile ImageAbout)

        {
            if (newaboutUs == null)
                return EditAboutUsResualt.DataViewNotFound;

            var oldAboutUs = _aboutUsRepository.GetAboutUs(newaboutUs.Id);

            if (oldAboutUs == null)
                return EditAboutUsResualt.DataNotFound;

            oldAboutUs.TitleAboutUs = newaboutUs.Title;
            oldAboutUs.DiscriptionAboutUs = newaboutUs.Description;

            //imag
            if (ImageAbout != null)
            {
                var GetImag = Guid.NewGuid().ToString() +
                          Path.GetExtension(ImageAbout.FileName);

                string savePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/ImagAbout", ImageAbout.FileName);

                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    ImageAbout.CopyTo(fileStream);
                }
                oldAboutUs.ImagAboutUs = GetImag;


            }
            _aboutUsRepository.EditAboutUs(oldAboutUs);
            //bool res = false;
            //imageAbout.IsImage(res);
            //if (res)
            //{ }
            _aboutUsRepository.save();
            return EditAboutUsResualt.Suscess;

        }




        public EditAboutUsViewModel GetAboutUsforEdit(int id)
        {


            var aboutUs = _aboutUsRepository.GetAboutUs(id);

            // var editaboutUs=new EditAboutUsViewModel
            return new EditAboutUsViewModel

            {
                Description = aboutUs.DiscriptionAboutUs,
                ImagAbouts = aboutUs.ImagAboutUs,
                Title = aboutUs.TitleAboutUs,
                Id = aboutUs.Id,
            };
        

            //retrun aboutUs

        }


        public List<AboutUsModel> GetAllAboutUs()
        {
            return _aboutUsRepository.GetAll();
        }
    }
}

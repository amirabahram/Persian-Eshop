using Azure;
using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.AboutUs;
using Main.Domain.ViewModel.AboutUs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Main.Application.Services.Implementations
{
    public class AboutUsServices : IAboutUsServices
    { 
        //Connected interfacerepository 
        private readonly IAboutUsInterface _aboutUsRepository;

        public AboutUsServices(IAboutUsInterface aboutUsServices)
        {
            _aboutUsRepository = aboutUsServices;
        }


        public bool AddAboutUs(CreateAboutUsViewModel newaboutUs, IFormFile  ImageAbout )
        {
            if (newaboutUs == null)
                return false;
            string name = "";
            if (ImageAbout != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                              Path.GetFileName(ImageAbout.FileName));
                 name = Guid.NewGuid().ToString() + Path.GetExtension(ImageAbout.FileName);
            }
               
            var aboutUs = new AboutUsModel
            {
                //AboutUsModel=>view
                CreateDate = DateTime.Now,
                DiscriptionAboutUs = newaboutUs.Description,
                TitleAboutUs=newaboutUs.Title, 
                //create Img |if 

                ImagAboutUs=name

            };
            _aboutUsRepository.AddAboutUs(aboutUs);
            _aboutUsRepository.save();
            return true;
        }



        public bool DeleAboutUS(int id)
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
        public EditAboutUsResualt EditAboutUs(EditAboutUsViewModel newaboutUs, IFormFile imageAbout)

        {
            if(newaboutUs==null)
                return EditAboutUsResualt.DataViewNotFound;

            var oldAboutUs = _aboutUsRepository.GetAboutUs(newaboutUs.Id);
           
            if(oldAboutUs == null)
                return EditAboutUsResualt.DataNotFound;

            oldAboutUs.TitleAboutUs = newaboutUs.Title;
            oldAboutUs.DiscriptionAboutUs = newaboutUs.Description;
            
            //imag
            if(imageAbout!=null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                          Path.GetFileName(imageAbout.FileName));
             string name = Guid.NewGuid().ToString() + Path.GetExtension(imageAbout.FileName);
                oldAboutUs.ImagAboutUs = name;
            }
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
            _aboutUsRepository.EditAboutUs(aboutUs);
            _aboutUsRepository.save();

            //retrun aboutUs

        }


        public List<AboutUsModel> GetAllAboutUs()
        {
            return _aboutUsRepository.GetAll();
        }
    }
}

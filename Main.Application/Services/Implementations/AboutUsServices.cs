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

            if (ImageAbout != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                              Path.GetFileName(ImageAbout.FileName));
            }
            

        }
                
               
            var aboutUs = new AboutUsModel
            {
                //AboutUsModel=>view
                CreateDate = DateTime.Now,
                DiscriptionAboutUs = newaboutUs.Description,
                TitleAboutUs=newaboutUs.Title
            };
            _aboutUsRepository.AddAboutUs(aboutUs);
            _aboutUsRepository.save();
            return true;
        }

        public bool DeleAboutUS(int id)
        {
            throw new NotImplementedException();
        }

        public void EditAboutUs(EditAboutUsViewModel aboutUs)
        {
            throw new NotImplementedException();
        }

        public EditAboutUsViewModel GetAboutUsforEdit(int Id)
        {
            throw new NotImplementedException();
        }

        public List<AboutUsModel> GetAllAbous()
        {
            throw new NotImplementedException();
        }

        public List<AboutUsModel> GetAllAboutUs()
        {
            throw new NotImplementedException();
        }
    }
}

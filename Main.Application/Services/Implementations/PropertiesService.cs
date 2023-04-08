using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.CategoryProperties;
using Main.Domain.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{


    public class PropertiesService : IPropertiesService
    {
        private IPropertiesRepository _propertiesRepository;
        private ICategoryRepository _categoryRepository;
        public PropertiesService(IPropertiesRepository propertiesRepository, ICategoryRepository categoryRepository)
        {
            this._propertiesRepository = propertiesRepository;
            this._categoryRepository = categoryRepository;  
        }
        public async Task<List<PropertyViewModel>> GetAllProperties()
        {
            var allProperties = await _propertiesRepository.GetAllProperties();
            var properties = new List<PropertyViewModel>();
            foreach (var property in allProperties)
            {
                var propertyViewModel = new PropertyViewModel()
                {
                    Category = property.Category.Title,
                    Title = property.Title,
                    CategoryId = property.CategoryId,
                    Value = property.PropertyValue
                };
                properties.Add(propertyViewModel);
            }
            return properties;

        }

        public async Task<bool> InsertProperty(PropertyViewModel viewModel)
        {
            if (viewModel == null) return false;
            var model = new CategoryProperties()
            {
                CategoryId = viewModel.CategoryId,
                CreateDate = DateTime.Now,
                PropertyValue = viewModel.Value,
                Title = viewModel.Title,
               


            };

            await _propertiesRepository.AddProperty(model);
            await _propertiesRepository.Save();
            return true;
        }
    }
}

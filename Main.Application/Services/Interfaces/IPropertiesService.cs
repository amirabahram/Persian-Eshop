using Main.Domain.Models.CategoryProperties;
using Main.Domain.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface IPropertiesService
    {
        Task<bool> InsertProperty(PropertyViewModel model);
        Task<List<PropertyViewModel>> GetAllProperties();
        Task<List<PropertyViewModel>> GetPropertiesByCategoryId(int id);
    }
}

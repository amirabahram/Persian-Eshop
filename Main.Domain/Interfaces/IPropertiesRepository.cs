using Main.Domain.Models.CategoryProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface IPropertiesRepository
    {
        Task AddProperty(CategoryProperties model);
        Task<List<CategoryProperties>> GetAllProperties();
        Task Save();
    }
}

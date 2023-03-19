using Main.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<bool> InsertCategory(Category category);
        Task<UpdateCategoryResult> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);
        
    }
}

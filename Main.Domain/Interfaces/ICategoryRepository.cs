using Main.Domain.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<bool> IsDuplicated(string title);
        Task InsertCategory(Category category);
        void UpdateCategory(Category category);
        Task Save();


    }
}

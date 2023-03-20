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
        void Insert(Category category);
        void Update(Category category);
        void Save();


    }
}

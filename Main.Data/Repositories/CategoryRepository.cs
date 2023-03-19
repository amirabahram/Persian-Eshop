using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EshopContext db;
        public CategoryRepository(EshopContext context)
        {
            this.db = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await db.Categories.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public async Task InsertCategory(Category category)
        {
            db.Categories.Add(category);
        }

        public async Task<bool> IsDuplicated(string title)
        {
            if(db.Categories.Any(c => c.Title == title)) return true;
            return false;
        }

        public async Task Save()
        {
            db.SaveChangesAsync();
        }

        public void UpdateCategory(Category category)
        {
            db.Categories.Update(category);
        }
    }
}

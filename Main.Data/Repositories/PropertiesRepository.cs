using Main.Data.Context;
using Main.Domain.Interfaces;
using Main.Domain.Models.CategoryProperties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Data.Repositories
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly EshopContext _db;

        public PropertiesRepository(EshopContext db)
        {
            this._db = db;
        }


        public async Task AddProperty(CategoryProperties model)
        {
            await _db.categoryProperties.AddAsync(model);
        }

        public async Task<List<CategoryProperties>> GetAllProperties()
        {
            return await _db.categoryProperties.Include(i=>i.Category)
                .Where(p=>p.IsDelete==false)
                .OrderByDescending(p=>p.CreateDate).ToListAsync();
        }

        public async Task<List<CategoryProperties>> GetAllPropertiesByCategoryIdRepo(int id)
        {
            return await _db.categoryProperties.Where(p=>p.CategoryId==id).ToListAsync();
        }

        public async Task<List<CategoryProperties>> GetPropertiesByProduct(int id)
        {
            var propertyid = await _db.ProductProperties.Where(i => i.ProductId == id).Select(p=>p.PropertyId).ToListAsync();
            var properties = new List<CategoryProperties>();
            foreach(var item in propertyid)
            {
                var property = await _db.categoryProperties.Where(p=>p.Id==item).FirstOrDefaultAsync();
                properties.Add(property);
            }
            return properties;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}

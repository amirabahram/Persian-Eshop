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

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}

using Main.Application.Services.Interfaces;
using Main.Domain.Interfaces;
using Main.Domain.Models.Category;
using Main.Domain.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository; 
        }



        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null) return false;
            category.IsDelete = true;
            _categoryRepository.Update(category);
             _categoryRepository.Save();
            return true;

        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }


        public async Task<bool> InsertCategory(CategoryViewModel viewModel)
        {
            if (viewModel == null) return  false;
            Category category = new Category()
            {
                Title = viewModel.Title,
                CreateDate = DateTime.Now,

            };
             _categoryRepository.Insert(category);
             _categoryRepository.Save();
            return true;

        }

        public async Task<UpdateCategoryResult> UpdateCategory(Category category)
        {
            if (category == null) return UpdateCategoryResult.Failed;
            int id = category.Id;
            var oldCategory = await _categoryRepository.GetCategoryById(id);
            if (oldCategory == null) return UpdateCategoryResult.CategoryNotFound;
            if (await _categoryRepository.IsDuplicated(category.Title)) return UpdateCategoryResult.DuplicatedCategory;
            oldCategory.Title = category.Title;
            _categoryRepository.Update(oldCategory);
             _categoryRepository.Save();
            return UpdateCategoryResult.Success;


        }
    }
}

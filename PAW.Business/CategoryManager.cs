using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface ICategoryManager
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);

        Task<bool> DeleteCategoryAsync(int id);

        Task<Category> UpdateCategoryAsync(int id, Category updatedCategory);

        Task<Category> CreateCategoryAsync(Category category);
    }

    public class CategoryManager(ICategoryRepository categoryRepository, IFinanceService financeService) : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        public async Task<Category> GetByIdAsync(int id) 
        {
            return await _categoryRepository.GetByIdAsync(id);
        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category updatedCategory)
        {
            return await _categoryRepository.UpdateCategoryAsync(id, updatedCategory);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoryRepository.CreateCategoryAsync(category);
        }
    }
}
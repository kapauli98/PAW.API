using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetByIdAsync(int id);

        Task<bool> DeleteCategoryAsync(int id);

        Task<Category> UpdateCategoryAsync(int id, Category updatedCategory);

        Task<Category> CreateCategoryAsync(Category category);
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Category> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await FindAsync(id); 
            if (category != null)
            {
                return await DeleteAsync(category); 
            }
            return false; 
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category updatedCategory)
        {
            var category = await FindAsync(id);
            if (category != null)
            {
                category.CategoryName = updatedCategory.CategoryName ?? category.CategoryName;
                category.Description = updatedCategory.Description ?? category.Description; ;
                await UpdateAsync(category);
                return category;
            }
            return null;
            
        }


        public async Task<Category> CreateCategoryAsync(Category category)
        {
            var created = await CreateAsync(category);
            return created ? category : null;
        }


        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    return await CreateAsync(product);
        //}

    }
}

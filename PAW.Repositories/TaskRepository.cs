using PAW.Data.Repository;
using PAW.Models;
using PM = PAW.Models;

namespace PAW.Repositories
{

    public interface ITaskRepository
    {
        Task<IEnumerable<PM.Task>> GetAllCategoriesAsync();

        Task<PM.Task> GetByIdAsync(int id);

        Task<bool> DeleteTaskAsync(int id);

        Task<PM.Task> UpdateTaskAsync(int id, PM.Task updatedTask);

        Task<PM.Task> CreateTaskAsync(PM.Task task);
    }
    public class TaskRepository : RepositoryBase<PM.Task>, ITaskRepository
    {

        public async Task<IEnumerable<PM.Task>> GetAllCategoriesAsync()
        {
            return await ReadAsync();
        } 

        public async Task<PM.Task> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await FindAsync(id); 
            if (task != null)
            {
                return await DeleteAsync(task); 
            }
            return false; 
        }

        public async Task<PM.Task> UpdateTaskAsync(int id, PM.Task updatedTask)
        {
            var task = await FindAsync(id);
            if (task != null)
            {
                task.Name = updatedTask.Name ?? task.Name;
                task.Description = updatedTask.Description ?? task.Description;
                task.Status = updatedTask.Status ?? task.Status;
                task.DueDate = updatedTask.DueDate ?? task.DueDate;
                task.CreatedAt = updatedTask.CreatedAt ?? task.CreatedAt;
                task.LastModified = updatedTask.LastModified ?? task.LastModified;
                task.ModifiedBy = updatedTask.ModifiedBy ?? task.ModifiedBy;
                await UpdateAsync(task);
                return task;
            }
            return null;
            
        }


        public async Task<PM.Task> CreateTaskAsync(PM.Task task)
        {
            var created = await CreateAsync(task);
            return created ? task : null;
        }


        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    return await CreateAsync(product);
        //}

    }
}

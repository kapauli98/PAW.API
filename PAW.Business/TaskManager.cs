using PAW.Models;
using PAW.Repositories;
using PAW.Services;
using PM = PAW.Models;

namespace PAW.Business
{
    public interface ITaskManager
    {
        Task<IEnumerable<PM.Task>> GetAllAsync();
        Task<PM.Task> GetByIdAsync(int id);

        Task<bool> DeleteTaskAsync(int id);

        Task<PM.Task> UpdateTaskAsync(int id, PM.Task updatedTask);

        Task<PM.Task> CreateTaskAsync(PM.Task task);
    }

    public class TaskManager(ITaskRepository taskRepository) : ITaskManager
    {
        private readonly ITaskRepository _taskRepository = taskRepository;
        
        public async Task<IEnumerable<PM.Task>> GetAllAsync()
        {
            return await _taskRepository.GetAllCategoriesAsync();
        }

        public async Task<PM.Task> GetByIdAsync(int id) 
        {
            return await _taskRepository.GetByIdAsync(id);
        }


        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTaskAsync(id);
        }

        public async Task<PM.Task> UpdateTaskAsync(int id, PM.Task updatedTask)
        {
            return await _taskRepository.UpdateTaskAsync(id, updatedTask);
        }

        public async Task<PM.Task> CreateTaskAsync(PM.Task task)
        {
            return await _taskRepository.CreateTaskAsync(task);
        }
    }
}
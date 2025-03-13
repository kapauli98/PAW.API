using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IUserManager
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);

        Task<bool> DeleteUserAsync(int id);

        Task<User> UpdateUserAsync(int id, User updatedUser);

        Task<User> CreateUserAsync(User user);
    }

    public class UserManager(IUserRepository userRepository, IFinanceService financeService) : IUserManager
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllCategoriesAsync();
        }

        public async Task<User> GetByIdAsync(int id) 
        {
            return await _userRepository.GetByIdAsync(id);
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            return await _userRepository.UpdateUserAsync(id, updatedUser);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
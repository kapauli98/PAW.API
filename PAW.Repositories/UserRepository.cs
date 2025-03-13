using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllCategoriesAsync();

        Task<User> GetByIdAsync(int id);

        Task<bool> DeleteUserAsync(int id);

        Task<User> UpdateUserAsync(int id, User updatedUser);

        Task<User> CreateUserAsync(User user);
    }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public async Task<IEnumerable<User>> GetAllCategoriesAsync()
        {
            return await ReadAsync();
        } 

        public async Task<User> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await FindAsync(id); 
            if (user != null)
            {
                return await DeleteAsync(user); 
            }
            return false; 
        }

        public async Task<User> UpdateUserAsync(int id, User updatedUser)
        {
            var user = await FindAsync(id);
            if (user != null)
            {
                user.Username = updatedUser.Username ?? user.Username;
                user.Email = updatedUser.Email ?? user.Email;
                user.IsActive = updatedUser.IsActive ?? user.IsActive;
                user.ModifiedBy = updatedUser.ModifiedBy ?? user.ModifiedBy;
                await UpdateAsync(user);
                return user;
            }
            return null;
            
        }


        public async Task<User> CreateUserAsync(User user)
        {
            var created = await CreateAsync(user);
            return created ? user : null;
        }


    }
}

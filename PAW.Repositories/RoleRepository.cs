using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllCategoriesAsync();

        Task<Role> GetByIdAsync(int id);

        Task<bool> DeleteRoleAsync(int id);

        Task<Role> UpdateRoleAsync(int id, Role updatedRole);

        Task<Role> CreateRoleAsync(Role role);
    }
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {

        public async Task<IEnumerable<Role>> GetAllCategoriesAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Role> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await FindAsync(id); 
            if (role != null)
            {
                return await DeleteAsync(role); 
            }
            return false; 
        }

        public async Task<Role> UpdateRoleAsync(int id, Role updatedRole)
        {
            var role = await FindAsync(id);
            if (role != null)
            {
                role.RoleName = updatedRole.RoleName ?? role.RoleName;
                await UpdateAsync(role);
                return role;
            }
            return null;
            
        }


        public async Task<Role> CreateRoleAsync(Role role)
        {
            var created = await CreateAsync(role);
            return created ? role : null;
        }


        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    return await CreateAsync(product);
        //}

    }
}

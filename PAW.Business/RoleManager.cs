using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);

        Task<bool> DeleteRoleAsync(int id);

        Task<Role> UpdateRoleAsync(int id, Role updatedRole);

        Task<Role> CreateRoleAsync(Role role);
    }

    public class RoleManager(IRoleRepository roleRepository, IFinanceService financeService) : IRoleManager
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllCategoriesAsync();
        }

        public async Task<Role> GetByIdAsync(int id) 
        {
            return await _roleRepository.GetByIdAsync(id);
        }


        public async Task<bool> DeleteRoleAsync(int id)
        {
            return await _roleRepository.DeleteRoleAsync(id);
        }

        public async Task<Role> UpdateRoleAsync(int id, Role updatedRole)
        {
            return await _roleRepository.UpdateRoleAsync(id, updatedRole);
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            return await _roleRepository.CreateRoleAsync(role);
        }
    }
}
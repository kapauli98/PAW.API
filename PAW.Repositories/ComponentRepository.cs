using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface IComponentRepository
    {
        Task<IEnumerable<Component>> GetAllComponentsAsync();

        Task<Component> GetComponentByIdAsync(int id);

    }
    public class ComponentRepository : RepositoryBase<Component>, IComponentRepository
    {

        public async Task<IEnumerable<Component>> GetAllComponentsAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Component> GetComponentByIdAsync(int id)
        {
            return await FindAsync(id);
        }    

    }
}

using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetAllInventorysAsync();

        Task<Inventory> GetByIdAsync(int id);

        Task<bool> DeleteInventoryAsync(int id);

        Task<Inventory> UpdateInventoryAsync(int id, Inventory updatedInventory);

        Task<Inventory> CreateInventoryAsync(Inventory inventory);
    }
    public class InventoryRepository : RepositoryBase<Inventory>, IInventoryRepository
    {

        public async Task<IEnumerable<Inventory>> GetAllInventorysAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Inventory> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }


        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await FindAsync(id); // Buscar el inventoryo por su ID
            if (inventory != null)
            {
                return await DeleteAsync(inventory); // Eliminar el inventoryo si existe
            }
            return false; // Retornar false si no se encontró el inventoryo
        }

        public async Task<Inventory> UpdateInventoryAsync(int id, Inventory updatedInventory)
        {
            var inventory = await FindAsync(id);
            if (inventory != null)
            {
                inventory.UnitPrice = updatedInventory.UnitPrice ?? inventory.UnitPrice;
                inventory.  UnitsInStock = updatedInventory.UnitsInStock ?? inventory.UnitsInStock;
                inventory.ModifiedBy = updatedInventory.ModifiedBy ?? inventory.ModifiedBy;
                await UpdateAsync(inventory);
                return inventory;
            }
            return null;
            
        }

        public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
        {
            var created = await CreateAsync(inventory);
            return created ? inventory : null;
        }


    }
}

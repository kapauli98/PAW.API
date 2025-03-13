using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IInventoryManager
    {
        Task<IEnumerable<Inventory>> GetAllAsync();
        Task<Inventory> GetByIdAsync(int id);

        Task<bool> DeleteInventoryAsync(int id);

        Task<Inventory> UpdateInventoryAsync(int id, Inventory updatedInventory);

        Task<Inventory> CreateInventoryAsync(Inventory inventory);
    }

    public class InventoryManager(IInventoryRepository inventoryRepository, IFinanceService financeService) : IInventoryManager
    {
        private readonly IInventoryRepository _inventoryRepository = inventoryRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Inventory>> GetAllAsync()
        {
            return await _inventoryRepository.GetAllInventorysAsync();
        }

        public async Task<Inventory> GetByIdAsync(int id) 
        {
            return await _inventoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            return await _inventoryRepository.DeleteInventoryAsync(id);
        }

        public async Task<Inventory> UpdateInventoryAsync(int id, Inventory updatedInventory)
        {
            return await _inventoryRepository.UpdateInventoryAsync(id, updatedInventory);
        }

        public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
        {
            return await _inventoryRepository.CreateInventoryAsync(inventory);
        }
    }
}
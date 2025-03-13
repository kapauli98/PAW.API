using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface ISupplierManager
    {
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task<Supplier> GetByIdAsync(int id);

        Task<bool> DeleteSupplierAsync(int id);

        Task<Supplier> UpdateSupplierAsync(int id, Supplier updatedSupplier);

        Task<Supplier> CreateSupplierAsync(Supplier supplier);
    }

    public class SupplierManager(ISupplierRepository supplierRepository, IFinanceService financeService) : ISupplierManager
    {
        private readonly ISupplierRepository _supplierRepository = supplierRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _supplierRepository.GetAllCategoriesAsync();
        }

        public async Task<Supplier> GetByIdAsync(int id) 
        {
            return await _supplierRepository.GetByIdAsync(id);
        }


        public async Task<bool> DeleteSupplierAsync(int id)
        {
            return await _supplierRepository.DeleteSupplierAsync(id);
        }

        public async Task<Supplier> UpdateSupplierAsync(int id, Supplier updatedSupplier)
        {
            return await _supplierRepository.UpdateSupplierAsync(id, updatedSupplier);
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            return await _supplierRepository.CreateSupplierAsync(supplier);
        }
    }
}
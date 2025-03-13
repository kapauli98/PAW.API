using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllCategoriesAsync();

        Task<Supplier> GetByIdAsync(int id);

        Task<bool> DeleteSupplierAsync(int id);

        Task<Supplier> UpdateSupplierAsync(int id, Supplier updatedSupplier);

        Task<Supplier> CreateSupplierAsync(Supplier supplier);
    }
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {

        public async Task<IEnumerable<Supplier>> GetAllCategoriesAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await FindAsync(id); 
            if (supplier != null)
            {
                return await DeleteAsync(supplier); 
            }
            return false; 
        }

        public async Task<Supplier> UpdateSupplierAsync(int id, Supplier updatedSupplier)
        {
            var supplier = await FindAsync(id);
            if (supplier != null)
            {
                supplier.SupplierName = updatedSupplier.SupplierName ?? supplier.SupplierName;
                supplier.ContactName = updatedSupplier.ContactName ?? supplier.ContactName;
                supplier.ContactTitle = updatedSupplier.ContactTitle ?? supplier.ContactTitle;
                supplier.Phone = updatedSupplier.Phone ?? supplier.Phone;
                supplier.Address = updatedSupplier.Address ?? supplier.Address;
                supplier.City = updatedSupplier.City ?? supplier.City;
                supplier.Country = updatedSupplier.Country ?? supplier.Country;
                supplier.ModifiedBy = updatedSupplier.ModifiedBy ?? supplier.ModifiedBy;
                await UpdateAsync(supplier);
                return supplier;
            }
            return null;
            
        }


        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            var created = await CreateAsync(supplier);
            return created ? supplier : null;
        }


        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    return await CreateAsync(product);
        //}

    }
}

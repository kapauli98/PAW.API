using PAW.Data.Repository;
using PAW.Models;

namespace PAW.Repositories
{

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> GetHighCostByIdAsync(int id, decimal value);

        Task<bool> DeleteProductAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product updatedProduct);

        Task<Product> CreateProductAsync(Product product);
    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await ReadAsync();
        } 

        public async Task<Product> GetByIdAsync(int id)
        {
            return await FindAsync(id);
        }

        public async Task<Product> GetHighCostByIdAsync(int id, decimal value)
        {
            var highcost = await ReadAsync();
            var results = highcost.Where(x => x.Rating > value);
            return results.SingleOrDefault(x => x.ProductId == id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await FindAsync(id); // Buscar el producto por su ID
            if (product != null)
            {
                return await DeleteAsync(product); // Eliminar el producto si existe
            }
            return false; // Retornar false si no se encontró el producto
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            var product = await FindAsync(id);
            if (product != null)
            {
                product.ProductName = updatedProduct.ProductName;
                product.Description = updatedProduct.Description;
                product.Rating = updatedProduct.Rating ?? product.Rating;
                await UpdateAsync(product);
                return product;
            }
            return null;
            
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var created = await CreateAsync(product);
            return created ? product : null;
        }


        //public async Task<bool> CreateProductAsync(Product product)
        //{
        //    return await CreateAsync(product);
        //}

    }
}

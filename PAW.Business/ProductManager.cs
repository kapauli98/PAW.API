using PAW.Models;
using PAW.Repositories;
using PAW.Services;

namespace PAW.Business
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);

        Task<Product> GetHighCostByIdAsync(int id, decimal value);

        Task<bool> DeleteProductAsync(int id);

        Task<Product> UpdateProductAsync(int id, Product updatedProduct);

        Task<Product> CreateProductAsync(Product product);
    }

    public class ProductManager(IProductRepository productRepository, IFinanceService financeService) : IProductManager
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IFinanceService _financeService = financeService;
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetByIdAsync(int id) 
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> GetHighCostByIdAsync(int id, decimal value)
        {
            var exchange = await _financeService.GetTodaysExchangeRateAsync();
            var product = await _productRepository.GetHighCostByIdAsync(id, value);
            product.LastRetrieved = DateTime.UtcNow;
            product.Rating*= exchange.Buy;
            product.IsDirty = true;
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        public async Task<Product> UpdateProductAsync(int id, Product updatedProduct)
        {
            return await _productRepository.UpdateProductAsync(id, updatedProduct);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }
    }
}
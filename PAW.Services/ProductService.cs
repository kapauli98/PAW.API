using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models;

namespace PAW.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }

    public class ProductService(IRestProvider restProvider) : IProductService
    {
        private readonly IRestProvider _restProvider = restProvider;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            //cambiar el enlace por el que les da el metodo de ProductApi/all en el API
            var data = await _restProvider.GetAsync($"https://localhost:7026/ProductApi/all", null);
            var products = JsonProvider.DeserializeSimple<IEnumerable<Product>>(data);
            return products;
        }


    }
}

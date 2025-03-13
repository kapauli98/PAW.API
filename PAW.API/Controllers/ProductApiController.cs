using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController(IProductManager manager) : Controller
    {
        private readonly IProductManager _manager = manager;

        //Obtiene un producto por id
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<Product> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los productos por id
        [HttpGet("all", Name = "GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        //Obtiene el tipo de cambio por id
        [HttpGet("high", Name = "GetHighCostProductsById")]
        public async Task<Product> GetHighCostProductByid(int id, decimal cost)
        {
            return await _manager.GetHighCostByIdAsync(id, cost);
        }

        [HttpPost("save", Name = "SaveProduct")]
        public async Task<Product> Save([FromBody] Product product)
        {
            return null;
        }

        //Actualiza un producto
        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<Product> Update(int id, [FromBody] Product product)
        {
            return await _manager.UpdateProductAsync(id, product);
        }

        //Borra un producto por id
        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteProductAsync(id);
        }

        [HttpPost("Create",Name = "CreateProduct")]
        public async Task<Product> Create([FromBody] Product product)
        {
            return await _manager.CreateProductAsync(product);
        }

    }
}

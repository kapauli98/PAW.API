using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryApiController(IInventoryManager manager) : Controller
    {
        private readonly IInventoryManager _manager = manager;

        //Obtiene un inventoryo por id
        [HttpGet("{id}", Name = "GetInventory")]
        public async Task<Inventory> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los inventoryos por id
        [HttpGet("all", Name = "GetAllInventorys")]
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        [HttpPost("save", Name = "SaveInventory")]
        public async Task<Inventory> Save([FromBody] Inventory inventory)
        {
            return null;
        }

        //Actualiza un inventoryo
        [HttpPut("{id}", Name = "UpdateInventory")]
        public async Task<Inventory> Update(int id, [FromBody] Inventory inventory)
        {
            return await _manager.UpdateInventoryAsync(id, inventory);
        }

        //Borra un inventoryo por id
        [HttpDelete("{id}", Name = "DeleteInventory")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteInventoryAsync(id);
        }

        [HttpPost("Create",Name = "CreateInventory")]
        public async Task<Inventory> Create([FromBody] Inventory inventory)
        {
            return await _manager.CreateInventoryAsync(inventory);
        }

    }
}

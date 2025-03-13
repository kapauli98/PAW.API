using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierApiController(ISupplierManager manager) : Controller
    {
        private readonly ISupplierManager _manager = manager;

        //Obtiene un suppliero por id
        [HttpGet("{id}", Name = "GetSupplier")]
        public async Task<Supplier> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los supplieros por id
        [HttpGet("all", Name = "GetAllSuppliers")]
        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        [HttpPost("save", Name = "SaveSupplier")]
        public async Task<Supplier> Save([FromBody] Supplier supplier)
        {
            return null;
        }

        //Actualiza un suppliero
        [HttpPut("{id}", Name = "UpdateSupplier")]
        public async Task<Supplier> Update(int id, [FromBody] Supplier supplier)
        {
            return await _manager.UpdateSupplierAsync(id, supplier);
        }

        //Borra un suppliero por id
        [HttpDelete("{id}", Name = "DeleteSupplier")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteSupplierAsync(id);
        }

        [HttpPost("Create",Name = "CreateSupplier")]
        public async Task<Supplier> Create([FromBody] Supplier supplier)
        {
            return await _manager.CreateSupplierAsync(supplier);
        }

    }
}

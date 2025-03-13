using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryApiController(ICategoryManager manager) : Controller
    {
        private readonly ICategoryManager _manager = manager;

        //Obtiene un categoryo por id
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<Category> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los categoryos por id
        [HttpGet("all", Name = "GetAllCategorys")]
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        [HttpPost("save", Name = "SaveCategory")]
        public async Task<Category> Save([FromBody] Category category)
        {
            return null;
        }

        //Actualiza un categoryo
        [HttpPut("{id}", Name = "UpdateCategory")]
        public async Task<Category> Update(int id, [FromBody] Category category)
        {
            return await _manager.UpdateCategoryAsync(id, category);
        }

        //Borra un categoryo por id
        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteCategoryAsync(id);
        }

        [HttpPost("Create",Name = "CreateCategory")]
        public async Task<Category> Create([FromBody] Category category)
        {
            return await _manager.CreateCategoryAsync(category);
        }

    }
}

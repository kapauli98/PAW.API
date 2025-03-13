using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleApiController(IRoleManager manager) : Controller
    {
        private readonly IRoleManager _manager = manager;

        //Obtiene un roleo por id
        [HttpGet("{id}", Name = "GetRole")]
        public async Task<Role> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los roleos por id
        [HttpGet("all", Name = "GetAllRoles")]
        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        [HttpPost("save", Name = "SaveRole")]
        public async Task<Role> Save([FromBody] Role role)
        {
            return null;
        }

        //Actualiza un roleo
        [HttpPut("{id}", Name = "UpdateRole")]
        public async Task<Role> Update(int id, [FromBody] Role role)
        {
            return await _manager.UpdateRoleAsync(id, role);
        }

        //Borra un roleo por id
        [HttpDelete("{id}", Name = "DeleteRole")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteRoleAsync(id);
        }

        [HttpPost("Create",Name = "CreateRole")]
        public async Task<Role> Create([FromBody] Role role)
        {
            return await _manager.CreateRoleAsync(role);
        }

    }
}

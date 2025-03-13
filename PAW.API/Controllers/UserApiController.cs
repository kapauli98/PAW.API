using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController(IUserManager manager) : Controller
    {
        private readonly IUserManager _manager = manager;

        //Obtiene un usero por id
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<User> Get(int id)
        {
            return await _manager.GetByIdAsync(id);
        }

        //Obtiene todos los useros por id
        [HttpGet("all", Name = "GetAllUsers")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _manager.GetAllAsync();
        }

        [HttpPost("save", Name = "SaveUser")]
        public async Task<User> Save([FromBody] User user)
        {
            return null;
        }

        //Actualiza un usero
        [HttpPut("{id}", Name = "UpdateUser")]
        public async Task<User> Update(int id, [FromBody] User user)
        {
            return await _manager.UpdateUserAsync(id, user);
        }

        //Borra un usero por id
        [HttpDelete("{id}", Name = "DeleteUser")]
        public async Task<bool> Delete(int id)
        {
            return await _manager.DeleteUserAsync(id);
        }

        [HttpPost("Create",Name = "CreateUser")]
        public async Task<User> Create([FromBody] User user)
        {
            return await _manager.CreateUserAsync(user);
        }

    }
}

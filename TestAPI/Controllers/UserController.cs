using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBUS.Service.Interface;
using TestBUS.ViewModel.User;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVM>>> GetAll()
        {
            var user = await _service.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> GetUserById(int id)
        {
            try
            {
                var user = await _service.GetById(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new {message = ex.Message});
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserCreateVM user)
        {
            await _service.AddUserAsync(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserUpdateVM user)
        {
            try
            {
                user.UserId = id;
                await _service.UpdateUserAsync(user);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _service.DeleteUserAsync(id);
                return NoContent(); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }   
}

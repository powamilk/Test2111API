using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBUS.Service.Interface;
using TestBUS.ViewModel.Email;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmails()
        {
            var emails = await _emailService.GetAllEmailsAsync();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailById(int id)
        {
            var email = await _emailService.GetEmailByIdAsync(id);
            if (email == null)
            {
                return NotFound($"Email with ID {id} not found.");
            }
            return Ok(email);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmail([FromBody] EmailCreateVM emailCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _emailService.AddEmailAsync(emailCreateVM);
            return CreatedAtAction(nameof(GetEmailById), new { id = emailCreateVM.UserId }, emailCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmail(int id, [FromBody] EmailUpdateVM emailUpdateVM)
        {
            if (id != emailUpdateVM.EmailId)
            {
                return BadRequest("Email ID mismatch.");
            }

            await _emailService.UpdateEmailAsync(emailUpdateVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            await _emailService.DeleteEmailAsync(id);
            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetEmailsByUserId(int userId)
        {
            var emails = await _emailService.GetEmailsByUserIdAsync(userId);
            return Ok(emails);
        }
    }
}

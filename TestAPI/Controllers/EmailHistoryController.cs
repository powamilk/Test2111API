using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestBUS.Service.Interface;
using TestBUS.ViewModel.EmailHistory;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailHistoryController : ControllerBase
    {
        private readonly IEmailHistoryService _emailHistoryService;

        public EmailHistoryController(IEmailHistoryService emailHistoryService)
        {
            _emailHistoryService = emailHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var histories = await _emailHistoryService.GetAllAsync();
            return Ok(histories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var history = await _emailHistoryService.GetByIdAsync(id);
            if (history == null)
            {
                return NotFound($"Email history with ID {id} not found.");
            }
            return Ok(history);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmailHistoryCreateVM emailHistoryCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _emailHistoryService.AddAsync(emailHistoryCreateVM);
            return CreatedAtAction(nameof(GetById), new { id = emailHistoryCreateVM.EmailId }, emailHistoryCreateVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EmailHistoryUpdateVM emailHistoryUpdateVM)
        {
            if (id != emailHistoryUpdateVM.HistoryId)
            {
                return BadRequest("History ID mismatch.");
            }

            await _emailHistoryService.UpdateAsync(emailHistoryUpdateVM);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _emailHistoryService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("email/{emailId}")]
        public async Task<IActionResult> GetByEmailId(int emailId)
        {
            var histories = await _emailHistoryService.GetByEmailIdAsync(emailId);
            return Ok(histories);
        }
    }
}

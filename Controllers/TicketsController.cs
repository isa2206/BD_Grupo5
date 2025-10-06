using apiwithdb.Models.dtos;
using apiwithdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAll();
            return Ok(items);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var ticket = await _service.GetById(id);
            return ticket == null
                ? NotFound(new { error = "Ticket not found", status = 404 })
                : Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var ticket = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Ticket not found", status = 404 });
        }
    }
}

using apiwithdb.Models.dtos;
using apiwithdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiwithdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var _event = await _service.GetById(id);
            return _event == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(_event);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var _event = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = _event.Id }, _event);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success ? NoContent() : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}

using Business.Abstract;
using Entities.DTOs.Blogs;
using Entities.DTOs.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        IEventService _service;

        public EventsController(IEventService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getpaged")]
        public IActionResult GetPaged([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var result = _service.GetAllFilter(page, limit);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] EventCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EventUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

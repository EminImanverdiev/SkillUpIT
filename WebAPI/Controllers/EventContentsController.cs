using Business.Abstract;
using Entities.DTOs.Events.EventContents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class EventContentsController : ControllerBase
    {
        IEventContentService _service;

        public EventContentsController(IEventContentService service)
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
        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(EventContentCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(EventContentUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}

using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        ITagService _service;

        public TagsController(ITagService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(Guid id)
        {
            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Entities.DTOs.Tags.TagCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(Entities.DTOs.Tags.TagUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

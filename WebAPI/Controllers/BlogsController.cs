using Business.Abstract;
using Entities.DTOs.Blogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlogService _service;

        public BlogsController(IBlogService service)
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
        public IActionResult Add(BlogCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(BlogUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}

using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        ICourseService _service;

        public CoursesController(ICourseService service)
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
        public IActionResult Add(Entities.DTOs.Courses.CourseCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Entities.DTOs.Courses.CourseUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getpaged")]
        public IActionResult GetPaged(int page, int limit)
        {
            var result = _service.GetAllFilter(page, limit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

using Business.Abstract;
using Entities.DTOs.ContactBlocks;
using Entities.DTOs.Fags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class ContactBlocksController : ControllerBase
    {
        IContactBlockService _service;

        public ContactBlocksController(IContactBlockService service)
        {
            _service = service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Create(ContactBlockCreateDto create)
        {
            var result = _service.Add(create);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(ContactBlockUpdateDto update)
        {
            var result = _service.Update(update);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var result = _service.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}

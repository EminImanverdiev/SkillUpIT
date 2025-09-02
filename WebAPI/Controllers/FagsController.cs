using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Fags;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class FagsController : ControllerBase
    {
        IFagService _fagService;

        public FagsController(IFagService fagService)
        {
            _fagService = fagService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fagService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Post(FagDto fag)
        {
            var result = _fagService.Add(fag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var result = _fagService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

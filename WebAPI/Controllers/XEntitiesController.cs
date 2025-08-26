using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("nam/[controller]")]
    [ApiController]
    public class XEntitiesController : ControllerBase
    {
        IXEntityService _xEntityService;
        public XEntitiesController(IXEntityService xEntityService)
        {
            _xEntityService = xEntityService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _xEntityService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Post(XEntity xEntity)
        {
            var result = _xEntityService.Add(xEntity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var result = _xEntityService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}

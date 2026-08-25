using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributionController : ControllerBase
    {
        DistributionService service;

        public DistributionController(DistributionService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(DistributionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!service.Create(model))
            {
                return BadRequest("Cannot distribute food");
            }

            return Ok("Food distributed");
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(service.Read());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = service.GetById(id);

            if (data.Count == 0)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Delete(id))
            {
                return BadRequest();
            }

            return Ok("Distribution deleted");
        }

        [HttpGet("getWithEmployeeName")]
        public IActionResult GetWithEmployeeName()
        {
            var data=service.GetWithEmployeeName();
            return Ok(data);
        }
    }
}

using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService service;

        public EmployeeController(EmployeeService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!service.Create(model))
            {
                return BadRequest();

            }

            return Ok("Employee created");
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(service.Read());
        }

        [HttpPut("update")]
        public IActionResult Update(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!service.Update(model))
            {
                return BadRequest();

            }

            return Ok("Employee updated");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Delete(id))
            {
                return BadRequest();

            }

            return Ok("Employee deleted");
        }
    }
}

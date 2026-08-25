using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionRequestController : ControllerBase
    {
        CollectionRequestService service;

        public CollectionRequestController(CollectionRequestService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(CollectionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!service.Create(model))
            {
                return BadRequest("Invalid request");
            }

            return Ok("Request created");
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

        [HttpPut("accept/{id}")]
        public IActionResult Accept(int id)
        {
            if (!service.Accept(id))
            {
                return BadRequest("Cannot accept request");
            }

            return Ok("Request accepted");
        }

        [HttpPut("assign/{id}/{employeeId}")]
        public IActionResult Assign(int id, int employeeId)
        {
            if (!service.AssignEmployee(id, employeeId))
            {
                return BadRequest("Cannot assign employee");
            }

            return Ok("Employee assigned");
        }

        [HttpPut("collect/{id}")]
        public IActionResult Collect(int id)
        {
            if (!service.Collect(id))
            {
                return BadRequest("Cannot collect request");
            }

            return Ok("Food collected");
        }

        [HttpPut("complete/{id}")]
        public IActionResult Complete(int id)
        {
            if (!service.Complete(id))
            {
                return BadRequest("Cannot complete request");
            }

            return Ok("Request completed");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Delete(id))
            {
                return BadRequest();
            }

            return Ok("Request deleted");
        }

        [HttpGet("getWithRestaurantName")]
        public IActionResult GetWithRestaurantName()
        {
            var data = service.GetWithRestaurantName();
            return Ok(data);
        }

        [HttpGet("getWithEmployeeName")]
        public IActionResult GetWithEmployeeName()
        {
            var data = service.GetWithEmployeeName();

            return Ok(data);
        }
    }
}

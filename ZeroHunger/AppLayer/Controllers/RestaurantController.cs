using BLL.Models;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        RestaurantService service;

        public RestaurantController(RestaurantService service)
        {
            this.service = service;
        }

        [HttpPost("create")]
        public IActionResult Create(RestaurantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!service.Create(model))
            {
                return BadRequest();

            }

            return Ok("Restaurant created");
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(service.Read());
        }

        [HttpPut("update")]
        public IActionResult Update(RestaurantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            if (!service.Update(model))
            {
                return BadRequest();

            }

            return Ok("Restaurant updated");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!service.Delete(id))
            {
                return BadRequest();

            }

            return Ok("Restaurant deleted");
        }
    }
}

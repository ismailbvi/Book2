using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;
using GamingStore.BL.InerFaces;
using GamingStore.DL.InerFaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingStore2.Control
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public GameController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllOrders")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orderService.GetAll();

            if (result != null && result.Any()) return Ok(result);

            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(Order))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null) return BadRequest(id);

            var result = await _orderService.GetById(id);

            if (result != null) return Ok(result);

            return NotFound();
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] Order order)
        {
            await _orderService.Add(order);
        }


        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.Delete(id);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Gaming_Store_Data.Data;
using GamingStore.BL.Interfaces;

namespace Gaming_Store.Control
{
        [ApiController]
    [Route("api/[controller]")]
        public class OrderController : ControllerBase
        {
            private readonly IOrderService _orderService;

            public OrderController(IOrderService orderService)
            {
                _orderService = orderService;
            }
            [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [HttpGet("GetAllBOrders")]
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
            public async Task AddOrder([FromBody] Order order)
            {
                await _orderService.AddOrder(order);
            }

            [HttpPost("Update")]
            public async Task UpdateOrder([FromBody] Order order)
            {
                await _orderService.UpdateOrder(order);
            }

            [HttpDelete("Delete")]
            public async Task<IActionResult> DeleteOrder(Guid id)
            {
                await _orderService.DeleteOrder(id);

                return Ok();
            }
        }
    }

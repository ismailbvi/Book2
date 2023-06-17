using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;
using GamingStore.BL.InerFaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("{id}")]
    public ActionResult<OrderDto> GetById(int id)
    {
        var order = _orderService.GetById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> GetAll()
    {
        var orders = _orderService.GetAll();
        return Ok(orders);
    }

    [HttpPost]
    public IActionResult CreateOrder(CreateOrderDto createOrderDto)
    {
        // Perform any validation or additional logic
        _orderService.CreateOrder(createOrderDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, UpdateOrderDto updateOrderDto)
    {
        // Perform any validation or additional logic
        _orderService.UpdateOrder(id, updateOrderDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        // Perform any validation or additional logic
        _orderService.DeleteOrder(id);
        return Ok();
    }
}

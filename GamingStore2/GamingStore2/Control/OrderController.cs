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
    public ActionResult<OrderDto> GetOrderById(int id)
    {
        var order = _orderService.GetOrderById(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpGet]
    public ActionResult<IEnumerable<OrderDto>> GetAllOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }

    [HttpPost]
    public IActionResult AddOrder(CreateOrderDto orderDto)
    {
        
        _orderService.AddOrder(orderDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(UpdateOrderDto orderDto)
    {
       
        _orderService.UpdateOrder(orderDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(int id)
    {
        
        _orderService.DeleteOrder(id);
        return Ok();
    }
}

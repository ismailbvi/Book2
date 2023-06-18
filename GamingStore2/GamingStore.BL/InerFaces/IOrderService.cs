using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;

namespace GamingStore.BL.InerFaces
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int id);
        IEnumerable<OrderDto> GetAllOrders();
        void AddOrder(CreateOrderDto orderDto);
        void UpdateOrder(UpdateOrderDto orderDto);
        void DeleteOrder(int id);
    }
}

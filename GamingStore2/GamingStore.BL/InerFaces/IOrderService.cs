using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;

namespace GamingStore.BL.InerFaces
{
    public interface IOrderService
    {
        OrderDto GetById(int id);
        IEnumerable<OrderDto> GetAll();
        void CreateOrder(CreateOrderDto createOrderDto);
        void UpdateOrder(int id, UpdateOrderDto updateOrderDto);
        void DeleteOrder(int id);
    }
}

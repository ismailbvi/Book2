using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;

namespace GamingStore.BL.InerFaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetById(Guid id);
        Task<Order?> Add(Order game);
        Task Delete(Guid id);
    }
}

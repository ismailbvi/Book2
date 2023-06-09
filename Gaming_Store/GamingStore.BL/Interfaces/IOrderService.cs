using Gaming_Store_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.BL.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> GetById(Guid id);
        Task <IEnumerable<Order>> GetAll();
        Task<Order?>AddOrder(Order game);
        Task UpdateOrder(Order order);
        Task DeleteOrder(Guid id);                                                                                                                                                                                 
    }
}

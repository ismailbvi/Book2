using Gaming_Store_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.DL.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order?>GetById(Guid id);
        Task AddOrder(Order game);
        Task UpdateOrder(Order game);
        Task DeleteOrder(Guid id);
        Task<IEnumerable<Order>> GetAllByGameId(Guid gameId);
    }
}

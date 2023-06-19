using Gaming_Store_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.DL.InerFaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetAllByGameId(Guid gameId);
        Task<Order?> GetById(Guid id);
        Task Add(Order game);
        Task Delete(Guid id);
    }
}

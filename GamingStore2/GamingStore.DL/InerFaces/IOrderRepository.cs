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
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}

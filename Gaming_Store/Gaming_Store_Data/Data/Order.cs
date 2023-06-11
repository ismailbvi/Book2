using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Data
{
    public class Order
    {
        public Guid Id;
        public Guid GameId { get; set; }
        public string? OrderName { get; set; }
        
    }
}

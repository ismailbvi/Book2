using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Data
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

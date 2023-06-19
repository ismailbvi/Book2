using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Request
{
    public class AddOrderRequest
    {
        public string TitleofGame { get; set; }

        public Guid GameId { get; set; }

        public string Description { get; set; }
    }
}

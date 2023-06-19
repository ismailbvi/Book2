using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaming_Store_Data.Data
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid GameId { get; set; }

        public string Description { get; set; }
    }
}

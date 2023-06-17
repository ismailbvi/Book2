using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.DL.Repo
{
    public class MongoOrderRepo : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public MongoOrderRepo(IMongoDatabase database)
        {
            _orderCollection = database.GetCollection<Order>("orders");
        }

        public Order GetById(int id)
        {
            return _orderCollection.Find(order => order.Id == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderCollection.Find(_ => true).ToList();
        }

        public void Add(Order order)
        {
            _orderCollection.InsertOne(order);
        }

        public void Update(Order order)
        {
            _orderCollection.ReplaceOne(existingOrder => existingOrder.Id == order.Id, order);
        }

        public void Delete(int id)
        {
            _orderCollection.DeleteOne(order => order.Id == id);
        }
    }
}

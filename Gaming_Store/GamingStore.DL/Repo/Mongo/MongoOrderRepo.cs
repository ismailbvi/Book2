using Gaming_Store_Data.Config;
using Gaming_Store_Data.Data;
using GamingStore.DL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;


namespace GamingStore.DL.Repo.Mongo
{
    public class MongoOrderRepo : IOrderRepository
    {
        private readonly IMongoCollection<Order> _order;

        public MongoOrderRepo(IOptionsMonitor<MongoConfiguration> mongoConfig)
        {
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };
            _order = database
                .GetCollection<Order>(nameof(Order), collectionSettings);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await
                _order.Find(game => true).ToListAsync();
        }

        public async Task<Order?> GetById(Guid id)
        {   
            var item = await _order
                .Find(Builders<Order>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task AddOrder(Order game)
        {
            await _order.InsertOneAsync(game);
        }

        public Task DeleteOrder(Guid id)
        {
            return _order.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateOrder(Order order)
        {
            var filter =
                Builders<Order>.Filter.Eq(s => s.Id, order.Id);
            var update = Builders<Order>
                .Update.Set(s =>
                    s.OrderName, order.OrderName);

            await _order.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<Order>> GetAllByGameId(Guid gameId)
        {
            return await _order
                .Find(x => x.GameId == gameId)
                .ToListAsync();
        }
    }
}

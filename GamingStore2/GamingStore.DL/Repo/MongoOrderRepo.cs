using Gaming_Store_Data.Config;
using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
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
        private readonly IMongoCollection<Order> _orders;
        private readonly IOptionsMonitor<MongoConfiguration> _config;

        public MongoOrderRepo(
            IOptionsMonitor<MongoConfiguration> config)
        {
            _config = config;
            var client =
                new MongoClient(_config.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(_config.CurrentValue.DatabaseName);

            _orders =
                database.GetCollection<Order>($"{nameof(Order)}",
                    new MongoCollectionSettings()
                    {
                        GuidRepresentation = GuidRepresentation.Standard
                    });
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _orders.Find(order => true)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllByGameId(Guid gameId)
        {
            return await _orders
                .Find(a => a.GameId == gameId)
                .ToListAsync();
        }

        public async Task<Order?> GetById(Guid id)
        {
            return await _orders
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(Order game)
        {
            await _orders.InsertOneAsync(game);
        }

        public async Task Delete(Guid id)
        {
            await _orders
                .DeleteOneAsync(a => a.Id == id);
        }
    }
}

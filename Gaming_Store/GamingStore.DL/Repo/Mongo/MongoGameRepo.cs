using Gaming_Store_Data.Config;
using GamingStore.DL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Gaming_Store_Data.Data;

namespace GamingStore.DL.Repo.Mongo
{
    public class MongoGameRepo : IGameRepository
    {
        private readonly IMongoCollection<Game> _games;

        public MongoGameRepo(
            IOptionsMonitor<MongoConfiguration> mongoConfig)
        {
            var client = new MongoClient(
                mongoConfig.CurrentValue.ConnectionString);
            var database =
                client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };
            _games = database
                .GetCollection<Game>(nameof(Game), collectionSettings);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await
                _games.Find(game => true).ToListAsync();
        }
            
        public async Task<Game> GetById(Guid id)
        {
            var item = await _games
                .Find(Builders<Game>.Filter.Eq("_id", id))
                .FirstOrDefaultAsync();
            return item;
        }

        public async Task AddGame(Game game)
        {
            await _games.InsertOneAsync(game);
        }

        public Task DeleteGame(Guid id)
        {
            return _games.DeleteOneAsync(x => x.Id == id);
        }

        public Task UpdateGame(Game game)
        {
            var filter =
                Builders<Game>.Filter.Eq(s => s.Id, game.Id);
            var update = Builders<Game>
                .Update.Set(s =>
                    s.Developer, game.Developer);
            return _games.UpdateOneAsync(filter, update);
        }
    }
}

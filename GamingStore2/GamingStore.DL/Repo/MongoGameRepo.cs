using Gaming_Store_Data.Config;
using Gaming_Store_Data.Data;
using GamingStore.DL.InerFaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GamingStore.DL.Repo
{
    public class MongoGameRepo : IGameRepository
    {
    private readonly IMongoCollection<Game> _gameCollection;

        public MongoGameRepo(IMongoDatabase database)
        {
            _gameCollection = database.GetCollection<Game>("games");
        }

        public Game GetById(int id)
        {
            return _gameCollection.Find(game => game.Id == id).FirstOrDefault();
        }

        public IEnumerable<Game> GetAll()
        {
            return _gameCollection.Find(_ => true).ToList();
        }

        public void Add(Game game)
        {
            _gameCollection.InsertOne(game);
        }

        public void Update(Game game)
        {
            _gameCollection.ReplaceOne(existingGame => existingGame.Id == game.Id, game);
        }

        public void Delete(int id)
        {
            _gameCollection.DeleteOne(game => game.Id == id);
        }
    }
}

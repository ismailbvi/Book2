using AutoMapper;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;
using GamingStore.BL.InerFaces;
using GamingStore.DL.InerFaces;

namespace GamingStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(
            IGameRepository gameRepository,
            IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameRepository.GetAll();
        }

        public async Task<Game> GetById(Guid id)
        {
            return await _gameRepository.GetById(id);
        }

        public async Task<Game> AddGame(AddGameRequest gameRequest)
        {
            var game
                = _mapper.Map<Game>(gameRequest);

            game.Id = Guid.NewGuid();

            await _gameRepository.Add(game);
            return game;
        }

        public async Task DeleteGame(Guid id)
        {
            await _gameRepository.Delete(id);
        }
    }
}


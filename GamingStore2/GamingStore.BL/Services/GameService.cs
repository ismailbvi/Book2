using GamingStore.BL.InerFaces;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;
using GamingStore.DL.InerFaces;
using AutoMapper;

namespace GamingStore.BL.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public GameDto GetById(int id)
        {
            var game = _gameRepository.GetById(id);
            return _mapper.Map<GameDto>(game);
        }

        public IEnumerable<GameDto> GetAll()
        {
            var games = _gameRepository.GetAll();
            return _mapper.Map<IEnumerable<GameDto>>(games);
        }

        public void CreateGame(CreateGameDto createGameDto)
        {
            var game = _mapper.Map<Game>(createGameDto);
            // Perform any additional logic or validation
            _gameRepository.Add(game);
        }

        public void UpdateGame(int id, UpdateGameDto updateGameDto)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                throw new NotFoundException("Game not found.");
            }

            _mapper.Map(updateGameDto, game);
            // Perform any additional logic or validation
            _gameRepository.Update(game);
        }

        public void DeleteGame(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                throw new NotFoundException("Game not found.");
            }

            // Perform any additional logic or validation
            _gameRepository.Delete(id);
        }
    }

}

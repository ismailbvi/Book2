using AutoMapper;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;
using GamingStore.BL.InerFaces;
using GamingStore.DL.InerFaces;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public GameDto GetGameById(int id)
    {
        Game game = _gameRepository.GetById(id);
        return _mapper.Map<GameDto>(game);
    }

    public IEnumerable<GameDto> GetAllGames()
    {
        IEnumerable<GameDto> games = _gameRepository.GetAll();
        return _mapper.Map<IEnumerable<GameDto>>(games);
    }

    public void AddGame(CreateGameDto gameDto)
    {
        Game game = _mapper.Map<Game>(gameDto);
        _gameRepository.Add(game);
    }

    public void UpdateGame(UpdateGameDto gameDto)
    {
        var game = _mapper.Map<Game>(gameDto);

        _gameRepository.Update(game);
    }

    public void DeleteGame(int id)
    {
        _gameRepository.Delete(id);
    }
}
using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;
using GamingStore.BL.InerFaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/games")]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet("{id}")]
    public ActionResult<GameDto> GetById(int id)
    {
        var game = _gameService.GetById(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpGet]
    public ActionResult<IEnumerable<GameDto>> GetAll()
    {
        var games = _gameService.GetAll();
        return Ok(games);
    }

    [HttpPost]
    public IActionResult CreateGame(CreateGameDto createGameDto)
    {
        // Perform any validation or additional logic
        _gameService.CreateGame(createGameDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGame(int id, UpdateGameDto updateGameDto)
    {
        // Perform any validation or additional logic
        _gameService.UpdateGame(id, updateGameDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGame(int id)
    {
        // Perform any validation or additional logic
        _gameService.DeleteGame(id);
        return Ok();
    }
}

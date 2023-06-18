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
    public ActionResult<GameDto> GetGameById(int id)
    {
        var game = _gameService.GetGameById(id);
        if (game == null)
        {
            return NotFound();
        }
        return Ok(game);
    }

    [HttpGet]
    public ActionResult<IEnumerable<GameDto>> GetAllGames()
    {
        var games = _gameService.GetAllGames();
        return Ok(games);
    }

    [HttpPost]
    public IActionResult AddGame(CreateGameDto gameDto)
    {
       
        _gameService.AddGame(gameDto);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGame(UpdateGameDto gameDto)
    {
        
        _gameService.UpdateGame(gameDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGame(int id)
    {
        
        _gameService.DeleteGame(id);
        return Ok();
    }
}

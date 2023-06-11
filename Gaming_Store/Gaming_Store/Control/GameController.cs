using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;
using GamingStore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gaming_Store.Control
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("GetAllGames")]
        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gameService.GetAll();
        }

        [HttpGet("GetById")]
        public async Task<Game> GetById(Guid id)
        {
            return await _gameService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task AddGame([FromBody] AddGameRequest gameRequest)
        {
            await _gameService.AddGame(gameRequest);
        }

        [HttpPost("Update")]
        public async Task UpdateGame([FromBody] UpdateGameRequest game)
        {
            await _gameService.UpdateGame(game);
        }

        [HttpDelete("Delete")]
        public void DeleteGame(Guid id)
        {
            _gameService.DeleteGame(id);
        }
    }
}

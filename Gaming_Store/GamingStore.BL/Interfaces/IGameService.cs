using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;

namespace GamingStore.BL.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task  AddGame(AddGameRequest game);
        Task DeleteGame(Guid id);
        Task UpdateGame(UpdateGameRequest game);
    }
}

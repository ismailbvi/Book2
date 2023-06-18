using Gaming_Store_Data.Data;
using Gaming_Store_Data.GameDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.BL.InerFaces
{
    public interface IGameService
    {
        GameDto GetGameById(int id);
        IEnumerable<GameDto> GetAllGames();
        void AddGame(CreateGameDto gameDto);
        void UpdateGame( UpdateGameDto gameDto);
        void DeleteGame(int id);
    }
}

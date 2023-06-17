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
        GameDto GetById(int id);
        IEnumerable<GameDto> GetAll();
        void CreateGame(CreateGameDto createGameDto);
        void UpdateGame(int id, UpdateGameDto updateGameDto);
        void DeleteGame(int id);
    }
}

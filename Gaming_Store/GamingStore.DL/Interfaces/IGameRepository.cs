using Gaming_Store_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.DL.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task AddGame(Game game);
        Task DeleteGame(Guid id);
        Task UpdateGame(Game game);
    }
}

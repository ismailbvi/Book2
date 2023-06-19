using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingStore.BL.InerFaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetById(Guid id);
        Task AddGame(AddGameRequest gameRequest);
        Task DeleteGame(Guid id);
    }
}

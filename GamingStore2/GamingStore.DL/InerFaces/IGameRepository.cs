using Gaming_Store_Data.Data;

namespace GamingStore.DL.InerFaces
{
    public interface IGameRepository
    {
        Task<Game> GetById(Guid id);
        Task<IEnumerable<Game>> GetAll();
        Task Add(Game game);
        Task Delete(Guid id);
    }
}

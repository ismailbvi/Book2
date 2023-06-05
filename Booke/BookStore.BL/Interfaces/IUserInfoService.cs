using BookStore.Models.Data.Users;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        Task Add(string email, string password);
        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}

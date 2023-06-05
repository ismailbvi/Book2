using BookStore.Models.Data.Users;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        Task Add(UserInfo userInfo);
        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}

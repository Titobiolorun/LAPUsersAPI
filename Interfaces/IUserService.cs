using LAPUsersAPI.Models;

namespace LAPUsersAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel?> GetUserByIdAsync(int id);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel?> UpdateUserAsync(int id, UserModel user);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> DeleteUsersAsync(List<int> ids);
    }
}

using MyFirstAPI.Models;

namespace MyFirstAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        
        Task<UserModel> GetUserByID(int id);

        Task<UserModel> AddUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user, int id);

        Task<bool> DeleteUser(int id);
    }
}

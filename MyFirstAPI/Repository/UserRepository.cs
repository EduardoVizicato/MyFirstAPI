using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Models;
using MyFirstAPI.Repository.Interfaces;

namespace MyFirstAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public UserRepository(TaskSystemDBContext taskSistemDBContext)
        {
            _dbContext = taskSistemDBContext;
        }
        public async Task<UserModel> AddUser(UserModel user)
        {
           _dbContext.Add(user);
            _dbContext.SaveChanges();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userId = await GetUserByID(id);

            if (userId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public  async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByID(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userId = await GetUserByID(id);

            if (userId == null) 
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no Banco de Dados.");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;

            _dbContext.Users.Update(userId);
            _dbContext.SaveChanges();
            return userId;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Models;
using MyFirstAPI.Repository.Interfaces;

namespace MyFirstAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;
        public TaskRepository(TaskSystemDBContext taskSystemDBContext)
        {
            _dbContext = taskSystemDBContext;
        }
        public async Task<TaskModel> AddTask(TaskModel Task)
        {
            await _dbContext.AddAsync(Task);
            await _dbContext.SaveChangesAsync();
            return Task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById != null)
            {
                throw new Exception($"Tarefa para o ID: {id} não encontrada no banco de dados");
            }
            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskModel> UpdateTask(TaskModel Task, int id)
        {
            TaskModel taskById = await GetTaskById(id);
            if (taskById != null)
            {
                throw new Exception($"Tarefa para o ID: {id} não encontrada no banco de dados");
            }
            taskById.Name = Task.Name;
            taskById.Description = Task.Description;
            taskById.Status = Task.Status;
            taskById.UserId = Task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }
    }
}

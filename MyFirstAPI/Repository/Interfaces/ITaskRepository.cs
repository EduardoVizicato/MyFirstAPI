using MyFirstAPI.Models;

namespace MyFirstAPI.Repository.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTask(TaskModel Task);
        Task<TaskModel> UpdateTask(TaskModel Task, int id);
        Task<bool> DeleteTask(int id);
    }
}

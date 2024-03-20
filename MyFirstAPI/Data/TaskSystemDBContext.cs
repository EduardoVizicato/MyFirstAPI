using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data.Map;
using MyFirstAPI.Models;

namespace MyFirstAPI.Data
{
    public class TaskSystemDBContext : DbContext
    {
        public TaskSystemDBContext(DbContextOptions<TaskSystemDBContext> options) : base(options)  
        {
                
        }

        public DbSet<UserModel> Users { get; set; } 

        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapcs());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

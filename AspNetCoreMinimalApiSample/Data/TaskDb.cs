using Microsoft.EntityFrameworkCore;
using AspNetCoreMinimalApiSample.Tasks;

namespace AspNetCoreMinimalApiSample.Data
{
    public class TaskDb : DbContext

    {
        public TaskDb(DbContextOptions<TaskDb> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
          modelBuilder.Entity<TaskItem>().HasData(
            new TaskItem { Id = 1, Name = "Task1", IsComplete = false },
            new TaskItem { Id = 2, Name = "Task2", IsComplete = true },
            new TaskItem { Id = 3, Name = "Task3", IsComplete = false }
        );
    }
}

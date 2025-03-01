using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AspNetCoreMinimalApiSample.Tasks
{
    public static class TasksEndpoints
    {
        public static void REgisterTasksEndpoints(this WebApplication app)
        {
            app.MapGet("/tasks", async (TaskDb db) =>
                await db.Tasks.ToListAsync());

            app.MapGet("/tasks/{id}", async (int id, TaskDb db) =>
            await db.Tasks.FindAsync(id)
                is Task task
                    ? Results.Ok(task)
                    : Results.NotFound());

        }
    }
}

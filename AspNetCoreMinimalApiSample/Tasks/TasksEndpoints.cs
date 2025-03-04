using Microsoft.EntityFrameworkCore;
using AspNetCoreMinimalApiSample.Data;

namespace AspNetCoreMinimalApiSample.Tasks
{
    public static class TasksEndpoints
    {
        public static void RegisterTasksEndpoints(this WebApplication app)
        {
            app.MapGet("/tasks", async (TaskDb db) =>
                await db.Tasks.ToListAsync());

            app.MapGet("/tasks/{id}", async (int id, TaskDb db) =>
            await db.Tasks.FindAsync(id)
                is TaskItem task
                    ? Results.Ok(task)
                    : Results.NotFound());

        }
    }
}

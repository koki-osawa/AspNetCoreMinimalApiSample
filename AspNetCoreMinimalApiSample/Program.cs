using Microsoft.EntityFrameworkCore;
using AspNetCoreMinimalApiSample.Tasks;
using AspNetCoreMinimalApiSample.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskDb>(options =>
    options.UseInMemoryDatabase("TaskDb"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDb>();
    db.Database.EnsureCreated();
}

app.MapGet("/", () => "Hello World!");

app.RegisterTasksEndpoints();
app.Run();

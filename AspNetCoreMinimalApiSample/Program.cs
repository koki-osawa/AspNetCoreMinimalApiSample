using Microsoft.EntityFrameworkCore;
using AspNetCoreMinimalApiSample.Tasks;
using AspNetCoreMinimalApiSample.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskDb>(options =>
    options.UseInMemoryDatabase("TaskDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.RegisterTasksEndpoints();
app.Run();

using PAW.Models;
using PAW.Business;
using PAW.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PM = PAW.Models;

var builder = WebApplication.CreateBuilder(args);

// Registrar dependencias
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskManager, TaskManager>();

var app = builder.Build();

// Minimal API Endpoints
app.MapPost("/tasks", async (PM.Task task, ITaskManager taskManager) =>
{
    var createdTask = await taskManager.CreateTaskAsync(task);
    return createdTask != null ? Results.Created($"/tasks/{createdTask.Id}", createdTask) : Results.BadRequest("Error al crear la tarea.");
});

app.MapGet("/tasks", async (ITaskManager taskManager) =>
{
    return Results.Ok(await taskManager.GetAllAsync());
});

app.MapGet("/tasks/{id}", async (int id, ITaskManager taskManager) =>
{
    var task = await taskManager.GetByIdAsync(id);
    return task != null ? Results.Ok(task) : Results.NotFound();
});

app.MapPut("/tasks/{id}", async (int id, PM.Task updatedTask, ITaskManager taskManager) =>
{
    var task = await taskManager.UpdateTaskAsync(id, updatedTask);
    return task != null ? Results.Ok(task) : Results.NotFound();
});

app.MapDelete("/tasks/{id}", async (int id, ITaskManager taskManager) =>
{
    bool deleted = await taskManager.DeleteTaskAsync(id);
    return deleted ? Results.NoContent() : Results.NotFound();
});

app.Run();

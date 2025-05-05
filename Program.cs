using Microsoft.EntityFrameworkCore;
using Minimal_api_net9;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "MinimalAPI NET 9", Version = "v1" });
});

builder.Services.AddDbContext<Appdbcontext>(opt => opt.UseInMemoryDatabase("TodoDb"));

var app = builder.Build();

#region Minimal API's

app.MapGet("/todos", async (Appdbcontext db) => await db.Todos.ToListAsync())
    .WithName("GetTodos")
    .WithOpenApi();

app.MapGet("/todos/{id}", async (int id, Appdbcontext db) => await db.Todos.FindAsync(id) is
        Todo todo ? Results.Ok(todo) : Results.NotFound())
        .WithName("GetTodoById")
        .WithOpenApi();

app.MapPost("/todos", async (Todo todo, Appdbcontext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{todo.Id}", todo);
}).WithName("AddNewTodo")
    .WithOpenApi();

app.MapPut("/todos/{id}", async (int id, Todo updatedTodo, Appdbcontext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Title = updatedTodo.Title;
    todo.IsComplete = updatedTodo.IsComplete;
    await db.SaveChangesAsync();

    return Results.NoContent();
}).WithName("UpdateTodo")
    .WithOpenApi();

app.MapDelete("/todos/{id}", async (int id, Appdbcontext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.Ok();
}).WithName("DeleteTodo")
    .WithOpenApi();

#endregion Minimal API's

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>

        opt.SwaggerEndpoint("/swagger/v1/swagger.json", "MinimalAPI NET 9")
    );
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
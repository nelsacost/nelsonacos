using api.clientes.Data;
using api.clientes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

builder.Services.AddDbContext<Programacion8vo>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/clientes/", async (Clientes clientes, Programacion8vo db) =>
{
    db.Clientes.Add(clientes);
    await db.SaveChangesAsync();

    return Results.Created($"/clientes/{clientes.Id}", clientes);
});

app.MapGet("/clientes/{id:int}", async (int id, Programacion8vo db) =>
{
    return await db.Clientes.FindAsync(id)
              is Clientes cliente ? Results.Ok(cliente) : Results.NotFound();
});

app.MapPost("/ciudad/", async (Ciudad ciudad, Programacion8vo db) =>
{
    db.Ciudad.Add(ciudad);
    await db.SaveChangesAsync();

    return Results.Created($"/ciudad/{ciudad.Id}", ciudad);
});

app.MapGet("/ciudad/{id:int}", async (int id, Programacion8vo db) =>
{
    return await db.Ciudad.FindAsync(id)
              is Ciudad ciudad ? Results.Ok(ciudad) : Results.NotFound();
});
app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
using Microsoft.EntityFrameworkCore;
using RaceStrategy.Api.Middleware;
using RaceStrategy.Application.Interfaces;
using RaceStrategy.Application.Services;
using RaceStrategy.Domain.Ports;
using RaceStrategy.Infrastructure.Persistence;
using RaceStrategy.Infrastructure.Persistence.Adapters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ITireRepository, TireRepository>();
builder.Services.AddScoped<IStrategyRepository, StrategyRepository>();

builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ITireService, TireService>();
builder.Services.AddScoped<IStrategyService, StrategyService>();

var app = builder.Build();

app.UseCors("AllowAngularLocalhost");

app.UseMiddleware<ApiKeyMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

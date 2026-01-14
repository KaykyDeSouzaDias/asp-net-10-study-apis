using ApiStudy.Configurations;
using ApiStudy.Repositories;
using ApiStudy.Repositories.Impl;
using ApiStudy.Services;
using ApiStudy.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddSerilogLogging();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(
    builder.Configuration,
    builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

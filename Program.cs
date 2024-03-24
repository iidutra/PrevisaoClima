using Microsoft.EntityFrameworkCore;
using PrevisaoClima.Interface;
using PrevisaoClima.Service;
using System.Data;
using static PrevisaoClima.Repository.MeteorologiaRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                      .AddEnvironmentVariables();

builder.Services.AddHttpClient<ServicoMeteorologia>();

builder.Services.AddScoped<IDbConnection>(sp =>
    new Microsoft.Data.SqlClient.SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));



// Registrar o ClimaRepository
builder.Services.AddScoped<IRepositorioMeteorologia, RepositorioMeteorologia>();
builder.Services.AddScoped<IServicoMeteorologia, ServicoMeteorologia>();
builder.Services.AddHttpClient<IApiClient, ApiClient>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

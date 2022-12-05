using SearchServiceTest;
using SearchServiceTest.Context;
using SearchServiceTest.Helpers;
using SearchServiceTest.Model.Service;
using SearchServiceTest.Repository;
using SearchServiceTest.Repository.JSON;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<JsonContext>(x => new JsonContext("Data.json"));
builder.Services.AddScoped<IRepository<BokaService>, JsonRepository<BokaService>>();
builder.Services.AddSingleton<IPositionCalculator, PositionCalculator>();
builder.Services.AddSingleton<ISimilarityCalculator, SimilarityCalculator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

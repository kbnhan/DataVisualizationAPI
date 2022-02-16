using DataVisualizationAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration for connecting to database.
var connectionString = builder.Configuration["ConnectionStrings:DataVizProject"];
var serverVersion = new MariaDbServerVersion(ServerVersion.AutoDetect(connectionString));

// Add services to the container.
builder.Services.AddDbContext<DataViz_ProjectContext>(options => options.UseMySql(connectionString, serverVersion));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


//--Krijimi i builder
using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//--E kom shtu per batabaze
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

//--E kom shtu per databaze
builder.Services.AddDbContext<WatchListContext>(options =>
options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))); 

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


//--Ku e bon run 1webApp
app.Run();

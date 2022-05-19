using JsonSqlApi.Domain;
using JsonSqlApi.Infrastructure;
using JsonSqlApi.Service.Mappers;
using JsonSqlApi.Service.ToDoItems.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseInMemoryDatabase("InMemory"));
builder.Services.AddMediatR(typeof(ToDoItemsQueryRequest).Assembly);
builder.Services.AddAutoMapper(typeof(ToDoMapper).Assembly);
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();

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

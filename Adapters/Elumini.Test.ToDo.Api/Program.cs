global using Elumini.Test.ToDo.Domain;

using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Application.Profiles;
using Elumini.Test.ToDo.Application.Services;
using Elumini.Test.ToDo.MessageBroker;
using Elumini.Test.ToDo.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IToDoQueuePublisher, ToDoQueuePublisher>();

builder.Services.AddAutoMapper(typeof(ToDoProfile));
builder.Services.AddDbContext<ToDoContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("ToDoConnection")));

builder.Services.AddMassTransit(bus =>
{
    bus.UsingRabbitMq((ctx, busConfigurator) =>
    {
        busConfigurator.Host(builder.Configuration.GetConnectionString("RabbitMq"));
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

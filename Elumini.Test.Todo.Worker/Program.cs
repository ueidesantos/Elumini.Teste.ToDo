using Elumini.Test.Todo.Worker;
using Elumini.Test.ToDo.Worker;
using MassTransit;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Logging.AddSerilog();

builder.Services.AddMassTransit(bus =>
{
    bus.AddConsumer<ToDoQueueConsumer>();
    bus.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMq"));
        cfg.ConnectReceiveObserver(new ToDoConsumerObserverExtensions());
        cfg.ServiceInstance(instance => 
        {
            instance.ConfigureJobServiceEndpoints();
            instance.ConfigureEndpoints(ctx);

        });
    });
});

var host = builder.Build();

host.Run();

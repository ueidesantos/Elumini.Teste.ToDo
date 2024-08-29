using MassTransit;

namespace Elumini.Test.ToDo.Worker
{
    public class ToDoQueueConsumer : IConsumer<Domain.ToDo>
    {
        public async Task Consume(ConsumeContext<Domain.ToDo> context)
        {
            Console.WriteLine($"MENSAGEM RECEBIDA: {context.Message.ToString()}");
        }
    }
}

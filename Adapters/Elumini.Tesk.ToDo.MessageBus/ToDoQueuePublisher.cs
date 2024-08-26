using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Domain;
using MassTransit;


namespace Elumini.Test.ToDo.MessageBroker
{
    public class ToDoQueuePublisher: IToDoQueuePublisher
    {
        private readonly IBus _bus;
        public ToDoQueuePublisher(IBus bus)
        {
            _bus = bus;
        }
        public async Task Enqueue(Domain.ToDo toDo)
        {
            Uri uri = new Uri("rabbitmq://localhost/ToDoQueue");
            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(toDo);
        }
    }
}

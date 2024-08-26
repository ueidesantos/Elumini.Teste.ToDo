using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elumini.Test.ToDo.Application.Ports
{
    public interface IToDoQueuePublisher
    {
        Task Enqueue(Domain.ToDo toDo);
    }
}

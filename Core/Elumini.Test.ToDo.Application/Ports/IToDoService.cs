using Elumini.Test.ToDo.Application.Ports.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elumini.Test.ToDo.Application.Ports
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> Get();
        Task<ToDoDto> Get(int id);
        Task Add(Domain.ToDo toDo);
        Task Update(Domain.ToDo toDo);
        Task Delete(int id);
    }
}

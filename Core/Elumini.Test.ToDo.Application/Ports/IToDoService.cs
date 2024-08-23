using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elumini.Test.ToDo.Application.Ports
{
    public interface IToDoService
    {
        Task<IEnumerable<Domain.ToDo>> Get();
        Task<Domain.ToDo> Get(int id);
        Task Add(Domain.ToDo toDo);
        Task Update(Domain.ToDo toDo);
        Task Delete(int id);
    }
}

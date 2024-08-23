
using Elumini.Test.ToDo;

namespace Elumini.Test.ToDo.Application.Ports
{
    public interface IToDoRepository
    {
        Task<IEnumerable<Domain.ToDo>> Get();
        Task<Domain.ToDo> Get(int id);
        Task Add(Domain.ToDo toDo);
        Task Update(Domain.ToDo toDo);
        Task Delete(int id);
    }
}

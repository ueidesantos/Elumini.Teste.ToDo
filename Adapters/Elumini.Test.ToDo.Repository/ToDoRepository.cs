using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Domain;
using System.Collections.Immutable;
using System.Linq;

namespace Elumini.Test.ToDo.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        readonly ToDoContext _toDoContext;

        public ToDoRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public async Task<IEnumerable<Domain.ToDo>> Get()
            => _toDoContext.ToDos.ToImmutableList();


        public async Task<Domain.ToDo?> Get(int id)
            => _toDoContext.ToDos.Find(id);

        public async Task Add(Domain.ToDo toDo)
        {
            _toDoContext.Add(toDo);
            _toDoContext.SaveChanges();

        }

        public async Task Update(Domain.ToDo toDo)
        {
            _toDoContext.Update(toDo);
            _toDoContext.SaveChanges();
        }
        public async Task Delete(int id)
        {
            _toDoContext.Remove(Get(id));
            _toDoContext.SaveChanges();
        }
    }
}

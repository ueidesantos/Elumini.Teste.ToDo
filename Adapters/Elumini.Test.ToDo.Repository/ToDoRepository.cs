using Elumini.Test.ToDo.Application.Ports;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

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
            => await _toDoContext.ToDos.FindAsync(id);

        public async Task Add(Domain.ToDo toDo)
        {
            _toDoContext.Add(toDo);
            await _toDoContext.SaveChangesAsync();

        }

        public async Task Update(Domain.ToDo toDo)
        {
            _toDoContext.Update(toDo);
            await _toDoContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            _toDoContext.Remove(Get(id));
            await _toDoContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        => await _toDoContext.ToDos.AnyAsync(x => x.Id == id);

    }
}

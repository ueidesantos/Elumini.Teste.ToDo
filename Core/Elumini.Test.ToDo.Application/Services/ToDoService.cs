using Elumini.Test.ToDo.Application.Ports;

namespace Elumini.Test.ToDo.Application.Services
{
    public class ToDoService : IToDoService
    {
        readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<IEnumerable<Domain.ToDo>> Get()
        {
            try
            {
                return await _toDoRepository.Get();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Domain.ToDo> Get(int id)
            => await _toDoRepository.Get(id);

        public async Task Add(Domain.ToDo toDo)
            => await _toDoRepository.Add(toDo);

        public async Task Update(Domain.ToDo toDo)
        {


            try
            {
                var result = await Get(toDo.Id);
                if (result is null)
                    throw new ArgumentNullException("Tarefa não encontrada.");

                result.DtUpdated = DateTime.Now;
                await _toDoRepository.Update(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}

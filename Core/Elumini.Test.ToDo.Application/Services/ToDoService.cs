using AutoMapper;
using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Application.Ports.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Elumini.Test.ToDo.Application.Services
{
    public class ToDoService : IToDoService
    {
        readonly IToDoRepository _toDoRepository;
        readonly ILogger<ToDoService> _logger;
        readonly IMapper _mapper;
        readonly IConfiguration _configuration;

        public ToDoService(
            IToDoRepository toDoRepository, 
            ILogger<ToDoService> logger,
            IMapper mapper,
            IConfiguration configuration)
        {
            _toDoRepository = toDoRepository;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<ToDoDto>> Get()
        {
            try
            {
                await TraceMe(message: "Obtendo tarefas.");

                var toDos = await _toDoRepository.Get();

                return _mapper.Map<IEnumerable<ToDoDto>>(toDos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task<ToDoDto> Get(int id)
        {
            try
            {
                await TraceMe(message: "Obtendo tarefa por Id.");

                var toDo = await _toDoRepository.Get(id);
                
                return _mapper.Map<ToDoDto>(toDo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task Add(Domain.ToDo toDo)
        {
            await TraceMe(message: "Adicionando tarefa.");
            await _toDoRepository.Add(toDo);
            return;
        }
        public async Task Update(Domain.ToDo toDo)
        {

            try
            {
                var taskfound = await _toDoRepository.Exists(toDo.Id);
                if (!taskfound)
                {
                    await TraceMe(message: "Tarefa não encontrada.");
                    throw new ArgumentNullException("Tarefa não encontrada.");
                }

                _logger.LogInformation("Atualizando tarefa.");
                toDo.DtUpdated = DateTime.Now;
                await _toDoRepository.Update(toDo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await TraceMe(message: "Excluindo tarefa.");
                await _toDoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        
        private async Task TraceMe(string message)
        {
            var logInformation = false;
            bool.TryParse(_configuration.GetSection("TurnOnLogInformationService").Value, out logInformation);
            if (logInformation) 
            {
                _logger.LogInformation(message);
            };
        }
    }
}

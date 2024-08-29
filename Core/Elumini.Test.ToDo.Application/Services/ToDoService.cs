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
        readonly IToDoQueuePublisher _toDoQueuePublisher;
        public ToDoService(
            IToDoRepository toDoRepository, 
            ILogger<ToDoService> logger,
            IMapper mapper,
            IConfiguration configuration,
            IToDoQueuePublisher toDoQueuePublisher)
        {
            _toDoRepository = toDoRepository;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
            _toDoQueuePublisher = toDoQueuePublisher;
        }

        public async Task<IEnumerable<ToDoDto>> Get()
        {
            await TraceMe(message: "Obtendo tarefas.");
            try
            {
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
            await TraceMe(message: "Obtendo tarefa por Id.");
            try
            {
                

                var toDo = await _toDoRepository.Get(id);
                
                return _mapper.Map<ToDoDto>(toDo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public async Task Add(ToDoCreateDto toDo)
        {
            await TraceMe(message: "Adicionando tarefa.");

            Validate(toDo);
            await Create(toDo);

            return;
        }
        public async Task Update(ToDoUpdateDto toDo)
        {
            await TraceMe(message: "Atualizando tarefa.");
            try
            {
                Validate(toDo);
                var taskfound = await _toDoRepository.Exists(toDo.Id);
                if (!taskfound)
                {
                    _logger.LogError($"Tarefa não encontrada (Id: {toDo.Id}).");
                    await TraceMe(message: "");
                    throw new ArgumentNullException($"Tarefa não encontrada. (Id: {toDo.Id}))");
                }
                
                toDo.DtUpdated = DateTime.Now;
                await _toDoRepository.Update(_mapper.Map<Domain.ToDo>(toDo));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public async Task Delete(int id)
        {
            await TraceMe(message: "Excluindo tarefa.");
            try
            {
                await _toDoRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        private async Task Create(ToDoCreateDto toDo)
        {
            toDo.DtCreated = DateTime.Now;
            await _toDoRepository.Add(_mapper.Map<Domain.ToDo>(toDo));
            await _toDoQueuePublisher.Enqueue(_mapper.Map<Domain.ToDo>(toDo));
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
        private void Validate(IToDo toDo)
        {
            var toDoValidator = new ToDoValidator();
            var resultValidation = toDoValidator.Validate(toDo);
            if (!resultValidation.IsValid)
            {
                var exception = new ArgumentException("Dados inválidos.");
                resultValidation.Errors.ForEach(x => exception.Data.Add(x.ErrorCode, x.ErrorMessage));
                resultValidation.Errors.ForEach(x => _logger.LogError(x.ErrorMessage));
                throw exception;
            }
        }
    }
}

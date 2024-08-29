using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Application.Ports.Dtos;
using Elumini.Test.ToDo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Elumini.Test.ToDo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDto>>> Get()
        {
            var result = await _toDoService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IAsyncEnumerable<ToDoDto>>> Get(int id)
        {
            var result = await _toDoService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ToDoCreateDto toDo)
        {
            await _toDoService.Add(toDo);
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ToDoUpdateDto toDo)
        {
            await _toDoService.Update(toDo);
            return Ok(toDo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _toDoService.Delete(id);
            return NoContent();
        }
    }
}

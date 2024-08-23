using Elumini.Test.ToDo.Application.Ports;
using Elumini.Test.ToDo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Elumini.Test.ToDo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {
        readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.ToDo>>> Get()
        {
            var result1 = await _toDoService.Get();
            return Ok(result1);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IAsyncEnumerable<Domain.ToDo>>> Get(int id)
        {
            var result = await _toDoService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Domain.ToDo toDo)
        {
            await _toDoService.Add(toDo);
            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Domain.ToDo toDo)
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

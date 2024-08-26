using Elumini.Test.ToDo.Application.Ports.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elumini.Teste.ToDo.Test.Mocks
{
    public class ToDoMock
    {
        
        public static ToDoCreateDto BuildMock()
        {
            ToDoCreateDto _toDoMock = new ToDoCreateDto();
            _toDoMock.Description = $@"DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription
DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription
DescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescriptionDescription";
            _toDoMock.Status = Elumini.Test.ToDo.Domain.Status.InProgress;
            _toDoMock.DtConclusion = DateTime.Now.AddDays(1);
            return _toDoMock;
        }
    }
}

using Elumini.Test.ToDo.Application.Ports.Dtos;
using Elumini.Test.ToDo.Domain;
using FluentValidation;

namespace Elumini.Test.ToDo.Application.Services
{
    public class ToDoValidator : AbstractValidator<IToDo>
    {
        public ToDoValidator()
        {
            RuleFor(toDo => toDo.Description)
                .MaximumLength(150)
                .WithMessage("O campo Descrição deve ter no máximo 150 caracteres.");

            RuleFor(toDo => toDo.DtConclusion)
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("O campo Data Conlusão deve ser maior ou igual a data de hoje");
        }
    }
}

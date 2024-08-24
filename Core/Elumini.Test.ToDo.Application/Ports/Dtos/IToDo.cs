using Elumini.Test.ToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elumini.Test.ToDo.Application.Ports.Dtos
{
    public interface IToDo
    {
        public string Description { get; set; }
        public DateTime DtConclusion { get; set; }
        public Status Status { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
    }
}

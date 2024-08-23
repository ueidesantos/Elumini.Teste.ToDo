namespace Elumini.Test.ToDo.Domain
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DtConclusion { get; set; }
        public Status Status{ get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
    }
}

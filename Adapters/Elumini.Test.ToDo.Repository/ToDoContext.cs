using Microsoft.EntityFrameworkCore;

namespace Elumini.Test.ToDo.Repository
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        public DbSet<Domain.ToDo> ToDos { get; set; }
    }
}

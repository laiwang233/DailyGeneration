using Entities;
using EntityFrameworkCore;

namespace Repository;

public class TodoRepository : BaseRepository<Todo, Guid>
{
    public TodoRepository(TodoDbContext todoDbContext) : base(todoDbContext)
    {
    }
}
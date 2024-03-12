using DailyGeneration.Domain.Entities;
using DailyGeneration.Infrastructure.EntityFrameworkCore;

namespace DailyGeneration.Infrastructure.Repository;

public class TodoRepository : BaseRepository<Todo, Guid>
{
    public TodoRepository(TodoDbContext todoDbContext) : base(todoDbContext)
    {
    }
}
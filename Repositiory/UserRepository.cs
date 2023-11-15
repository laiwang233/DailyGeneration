using Entities;
using EntityFrameworkCore;

namespace Repository;

public class UserRepository : BaseRepository<User, Guid>
{
    public UserRepository(TodoDbContext todoDbContext) : base(todoDbContext)
    {
    }
}
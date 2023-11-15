using Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DbSet<User> Users { get; set; }

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
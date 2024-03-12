using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EntityFrameworkCore
{
    public class TodoDbContext : IdentityDbContext<User, Role, string>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            //这行是必要的，因为方法内包含了User和Role的实体配置
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<Role>().HasData(new Role { Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}
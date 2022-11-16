using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoListSolution.Configurations;
using TodoListSolution.Extensions;
using TodoListSolution.Models;

namespace TodoListSolution.DataContext
{
    public partial class DataDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DataDbContext()
        {
        }

        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //Configure using Fluent API 
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
           
            modelBuilder.ApplyConfiguration(new TaskConfiguration());

            //Data seeding
            modelBuilder.Seed();
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

    }
}

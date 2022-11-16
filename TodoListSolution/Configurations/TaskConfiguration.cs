using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TodoListSolution.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TodoListSolution.Models.Task>
    {
        public void Configure(EntityTypeBuilder<TodoListSolution.Models.Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => x.Id);
        }
    }
}

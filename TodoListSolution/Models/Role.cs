using Microsoft.AspNetCore.Identity;

namespace TodoListSolution.Models
{
    public class Role : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}

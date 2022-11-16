using Microsoft.AspNetCore.Identity;

namespace TodoListSolution.Models
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FullName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? UrlAvatar { get; set; }
    }
}

namespace TodoListSolution.Models
{
    public class Task : AuditableBaseEntity
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}

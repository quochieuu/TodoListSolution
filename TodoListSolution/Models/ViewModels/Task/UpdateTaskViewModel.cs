namespace TodoListSolution.Models.ViewModels.Task
{
    public class UpdateTaskViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}

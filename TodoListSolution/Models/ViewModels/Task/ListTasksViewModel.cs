namespace TodoListSolution.Models.ViewModels.Task
{
    public class ListTasksViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}

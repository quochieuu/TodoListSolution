using TodoListSolution.Models.ViewModels;
using TodoListSolution.Models.ViewModels.Task;

namespace TodoListSolution.Repository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAll();
        Task<RepositoryResponse> Create(CreateTaskViewModel model);
        Task<RepositoryResponse> Update(UpdateTaskViewModel model);
        System.Threading.Tasks.Task Delete(Guid id);
        System.Threading.Tasks.Task<bool> UpdateCompleted(Guid id);
    }
}

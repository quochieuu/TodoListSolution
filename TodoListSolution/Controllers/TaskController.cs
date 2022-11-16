using Microsoft.AspNetCore.Mvc;
using TodoListSolution.Models.ViewModels;
using TodoListSolution.Models.ViewModels.Task;
using TodoListSolution.Repository;

namespace TodoListSolution.Controllers
{
    [Route("task")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [Route("")]
        // API: https://localhost:7011/task
        public async Task<IEnumerable<Models.Task>> Index()
        {
            var listTasks = await _taskRepository.GetAll();
            return listTasks;
        }

        [HttpPost("create")]
        public async Task<RepositoryResponse> Create(CreateTaskViewModel model)
        {
            var result = await _taskRepository.Create(model);
            return result;
        }

        [HttpGet("mark-completed/{id}")]
        public async Task<bool> MarkCompleted(Guid id)
        {
            var result = await _taskRepository.UpdateCompleted(id);
            return result;
        }

        [HttpGet("delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _taskRepository.Delete(id);
        }
    }
}

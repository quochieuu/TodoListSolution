using Microsoft.EntityFrameworkCore;
using TodoListSolution.DataContext;
using TodoListSolution.Models.ViewModels;
using TodoListSolution.Models.ViewModels.Task;

namespace TodoListSolution.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataDbContext _context;
        public TaskRepository(DataDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Task>> GetAll()
        {
            var item = await _context.Tasks.Where(x => !x.IsDeleted).OrderByDescending(o => o.CreatedTime).ToListAsync();
            return item;
        }

        public async Task<RepositoryResponse> Create(CreateTaskViewModel model)
        {
            Models.Task item = new Models.Task()
            {
                Title = model.Title,
                IsCompleted = false,
                CreatedTime = DateTime.Now,
                CreatedBy = "root",
                LastModifiedBy = "root",
                IsDeleted = false
            };
            _context.Tasks.Add(item);
            var result = await _context.SaveChangesAsync();

            return new RepositoryResponse()
            {
                Result = result,
                Id = item.Id,
            };
        }

        public async Task<RepositoryResponse> Update(UpdateTaskViewModel model)
        {
            var item = await _context.Tasks.FindAsync(model.Id);

            item.Title = model.Title;
            item.IsCompleted = model.IsCompleted;
            item.LastModifiedBy = "root";
            item.LastModifiedTime = DateTime.Now;
            item.IsDeleted = false;
            _context.Tasks.Update(item);
            var result = await _context.SaveChangesAsync();
            return new RepositoryResponse()
            {
                Result = result,
                Id = item.Id,
            };
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            var item = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task<bool> UpdateCompleted(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            task.IsCompleted = !task.IsCompleted;
            _context.Update(task);
            await _context.SaveChangesAsync();

            return !task.IsCompleted;
        }
    }
}

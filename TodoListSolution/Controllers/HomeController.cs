using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoListSolution.Models;
using TodoListSolution.Repository;

namespace TodoListSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public HomeController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult Index()
        {
            var listTasks = _taskRepository.GetAll();
            return View(listTasks);
        }
    }
}
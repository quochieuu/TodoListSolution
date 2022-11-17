using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListSolution.Models;

namespace TodoListSolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/roles")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        public RoleManagerController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                var rol = new Role()
                {
                    Name = roleName.Trim()
                };
                await _roleManager.CreateAsync(rol);
            }
            return RedirectToAction("Index");
        }
    }
}

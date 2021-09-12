using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Taskly.Services.Interfaces;
using Taskly.Web.InputModels;

namespace Taskly.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(TaskInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await taskService.AddTaskToProjectAsync(inputModel.Title, inputModel.Description, inputModel.ProjectId, userId);

            return RedirectToAction("Current", "Project" , new { guid = inputModel.ProjectGuid });
        }
    }
}

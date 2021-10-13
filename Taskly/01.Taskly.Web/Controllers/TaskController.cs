using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Taskly.Services.Interfaces;
using Taskly.Web.InputModels;
using Taskly.Web.ViewModels;

namespace Taskly.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
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

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Complete(int taskId, string projectGuid)
        {
            await taskService.CompleteTaskAsync(taskId);

            return RedirectToAction("Current", "Project", new { guid = projectGuid });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Uncomplete(int taskId, string projectGuid)
        {
            await taskService.UncompleteTaskAsync(taskId);

            return RedirectToAction("Current", "Project", new { guid = projectGuid });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePriority(int taskId, int priorityId, string projectGuid)
        {
            await taskService.AddTaskPriorityAsync(taskId, priorityId);

            return RedirectToAction("Current", "Project", new { guid = projectGuid });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCurrentTaskById(string taskGuid)
        {
            var task = taskService.GetTaskByGuid(taskGuid);
            var viewModel = mapper.Map<TaskViewModel>(task);

            return PartialView("~/Views/Task/_CurrentTaskModalPartial.cshtml", viewModel);
        }
    }
}
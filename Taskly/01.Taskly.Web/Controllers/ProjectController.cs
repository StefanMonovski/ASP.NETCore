using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Taskly.Data.Models;
using Taskly.Services.Interfaces;
using Taskly.Web.EditModels;
using Taskly.Web.InputModels;
using Taskly.Web.ViewModels;

namespace Taskly.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IProjectUserService projectUserService;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ProjectController(IProjectService projectService, IProjectUserService projectUserService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.projectService = projectService;
            this.projectUserService = projectUserService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(ProjectInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string guid = await projectService.AddProjectAsync(inputModel.Title, inputModel.ColorPicker, userId);

            return RedirectToAction("Current", new { guid });
        }

        [HttpGet]
        [Authorize]
        public IActionResult Current(string guid)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var project = projectService.GetProjectByGuid(guid, userId);
            var projectViewModel = mapper.Map<ProjectViewModel>(project);

            return View(projectViewModel);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToFavorite(int projectId, string projectGuid)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await projectUserService.AddProjectToUserFavoritesAsync(projectId, userId);

            return RedirectToAction("Current", new { guid = projectGuid });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveFromFavorite(int projectId, string projectGuid)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await projectUserService.RemoveProjectFromUserFavoritesAsync(projectId, userId);

            return RedirectToAction("Current", new { guid = projectGuid });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ProjectEditModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            await projectService.UpdateProjectTitleAsync(editModel.Id, editModel.Title);
            await projectService.UpdateProjectColorAsync(editModel.Id, editModel.ColorPicker);

            return RedirectToAction("Current", new { guid = editModel.Guid });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUser(ProjectUserInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            ApplicationUser user = await userManager.FindByNameAsync(inputModel.Username);
            await projectUserService.AddUserToProjectAsync(inputModel.ProjectId, user.Id, inputModel.IsCollaborator);

            return RedirectToAction("Current", new { guid = inputModel.ProjectGuid });
        }
    }
}
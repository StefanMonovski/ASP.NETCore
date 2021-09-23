﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;
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
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ProjectController(IProjectService projectService, IProjectUserService projectUserService, IUserService userService, IMapper mapper)
        {
            this.projectService = projectService;
            this.projectUserService = projectUserService;
            this.userService = userService;
            this.mapper = mapper;
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

            string userId = userService.GetUserByUsername(inputModel.Username).Id;
            await projectUserService.AddUserToProjectAsync(inputModel.ProjectId, userId, inputModel.IsCollaborator);

            return RedirectToAction("Current", new { guid = inputModel.ProjectGuid });
        }

        [HttpGet]
        [HttpPost]
        [Authorize]
        public IActionResult UsernameIsValid(string username)
        {
            string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            UserDto user = userService.GetUserByUsername(username);

            if (user == null)
            {
                return Json($"Username {username} does not exist.");
            }
            else if (user.Id == currentUserId)
            {
                return Json("Cannot add own username.");
            }

            return Json(true);
        }
    }
}
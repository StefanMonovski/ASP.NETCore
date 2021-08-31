using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Taskly.Services.Interfaces;
using Taskly.Web.ViewModels;

namespace Taskly.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.projectService = projectService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = projectService.GetAllProjects(userId);
            var projectsViewModel = mapper.Map<List<ProjectsViewModel>>(projects);

            return View(projectsViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Personal()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = projectService.GetAllPersonalProjects(userId);
            var projectsViewModel = mapper.Map<List<ProjectsViewModel>>(projects);

            return View(projectsViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Favorite()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = projectService.GetAllFavoriteProjects(userId);
            var projectsViewModel = mapper.Map<List<ProjectsViewModel>>(projects);

            return View(projectsViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Collaborative()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = projectService.GetAllCollaborativeProjects(userId);
            var projectsViewModel = mapper.Map<List<ProjectsViewModel>>(projects);

            return View(projectsViewModel);
        }
    }
}

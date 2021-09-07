using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Taskly.Services.DataTransferObjects;
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
        public IActionResult Display(string filter)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var projects = new List<ProjectDto>();
            switch (filter)
            {
                case "All": projects = projectService.GetAllProjects(userId); break;
                case "Personal": projects = projectService.GetAllPersonalProjects(userId); break;
                case "Collaborative": projects = projectService.GetAllCollaborativeProjects(userId); break;
                case "Favorite": projects = projectService.GetAllFavoriteProjects(userId); break;
            }

            var displayViewModel = new DisplayViewModel()
            {
                Filter = filter,
                Projects = mapper.Map<List<ProjectsViewModel>>(projects)
            };

            return View(displayViewModel);
        }
    }
}
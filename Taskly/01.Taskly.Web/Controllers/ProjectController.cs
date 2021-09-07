using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Taskly.Services.Interfaces;
using Taskly.Web.InputModels;

namespace Taskly.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
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
    }
}
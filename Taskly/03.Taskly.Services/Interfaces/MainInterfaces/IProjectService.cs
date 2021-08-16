using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IProjectService
    {
        Task<string> AddProjectAsync(string title, string userId, int? colorArgb);

        Task<string> DeleteProjectAsync(int projectId);

        Task<string> UpdateProjectTitleAsync(int projectId, string title);
        
        Task<string> UpdateProjectColorAsync(int projectId, int? colorArgb);

        Task<string> ArchiveProjectAsync(int projectId);

        Task<string> UnarchiveProjectAsync(int projectId);

        Task<string> AddToFavoritesAsync(int projectId, string userId);

        Task<string> RemoveFromFavoritesAsync(int projectId, string userId);

        Task<List<ProjectDto>> GetAllProjects(string userId);

        Task<List<ProjectDto>> GetAllPersonalProjects(string userId);

        Task<List<ProjectDto>> GetAllCollaborativeProjects(string userId);

        Task<ProjectDto> GetProject(int projectId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IProjectService
    {
        Task<string> AddProjectAsync(string title, int? colorArgb, string userId);

        Task<string> DeleteProjectAsync(int projectId);

        Task<string> UpdateProjectTitleAsync(int projectId, string title);
        
        Task<string> UpdateProjectColorAsync(int projectId, int? colorArgb);

        Task<string> ArchiveProjectAsync(int projectId);

        Task<string> UnarchiveProjectAsync(int projectId);

        List<ProjectDto> GetAllProjects(string userId);

        List<ProjectDto> GetAllPersonalProjects(string userId);

        List<ProjectDto> GetAllCollaborativeProjects(string userId);

        List<ProjectDto> GetAllFavoriteProjects(string userId);

        ProjectDto GetProjectById(int projectId);

        ProjectDto GetProjectByGuid(string projectGuid);
    }
}

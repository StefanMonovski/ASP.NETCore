﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IProjectService
    {
        Task<string> AddProjectAsync(string title, string colorHex, string userId);

        Task<string> DeleteProjectAsync(int projectId);

        Task<string> UpdateProjectTitleAsync(int projectId, string title);
        
        Task<string> UpdateProjectColorAsync(int projectId, string colorHex);

        Task<string> ArchiveProjectAsync(int projectId);

        Task<string> UnarchiveProjectAsync(int projectId);

        List<ProjectDto> GetAllProjects(string userId);

        List<ProjectDto> GetAllPersonalProjects(string userId);

        List<ProjectDto> GetAllCollaborativeProjects(string userId);

        List<ProjectDto> GetAllFavoriteProjects(string userId);

        List<ProjectDto> GetAllArchivedProjects(string userId);

        ProjectDto GetProjectById(int projectId, string userId);

        ProjectDto GetProjectByGuid(string projectGuid, string userId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IProjectUserService
    {
        Task AddUserToProjectAsync(int projectId, string userId, bool isCollaborator);

        Task AddUserRangeToProjectAsync(int projectId, List<string> usersIds, bool areCollaborators);

        Task DeleteUserFromProjectAsync(int projectId, string userId);

        Task DeleteUserRangeFromProjectAsync(int projectId, List<string> usersIds);

        Task AddUserAsCollaboratorAsync(int projectId, string userId);

        Task RemoveUserAsCollaboratorAsync(int projectId, string userId);

        Task AddProjectToUserFavoritesAsync(int projectId, string userId);

        Task RemoveProjectFromUserFavoritesAsync(int projectId, string userId);

        List<ProjectUserDto> GetAllUsersByProject(int projectId);
    }
} 

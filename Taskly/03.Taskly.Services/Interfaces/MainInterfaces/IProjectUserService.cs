using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IProjectUserService
    {
        Task<string> AddUserToProjectAsync(int projectId, string userId, bool isCollaborator);

        Task<string> AddUserRangeToProjectAsync(int projectId, List<string> usersIds, bool areCollaborators);

        Task<string> DeleteUserFromProjectAsync(int projectId, string userId);

        Task<string> DeleteUserRangeFromProjectAsync(int projectId, List<string> usersIds);

        Task<string> AddUserAsCollaboratorAsync(int projectId, string userId);

        Task<string> RemoveUserAsCollaboratorAsync(int projectId, string userId);

        Task<List<ProjectUserDto>> GetAllUsersByProject(int projectId);
    }
} 

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Taskly.Services.Services
{
    public class ProjectUserService : IProjectUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProjectUserService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddUserToProjectAsync(int projectId, string userId, bool isCollaborator)
        {
            ProjectUser projectUser = new()
            {
                ProjectId = projectId,
                UserId = userId,
                IsCollaborator = isCollaborator,
                IsCreator = false
            };

            await context.ProjectsUsers.AddAsync(projectUser);
            await context.SaveChangesAsync();

            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.IsPersonal = false;
            await context.SaveChangesAsync();
        }

        public async Task AddUserRangeToProjectAsync(int projectId, List<string> usersIds, bool areCollaborators)
        {
            List<ProjectUser> projectUsers = new();

            foreach (var userId in usersIds)
            {
                projectUsers.Add(new ProjectUser()
                {
                    ProjectId = projectId,
                    UserId = userId,
                    IsCollaborator = areCollaborators
                });
            }

            await context.AddRangeAsync(projectUsers);
            await context.SaveChangesAsync();

            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.IsPersonal = false;
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserFromProjectAsync(int projectId, string userId)
        {
            ProjectUser projectUser = context.ProjectsUsers
                .Where(x => x.ProjectId == projectId && x.UserId == userId)
                .FirstOrDefault();

            context.Remove(projectUser);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserRangeFromProjectAsync(int projectId, List<string> usersIds)
        {
            List<ProjectUser> projectUsers = new();

            foreach (var userId in usersIds)
            {
                projectUsers.Add(
                    context.ProjectsUsers
                    .Where(x => x.ProjectId == projectId && x.UserId == userId)
                    .FirstOrDefault()
                    );
            }

            context.RemoveRange(projectUsers);
            await context.SaveChangesAsync();
        }

        public async Task AddUserAsCollaboratorAsync(int projectId, string userId)
        {
            ProjectUser projectUser = context.ProjectsUsers
                .Where(x => x.ProjectId == projectId && x.UserId == userId)
                .FirstOrDefault();

            projectUser.IsCollaborator = true;
            await context.SaveChangesAsync();
        }

        public async Task RemoveUserAsCollaboratorAsync(int projectId, string userId)
        {
            ProjectUser projectUser = context.ProjectsUsers
                .Where(x => x.ProjectId == projectId && x.UserId == userId)
                .FirstOrDefault();

            projectUser.IsCollaborator = false;
            await context.SaveChangesAsync();
        }

        public List<ProjectUserDto> GetAllUsersByProject(int projectId)
        {
            List<ProjectUserDto> projectUsersDto = context.ProjectsUsers
                .Where(x => x.ProjectId == projectId)
                .ProjectTo<ProjectUserDto>(mapper.ConfigurationProvider)
                .ToList();

            return projectUsersDto;
        }
    }
}

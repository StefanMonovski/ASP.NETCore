using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddProjectAsync(string title, int? colorArgb, string userId)
        {
            Project project = new()
            {
                Title = title,
                ColorArgb = colorArgb,
            };

            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();

            ProjectUser projectUser = new()
            {
                ProjectId = project.Id,
                UserId = userId,
                IsCreator = true,
                IsCollaborator = false
            };

            await context.ProjectsUsers.AddAsync(projectUser);
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public async Task<string> DeleteProjectAsync(int projectId)
        {
            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            context.Projects.Remove(project);
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public async Task<string> UpdateProjectTitleAsync(int projectId, string title)
        {
            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.Title = title;
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public async Task<string> UpdateProjectColorAsync(int projectId, int? colorArgb)
        {
            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.ColorArgb = colorArgb;
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public async Task<string> ArchiveProjectAsync(int projectId)
        {
            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.IsArchived = true;
            project.ArchivedOn = DateTime.UtcNow;
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public async Task<string> UnarchiveProjectAsync(int projectId)
        {
            Project project = context.Projects
                .Where(x => x.Id == projectId)
                .FirstOrDefault();

            project.IsArchived = false;
            project.ArchivedOn = null;
            await context.SaveChangesAsync();

            return project.Guid;
        }

        public List<ProjectDto> GetAllProjects(string userId)
        {
            List<ProjectDto> projectsDto = context.ProjectsUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Project)
                .ProjectTo<ProjectDto>(mapper.ConfigurationProvider)
                .ToList();

            return projectsDto;
        }

        public List<ProjectDto> GetAllPersonalProjects(string userId)
        {
            List<ProjectDto> projectsDto = context.ProjectsUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Project)
                .Where(x => x.IsPersonal == true)
                .ProjectTo<ProjectDto>(mapper.ConfigurationProvider)
                .ToList();

            return projectsDto;
        }

        public List<ProjectDto> GetAllCollaborativeProjects(string userId)
        {
            List<ProjectDto> projectsDto = context.ProjectsUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Project)
                .Where(x => x.IsPersonal == false)
                .ProjectTo<ProjectDto>(mapper.ConfigurationProvider)
                .ToList();

            return projectsDto;
        }

        public List<ProjectDto> GetAllFavoriteProjects(string userId)
        {
            List<ProjectDto> projectsDto = context.ProjectsUsers
                .Where(x => x.UserId == userId && x.IsProjectFavorite == true)
                .Select(x => x.Project)
                .ProjectTo<ProjectDto>(mapper.ConfigurationProvider)
                .ToList();

            return projectsDto;
        }

        public ProjectDto GetProject(int projectId)
        {
            ProjectDto projectDto = context.Projects
                .Where(x => x.Id == projectId)
                .ProjectTo<ProjectDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return projectDto;
        }
    }
}

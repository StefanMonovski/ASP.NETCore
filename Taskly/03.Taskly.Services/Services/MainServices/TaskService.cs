using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;
using Task = Taskly.Data.Models.Task;

namespace Taskly.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TaskService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddTaskToProjectAsync(string title, string description, int projectId, string userId)
        {
            Task task = new()
            {
                Title = title,
                Description = description,
                ProjectId = projectId,
                CreatorId = userId,
                PriorityId = 4
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> AddSubTaskToTaskAsync(string title, string description, int projectId, string userId, int parentTaskId)
        {
            Task task = new()
            {
                Title = title,
                Description = description,
                ProjectId = projectId,
                CreatorId = userId,
                ParentTaskId = parentTaskId,
                PriorityId = 4
            };

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> DeleteTaskAsync(int taskId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> UpdateTaskTitleAsync(int taskId, string title)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.Title = title;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> UpdateTaskDescription(int taskId, string description)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.Description = description;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> ScheduleTaskAsync(int taskId, DateTime schedule)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.Schedule = schedule;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> UnscheduleTaskAsync(int taskId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.Schedule = null;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> AddTaskPriorityAsync(int taskId, int priorityId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.PriorityId = priorityId;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> RemoveTaskPriorityAsync(int taskId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.PriorityId = null;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> CompleteTaskAsync(int taskId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.IsCompleted = true;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public async Task<string> UncompleteTaskAsync(int taskId)
        {
            Task task = context.Tasks
                .Where(x => x.Id == taskId)
                .FirstOrDefault();

            task.IsCompleted = false;
            await context.SaveChangesAsync();

            return task.Guid;
        }

        public List<TaskDto> GetAllTasksByProject(int projectId)
        {
            List<TaskDto> tasksDto = context.Tasks
                .Where(x => x.ProjectId == projectId && x.ParentTaskId == null)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .ToList();

            return tasksDto;
        }

        public List<TaskDto> GetAllIncompletedTasksByProject(int projectId)
        {
            List<TaskDto> tasksDto = context.Tasks
                .Where(x => x.ProjectId == projectId && x.ParentTaskId == null && x.IsCompleted == false)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .ToList();

            return tasksDto;
        }

        public List<TaskDto> GetAllSubTasksByTask(int parentTaskId)
        {
            List<TaskDto> tasksDto = context.Tasks
                .Where(x => x.ParentTaskId == parentTaskId)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .ToList();

            return tasksDto;
        }

        public List<TaskDto> GetAllIncompletedSubTasksByProject(int parentTaskId)
        {
            List<TaskDto> tasksDto = context.Tasks
                .Where(x => x.ParentTaskId == parentTaskId && x.IsCompleted == false)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .ToList();

            return tasksDto;
        }

        public TaskDto GetTaskById(int taskId)
        {
            TaskDto taskDto = context.Tasks
                .Where(x => x.Id == taskId)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return taskDto;
        }

        public TaskDto GetTaskByGuid(string taskGuid)
        {
            TaskDto taskDto = context.Tasks
                .Where(x => x.Guid == taskGuid)
                .ProjectTo<TaskDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return taskDto;
        }
    }
}

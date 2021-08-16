using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface ITaskService
    {
        Task<string> AddTaskToProjectAsync(string title, string description, int projectId, string userId);

        Task<string> AddSubTaskToTaskAsync(string title, string description, int projectId, string userId, int parentTaskId);

        Task<string> DeleteTaskAsync(int taskId);

        Task<string> UpdateTaskTitleAsync(int taskId, string title);

        Task<string> UpdateTaskDescription(int taskId, string description);

        Task<string> ScheduleTaskAsync(int taskId, DateTime Schedule);

        Task<string> UnscheduleTaskAsync(int taskId);
        
        Task<string> AddTaskPriorityAsync(int taskId, int priorityId);

        Task<string> RemoveTaskPriorityAsync(int taskId);

        Task<string> CompleteTaskAsync(int taskId);

        Task<string> UncompleteTaskAsync(int taskId);

        Task<List<TaskDto>> GetAllTasksByProject(int projectId);

        Task<List<TaskDto>> GetAllSubTasksByTask(int parentTaskId);

        Task<TaskDto> GetTask(int taskId);
    }
}

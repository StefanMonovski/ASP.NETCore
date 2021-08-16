using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    interface ILabelTaskService
    {
        Task<string> AddLabelTaskAsync(int labelId, int taskId);

        Task<string> DeleteLabelTaskAsync(int labelId, int taskId);

        Task<List<LabelDto>> GetAllLabelsFromTask(int taskId);
    }
}

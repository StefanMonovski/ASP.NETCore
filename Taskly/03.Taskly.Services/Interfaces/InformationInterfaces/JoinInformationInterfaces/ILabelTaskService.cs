using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    public interface ILabelTaskService
    {
        Task AddLabelTaskAsync(int labelId, int taskId);

        Task DeleteLabelTaskAsync(int labelId, int taskId);

        List<LabelDto> GetAllLabelsFromTask(int taskId);
    }
}

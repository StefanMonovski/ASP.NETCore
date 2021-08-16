using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IPriorityService
    {
        Task<List<PriorityDto>> GetAllPriorities();

        Task<PriorityDto> GetPriority(int priorityId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IPriorityService
    {
        List<PriorityDto> GetAllPriorities();

        PriorityDto GetPriority(int priorityId);
    }
}

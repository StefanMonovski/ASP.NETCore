using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    public interface ILabelService
    {
        Task<int> AddLabelAsync(string title, string colorHex, string userId);

        Task<int> DeleteLabelAsync(int labelId);

        Task<int> UpdateLabelColorAsync(int labelId, string colorHex);

        List<LabelDto> GetAllLabels();

        LabelDto GetLabel(int labelId);
    }
}

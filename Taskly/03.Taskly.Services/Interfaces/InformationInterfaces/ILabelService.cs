using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    public interface ILabelService
    {
        Task<int> AddLabelAsync(string title, int? colorArgb, string userId);

        Task<int> DeleteLabelAsync(int labelId);

        Task<int> UpdateLabelColorAsync(int labelId, int? colorArgb);

        List<LabelDto> GetAllLabels();

        LabelDto GetLabel(int labelId);
    }
}

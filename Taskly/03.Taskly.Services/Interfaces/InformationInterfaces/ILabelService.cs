using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    public interface ILabelService
    {
        Task<string> AddLabelAsync(string title, int? colorArgb, string userId);

        Task<string> DeleteLabelAsync(int labelId);

        Task<string> UpdateLabelColorAsync(int labelId, int? colorArgb);

        Task<List<LabelDto>> GetAllLabels();

        Task<LabelDto> GetLabel(int labelId);
    }
}

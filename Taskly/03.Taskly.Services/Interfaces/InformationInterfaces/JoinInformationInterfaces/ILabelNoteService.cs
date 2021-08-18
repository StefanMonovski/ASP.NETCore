using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    public interface ILabelNoteService
    {
        Task AddLabelNoteAsync(int labelId, int noteId);

        Task DeleteLabelNoteAsync(int labelId, int noteId);

        List<LabelDto> GetAllLabelsFromNote(int noteId);
    }
}

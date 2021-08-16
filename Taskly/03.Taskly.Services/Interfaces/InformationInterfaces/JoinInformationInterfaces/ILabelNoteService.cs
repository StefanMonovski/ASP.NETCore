using Taskly.Services.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskly.Services.Interfaces
{
    interface ILabelNoteService
    {
        Task<string> AddLabelNoteAsync(int labelId, int noteId);

        Task<string> DeleteLabelNoteAsync(int labelId, int noteId);

        Task<List<LabelDto>> GetAllLabelsFromNote(int noteId);
    }
}

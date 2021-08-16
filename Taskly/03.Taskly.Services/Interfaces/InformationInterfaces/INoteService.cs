using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface INoteService
    {
        Task<string> AddNoteAsync(string title, string description, int? colorArgb, string userId);
        
        Task<string> AddNoteToProjectAsync(string title, string description, int? colorArgb, int projectId, string userId);

        Task<string> DeleteNoteAsync(int noteId);

        Task<string> UpdateNoteTitleAsync(int noteId, string title);

        Task<string> UpdateNoteDescriptionAsync(int noteId, string description);

        Task<string> UpdateNoteColorAsync(int noteId, int? colorArgb);

        Task<List<NoteDto>> GetAllPersonalNotes();

        Task<List<NoteDto>> GetAllProjectNotes(int projectId);

        Task<NoteDto> GetNote(int noteId);
    }
}                                               
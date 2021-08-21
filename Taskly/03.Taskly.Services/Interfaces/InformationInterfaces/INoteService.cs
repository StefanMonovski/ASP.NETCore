using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface INoteService
    {
        Task<string> AddNoteAsync(string title, string content, string colorHex, string userId);
        
        Task<string> AddNoteToProjectAsync(string title, string content, string colorHex, int projectId, string userId);

        Task<string> DeleteNoteAsync(int noteId);

        Task<string> UpdateNoteTitleAsync(int noteId, string title);

        Task<string> UpdateNoteContentAsync(int noteId, string content);

        Task<string> UpdateNoteColorAsync(int noteId, string colorHex);

        List<NoteDto> GetAllPersonalNotes();

        List<NoteDto> GetAllProjectNotes(int projectId);

        NoteDto GetNoteById(int noteId);

        NoteDto GetNoteByGuid(string noteGuid);
    }
}
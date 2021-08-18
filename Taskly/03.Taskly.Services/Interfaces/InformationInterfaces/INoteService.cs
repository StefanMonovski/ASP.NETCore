using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface INoteService
    {
        Task<string> AddNoteAsync(string title, string content, int? colorArgb, string userId);
        
        Task<string> AddNoteToProjectAsync(string title, string content, int? colorArgb, int projectId, string userId);

        Task<string> DeleteNoteAsync(int noteId);

        Task<string> UpdateNoteTitleAsync(int noteId, string title);

        Task<string> UpdateNoteContentAsync(int noteId, string content);

        Task<string> UpdateNoteColorAsync(int noteId, int? colorArgb);

        List<NoteDto> GetAllPersonalNotes();

        List<NoteDto> GetAllProjectNotes(int projectId);

        NoteDto GetNote(int noteId);
    }
}                                               
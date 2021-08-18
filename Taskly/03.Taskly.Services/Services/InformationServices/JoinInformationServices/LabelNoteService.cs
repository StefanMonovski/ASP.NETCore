using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Taskly.Services.Services
{
    public class LabelNoteService : ILabelNoteService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LabelNoteService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddLabelNoteAsync(int labelId, int noteId)
        {
            LabelNote labelNote = new()
            {
                LabelId = labelId,
                NoteId = noteId
            };

            await context.LabelsNotes.AddAsync(labelNote);
            await context.SaveChangesAsync();
        }

        public async Task DeleteLabelNoteAsync(int labelId, int noteId)
        {
            LabelNote labelNote = context.LabelsNotes
                .Where(x => x.LabelId == labelId && x.NoteId == noteId)
                .FirstOrDefault();

            context.LabelsNotes.Remove(labelNote);
            await context.SaveChangesAsync();
        }

        public List<LabelDto> GetAllLabelsFromNote(int noteId)
        {
            List<LabelDto> labelsDto = context.LabelsNotes
                .Where(x => x.NoteId == noteId)
                .Select(x => x.Label)
                .ProjectTo<LabelDto>(mapper.ConfigurationProvider)
                .ToList();

            return labelsDto;
        }
    }
}

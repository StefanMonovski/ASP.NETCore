using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskly.Data.Models;

namespace Taskly.Data.Configurations
{
    public class LabelNoteConfiguration : IEntityTypeConfiguration<LabelNote>
    {
        public void Configure(EntityTypeBuilder<LabelNote> builder)
        {
            builder.HasKey(x => new { x.LabelId, x.NoteId });
        }
    }
}

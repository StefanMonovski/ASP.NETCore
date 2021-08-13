using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskly.Data.Models;

namespace Taskly.Data.Configurations
{
    class ReplyReactionConfiguration : IEntityTypeConfiguration<ReplyReaction>
    {
        public void Configure(EntityTypeBuilder<ReplyReaction> builder)
        {
            builder.HasKey(x => new { x.ReplyId, x.CreatorId });
        }
    }
}

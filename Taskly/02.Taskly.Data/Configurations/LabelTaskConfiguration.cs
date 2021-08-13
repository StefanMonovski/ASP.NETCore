using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskly.Data.Models;

namespace Taskly.Data.Configurations
{
    public class LabelTaskConfiguration : IEntityTypeConfiguration<LabelTask>
    {
        public void Configure(EntityTypeBuilder<LabelTask> builder)
        {
            builder.HasKey(x => new { x.LabelId, x.TaskId });
        }
    }
}

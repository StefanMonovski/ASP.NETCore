using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data.Enumerators;
using Taskly.Data.Models;

namespace Taskly.Data.Configurations
{
    public class PriorityConfiguration : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            var priorities = new List<Priority>();
            var priorityTypeValues = Enum.GetValues(typeof(PriorityTypeEnum)).Cast<PriorityTypeEnum>().ToList();
            var priorityColorValues = Enum.GetValues(typeof(PriorityColorEnum)).Cast<PriorityColorEnum>().ToList();

            for (int i = 0; i < priorityTypeValues.Count; i++)
            {
                priorities.Add(new Priority
                {
                    Id = i + 1,
                    PriorityTypeName = priorityTypeValues[i].ToString(),
                    PriorityType = priorityTypeValues[i],
                    PriorityColorName = priorityColorValues[i].ToString(),
                    PriorityColor = priorityColorValues[i]
                });
            }

            builder.HasData(priorities);
        }
    }
}

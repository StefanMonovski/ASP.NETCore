using System;
using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class ChildTaskDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Schedule { get; set; }

        public bool IsCompleted { get; set; }

        public string CreatorId { get; set; }

        public int ProjectId { get; set; }

        public int? ParentTaskId { get; set; }

        public int? PriorityId { get; set; }

        public PriorityDto Priority { get; set; }

        public List<CommentDto> Comments { get; set; }

        public List<LabelDto> Labels { get; set; }
    }
}

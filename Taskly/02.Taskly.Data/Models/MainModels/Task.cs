using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Task : BaseModel<int>
    {
        public Task()
        {
            Guid = System.Guid.NewGuid().ToString();
            ChildTasks = new HashSet<Task>();
            Comments = new HashSet<Comment>();
            TaskLabels = new HashSet<LabelTask>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime? Schedule { get; set; }

        public bool IsCompleted { get; set; } = false;

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int? PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int? ParentTaskId { get; set; }
        public Task ParentTask { get; set; }

        public IEnumerable<Task> ChildTasks { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<LabelTask> TaskLabels { get; set; }
    }
}

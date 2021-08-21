using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Project : BaseModel<int>
    {
        public Project()
        {
            Guid = System.Guid.NewGuid().ToString();
            ProjectUsers = new HashSet<ProjectUser>();
            Notes = new HashSet<Note>();
            Tasks = new HashSet<Task>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [StringLength(7)]
        public string ColorHex { get; set; }

        public DateTime? ArchivedOn { get; set; }

        public bool IsArchived { get; set; } = false;

        public bool IsPersonal { get; set; } = true;

        public IEnumerable<ProjectUser> ProjectUsers { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}

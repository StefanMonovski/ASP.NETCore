using System;
using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public int? ColorArgb { get; set; }

        public DateTime? ArchivedOn { get; set; }

        public bool IsArchived { get; set; }

        public bool IsPersonal { get; set; }

        public bool IsFavorite { get; set; }

        public List<ProjectUserDto> ProjectUsers { get; set; }

        public List<NoteDto> Notes { get; set; }

        public List<TaskDto> Tasks { get; set; }
    }
}

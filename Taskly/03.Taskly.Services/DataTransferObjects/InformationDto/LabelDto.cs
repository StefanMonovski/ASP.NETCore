using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class LabelDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ColorArgb { get; set; }

        public string CreatorId { get; set; }

        public List<TaskDto> Tasks { get; set; }

        public List<NoteDto> Notes { get; set; }
    }
}

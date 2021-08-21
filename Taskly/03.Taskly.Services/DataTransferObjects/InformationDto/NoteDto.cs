using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class NoteDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ColorHex { get; set; }

        public string CreatorId { get; set; }

        public int? ProjectId { get; set; }

        public ProjectDto Project { get; set; }

        public List<LabelDto> Labels { get; set; }
    }
}

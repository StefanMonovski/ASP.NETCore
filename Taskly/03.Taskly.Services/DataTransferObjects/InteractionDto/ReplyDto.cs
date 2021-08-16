using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class ReplyDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Content { get; set; }

        public string CreatorId { get; set; }

        public int CommentId { get; set; }

        public CommentDto Comment { get; set; }

        public List<ReplyReactionDto> ReplyReactions { get; set; }
    }
}

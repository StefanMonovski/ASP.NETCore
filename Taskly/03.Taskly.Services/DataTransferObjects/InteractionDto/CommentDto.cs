using System.Collections.Generic;

namespace Taskly.Services.DataTransferObjects
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Content { get; set; }

        public string CreatorId { get; set; }

        public int TaskId { get; set; }

        public TaskDto Task { get; set; }

        public List<ReplyDto> Replies { get; set; }

        public List<CommentReactionDto> CommentReactions { get; set; }
    }
}

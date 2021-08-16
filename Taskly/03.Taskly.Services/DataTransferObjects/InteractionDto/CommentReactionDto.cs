namespace Taskly.Services.DataTransferObjects
{
    public class CommentReactionDto
    {
        public string CreatorId { get; set; }

        public int CommentId { get; set; }

        public bool IsPositive { get; set; }

        public CommentDto Comment { get; set; }
    }
}

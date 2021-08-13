namespace Taskly.Data.Models
{
    public class CommentReaction : BaseModel
    {
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public bool IsPositive { get; set; }
    }
}

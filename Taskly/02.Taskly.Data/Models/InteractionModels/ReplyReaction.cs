namespace Taskly.Data.Models
{
    public class ReplyReaction : BaseModel
    {
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int ReplyId { get; set; }
        public Reply Reply { get; set; }

        public bool IsPositive { get; set; }
    }
}

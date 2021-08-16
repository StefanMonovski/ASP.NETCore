namespace Taskly.Services.DataTransferObjects
{
    public class ReplyReactionDto
    {
        public string CreatorId { get; set; }

        public int ReplyId { get; set; }

        public bool IsPositive { get; set; }

        public ReplyDto Reply { get; set; }
    }
}

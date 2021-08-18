using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IReplyReactionService
    {
        Task AddReplyReaction(bool isPositive, int replyId, string userId);

        Task DeleteReplyReaction(int replyId, string creatorId);

        List<ReplyReactionDto> GetAllReactionsByReply(int replyId);

        ReplyReactionDto GetReplyReaction(int replyId, string creatorId);
    }
}

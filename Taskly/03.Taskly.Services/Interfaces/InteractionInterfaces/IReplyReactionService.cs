using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IReplyReactionService
    {
        Task<string> AddReplyReaction(bool isPositive, int replyId, string userId);

        Task<string> DeleteReplyReaction(int replyId, string creatorId);

        Task<List<ReplyReactionDto>> GetAllReactionsByReply(int replyId);

        Task<ReplyReactionDto> GetReplyReaction(int replyId, string creatorId);
    }
}

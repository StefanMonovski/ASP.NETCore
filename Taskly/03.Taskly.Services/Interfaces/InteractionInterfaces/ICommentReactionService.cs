using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface ICommentReactionService
    {
        Task AddCommentReaction(bool isPositive, int commentId, string userId);

        Task DeleteCommentReaction(int commentId, string creatorId);

        List<CommentReactionDto> GetAllReactionsByComment(int commentId);

        CommentReactionDto GetCommentReaction(int commentId, string creatorId);
    }
}

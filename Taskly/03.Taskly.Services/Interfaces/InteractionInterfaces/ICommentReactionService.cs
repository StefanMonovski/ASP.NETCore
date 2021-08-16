using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface ICommentReactionService
    {
        Task<string> AddCommentReaction(bool isPositive, int commentId, string userId);

        Task<string> DeleteCommentReaction(int commentId, string creatorId);

        Task<List<CommentReactionDto>> GetAllReactionsByComment(int commentId);

        Task<CommentReactionDto> GetCommentReaction(int commentId, string creatorId);
    }
}

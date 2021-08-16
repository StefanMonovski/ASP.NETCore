using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface IReplyService
    {
        Task<string> AddReplyAsync(string content, int commentId, string userId);

        Task<string> DeleteReplyAsync(int replyId);

        Task<string> UpdateReplyContentAsync(int replyId, string content);

        Task<List<ReplyDto>> GetAllRepliesByComment(int commentId);

        Task<List<ReplyDto>> GetAllRepliesByUser(string userId);

        Task<ReplyDto> GetReply(int replyId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Taskly.Services.DataTransferObjects;

namespace Taskly.Services.Interfaces
{
    public interface ICommentService
    {
        Task<string> AddCommentAsync(string content, int taskId, string userId);

        Task<string> DeleteCommentAsync(int commentId);

        Task<string> UpdateCommentContentAsync(int commentId, string content);

        List<CommentDto> GetAllCommentsByTask(int taskId);

        List<CommentDto> GetAllCommentsByUser(string userId);

        CommentDto GetCommentById(int commentId);

        CommentDto GetCommentByGuid(string commentGuid);
    }
}

using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;

namespace Taskly.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddCommentAsync(string content, int taskId, string userId)
        {
            Comment comment = new()
            {
                Content = content,
                TaskId = taskId,
                CreatorId = userId
            };

            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

            return comment.Guid;
        }

        public async Task<string> DeleteCommentAsync(int commentId)
        {
            Comment comment = context.Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefault();

            context.Comments.Remove(comment);
            await context.SaveChangesAsync();

            return comment.Guid;
        }

        public async Task<string> UpdateCommentContentAsync(int commentId, string content)
        {
            Comment comment = context.Comments
                .Where(x => x.Id == commentId)
                .FirstOrDefault();

            comment.Content = content;
            await context.SaveChangesAsync();

            return comment.Guid;
        }

        public List<CommentDto> GetAllCommentsByTask(int taskId)
        {
            List<CommentDto> commentsDto = context.Comments
                .Where(x => x.TaskId == taskId)
                .ProjectTo<CommentDto>(mapper.ConfigurationProvider)
                .ToList();

            return commentsDto;
        }

        public List<CommentDto> GetAllCommentsByUser(string userId)
        {
            List<CommentDto> commentsDto = context.Comments
                .Where(x => x.CreatorId == userId)
                .ProjectTo<CommentDto>(mapper.ConfigurationProvider)
                .ToList();

            return commentsDto;
        }

        public CommentDto GetComment(int commentId)
        {
            CommentDto commentDto = context.Comments
                .Where(x => x.Id == commentId)
                .ProjectTo<CommentDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return commentDto;
        }
    }
}

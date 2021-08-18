using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using Taskly.Data;
using Taskly.Data.Models;
using Taskly.Services.DataTransferObjects;
using Taskly.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace Taskly.Services.Services
{
    public class CommentReactionService : ICommentReactionService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CommentReactionService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        
        public async Task AddCommentReaction(bool isPositive, int commentId, string userId)
        {
            CommentReaction commentReaction = new()
            {
                IsPositive = isPositive,
                CommentId = commentId,
                CreatorId = userId
            };

            await context.CommentsReactions.AddAsync(commentReaction);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCommentReaction(int commentId, string creatorId)
        {
            CommentReaction commentReaction = context.CommentsReactions
                .Where(x => x.CommentId == commentId && x.CreatorId == creatorId)
                .FirstOrDefault();

            context.CommentsReactions.Remove(commentReaction);
            await context.SaveChangesAsync();
        }

        public List<CommentReactionDto> GetAllReactionsByComment(int commentId)
        {
            List<CommentReactionDto> commentReactionsDto = context.CommentsReactions
                .Where(x => x.CommentId == commentId)
                .ProjectTo<CommentReactionDto>(mapper.ConfigurationProvider)
                .ToList();

            return commentReactionsDto;
        }

        public CommentReactionDto GetCommentReaction(int commentId, string creatorId)
        {
            CommentReactionDto commentReactionDto = context.CommentsReactions
                .Where(x => x.CommentId == commentId && x.CreatorId == creatorId)
                .ProjectTo<CommentReactionDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return commentReactionDto;
        }
    }
}

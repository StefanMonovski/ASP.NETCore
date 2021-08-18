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
    public class ReplyReactionService : IReplyReactionService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReplyReactionService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddReplyReaction(bool isPositive, int replyId, string userId)
        {
            ReplyReaction replyReaction = new()
            {
                IsPositive = isPositive,
                ReplyId = replyId,
                CreatorId = userId
            };

            await context.RepliesReactions.AddAsync(replyReaction);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteReplyReaction(int replyId, string creatorId)
        {
            ReplyReaction replyReaction = context.RepliesReactions
                .Where(x => x.ReplyId == replyId && x.CreatorId == creatorId)
                .FirstOrDefault();

            context.RepliesReactions.Remove(replyReaction);
            await context.SaveChangesAsync();
        }

        public List<ReplyReactionDto> GetAllReactionsByReply(int replyId)
        {
            List<ReplyReactionDto> replyReactionsDto = context.RepliesReactions
                .Where(x => x.ReplyId == replyId)
                .ProjectTo<ReplyReactionDto>(mapper.ConfigurationProvider)
                .ToList();

            return replyReactionsDto;
        }

        public ReplyReactionDto GetReplyReaction(int replyId, string creatorId)
        {
            ReplyReactionDto replyReactionDto = context.RepliesReactions
                .Where(x => x.ReplyId == replyId && x.CreatorId == creatorId)
                .ProjectTo<ReplyReactionDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return replyReactionDto;
        }
    }
}

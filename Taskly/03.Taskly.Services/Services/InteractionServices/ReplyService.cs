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
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ReplyService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<string> AddReplyAsync(string content, int commentId, string userId)
        {
            Reply reply = new()
            {
                Content = content,
                CommentId = commentId,
                CreatorId = userId
            };

            await context.Replies.AddAsync(reply);
            await context.SaveChangesAsync();

            return reply.Guid;
        }

        public async Task<string> DeleteReplyAsync(int replyId)
        {
            Reply reply = context.Replies
                .Where(x => x.Id == replyId)
                .FirstOrDefault();

            context.Replies.Remove(reply);
            await context.SaveChangesAsync();

            return reply.Guid;
        }

        public async Task<string> UpdateReplyContentAsync(int replyId, string content)
        {
            Reply reply = context.Replies
                .Where(x => x.Id == replyId)
                .FirstOrDefault();

            reply.Content = content;
            await context.SaveChangesAsync();

            return reply.Guid;
        }

        public List<ReplyDto> GetAllRepliesByComment(int commentId)
        {
            List<ReplyDto> repliesDto = context.Replies
                .Where(x => x.CommentId == commentId)
                .ProjectTo<ReplyDto>(mapper.ConfigurationProvider)
                .ToList();

            return repliesDto;
        }

        public List<ReplyDto> GetAllRepliesByUser(string userId)
        {
            List<ReplyDto> repliesDto = context.Replies
                .Where(x => x.CreatorId == userId)
                .ProjectTo<ReplyDto>(mapper.ConfigurationProvider)
                .ToList();

            return repliesDto;
        }

        public ReplyDto GetReplyById(int replyId)
        {
            ReplyDto replyDto = context.Replies
                .Where(x => x.Id == replyId)
                .ProjectTo<ReplyDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return replyDto;
        }

        public ReplyDto GetReplyByGuid(string replyGuid)
        {
            ReplyDto replyDto = context.Replies
                .Where(x => x.Guid == replyGuid)
                .ProjectTo<ReplyDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return replyDto;
        }
    }
}

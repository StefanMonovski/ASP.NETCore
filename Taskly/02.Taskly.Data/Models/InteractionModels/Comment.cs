using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Comment : BaseModel<int>
    {
        public Comment()
        {
            Guid = System.Guid.NewGuid().ToString();
            Replies = new HashSet<Reply>();
            CommentReactions = new HashSet<CommentReaction>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public IEnumerable<Reply> Replies { get; set; }

        public IEnumerable<CommentReaction> CommentReactions { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Reply : BaseModel<int>
    {
        public Reply()
        {
            Guid = System.Guid.NewGuid().ToString();
            ReplyReactions = new HashSet<ReplyReaction>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public IEnumerable<ReplyReaction> ReplyReactions { get; set; }
    }
}

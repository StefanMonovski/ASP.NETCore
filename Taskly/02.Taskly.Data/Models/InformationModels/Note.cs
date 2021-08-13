using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Note : BaseModel<int>
    {
        public Note()
        {
            Guid = System.Guid.NewGuid().ToString();
            NoteLabels = new HashSet<LabelNote>();
        }

        [Required]
        public string Guid { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int? ColorArgb { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        public IEnumerable<LabelNote> NoteLabels { get; set; }
    }
}

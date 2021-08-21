using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Data.Models
{
    public class Label : BaseModel<int>
    {
        public Label()
        {
            LabelTasks = new HashSet<LabelTask>();
            LabelNotes = new HashSet<LabelNote>();
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [StringLength(7)]
        public string ColorHex { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public IEnumerable<LabelTask> LabelTasks { get; set; }

        public IEnumerable<LabelNote> LabelNotes { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taskly.Data.Enumerators;

namespace Taskly.Data.Models
{
    public class Priority
    {
        public Priority()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string PriorityTypeName { get; set; } 
        public PriorityTypeEnum PriorityType { get; set; }

        [Required]
        public string PriorityColorName { get; set; } 
        public PriorityColorEnum PriorityColor { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}

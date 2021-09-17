using System.ComponentModel.DataAnnotations;

namespace Taskly.Web.InputModels
{
    public class TaskInputModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectGuid { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(20, ErrorMessage = "Title must be at max 20 characters long.")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Description must be at max 500 characters long.")]
        public string Description { get; set; }
    }
}

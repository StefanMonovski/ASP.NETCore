using System.ComponentModel.DataAnnotations;

namespace Taskly.Web.InputModels
{
    public class ProjectInputModel
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title must be at max 100 characters long.")]
        public string Title { get; set; }

        [Required]
        public string ColorPicker { get; set; }
    }
}

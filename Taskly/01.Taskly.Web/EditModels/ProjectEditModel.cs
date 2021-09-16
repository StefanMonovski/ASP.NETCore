using System.ComponentModel.DataAnnotations;

namespace Taskly.Web.ViewModels
{
    public class ProjectEditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Guid { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(20, ErrorMessage = "Title must be at max 20 characters long.")]
        public string Title { get; set; }

        [Required]
        public string ColorPicker { get; set; }
    }
}

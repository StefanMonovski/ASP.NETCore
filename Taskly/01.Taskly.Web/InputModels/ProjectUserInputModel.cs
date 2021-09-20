using System.ComponentModel.DataAnnotations;

namespace Taskly.Web.InputModels
{
    public class ProjectUserInputModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectGuid { get; set; }
        
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required]
        public bool IsCollaborator { get; set; }
    }
}

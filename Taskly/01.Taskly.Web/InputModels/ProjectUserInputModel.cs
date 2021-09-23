using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Taskly.Web.Validation;

namespace Taskly.Web.InputModels
{
    public class ProjectUserInputModel
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        public string ProjectGuid { get; set; }
        
        [UsernameExists]
        [UsernameNotCurrent]
        [Remote("UsernameIsValid", "Project")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required]
        public bool IsCollaborator { get; set; }
    }
}

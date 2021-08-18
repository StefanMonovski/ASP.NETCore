namespace Taskly.Data.Models
{
    public class ProjectUser : BaseModel
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsCreator { get; set; }

        public bool IsCollaborator { get; set; }

        public bool IsProjectFavorite { get; set; } = false;
    }
}

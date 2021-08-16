namespace Taskly.Services.DataTransferObjects
{
    public class ProjectUserDto
    {
        public int ProjectId { get; set; }

        public string UserId { get; set; }

        public bool IsCreator { get; set; }

        public bool IsCollaborator { get; set; }

        public ProjectDto Project { get; set; }
    }
}

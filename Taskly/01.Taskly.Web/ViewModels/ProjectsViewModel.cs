namespace Taskly.Web.ViewModels
{
    public class ProjectsViewModel
    {
        public string Guid { get; set; }

        public string Title { get; set; }

        public string ColorHex { get; set; }

        public bool IsPersonal { get; set; }

        public bool IsFavorite { get; set; }
    }
}

using System.Collections.Generic;

namespace Taskly.Web.ViewModels
{
    public class DisplayViewModel
    {
        public string Filter { get; set; }

        public List<ProjectsViewModel> Projects { get; set; }
    }
}